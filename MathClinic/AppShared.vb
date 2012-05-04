' Desc: Centralized class to maintain state throughout the application
' Auth: Myles A. K. Steinhauser
' Date: 05/04/2012

Option Strict On
Option Explicit On

Imports System
Imports System.Configuration
Imports System.IO
Imports System.Net
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Text

Public Module AppShared
    Public Property strBaseUrl As String = "http://vps.kastlersteinhauser.com/math/"
    Public Property strConfigLocation As String = "app.config"
    Private inCookies As CookieContainer = Nothing
    Private inData As data = Nothing
    Private strConfDBPath As String = "DBPath"
    Private strConfOfflineStore As String = "OfflineStore"
    Private strConfOfflineUse As String = "OfflineUse"

    Public Property cookies As CookieContainer
        Get
            ' Share cookies across all instances of this module
            If inCookies Is Nothing Then
                inCookies = New CookieContainer()
            End If
            cookies = inCookies
        End Get

        Set(value As CookieContainer)
            inCookies = value
        End Set
    End Property

    Public Property data As data
        Get
            If inData Is Nothing Then
                inData = New data()
            End If
            data = inData
        End Get
        Set(value As data)
            inData = value
        End Set
    End Property

    Public Property DBPath As String
        Get
            DBPath = My.Settings(strConfDBPath).ToString
        End Get
        Set(value As String)
            My.Settings(strConfDBPath) = value
            My.Settings.Save()
        End Set
    End Property

    Public Property OfflineStore As String
        Get
            OfflineStore = My.Settings(strConfOfflineStore).ToString
        End Get
        Set(value As String)
            My.Settings(strConfOfflineStore) = value
            My.Settings.Save()
        End Set
    End Property

    Public Property OfflineUse As String
        Get
            OfflineUse = My.Settings(strConfOfflineUse).ToString
        End Get
        Set(value As String)
            My.Settings(strConfOfflineUse) = value
            My.Settings.Save()
        End Set
    End Property

    Public Sub close()
        'Show the message, with apt buttons
        If MsgBox("Do you want to exit?", MsgBoxStyle.YesNo, "Are You Sure?") = MsgBoxResult.No Then
            'if "No" was pressed, do nothing
        Else
            Application.Exit()
        End If
    End Sub

    Public Function makeGetRequest(strUrl As String) As String
        Dim httpRequest As HttpWebRequest
        Dim httpResponse As HttpWebResponse = Nothing
        Dim postStream As Stream = Nothing
        Dim strResponse As String = String.Empty

        Dim strServer As String = String.Empty
        Dim strStatusCode As String = String.Empty
        Dim strStatusDescription As String = String.Empty

        ' Create a request object to operate
        httpRequest = DirectCast(WebRequest.Create(strUrl), HttpWebRequest)

        ' Store some cookies
        httpRequest.CookieContainer = cookies

        Try
            ' Fire the request and get the response
            httpResponse = DirectCast(httpRequest.GetResponse(), HttpWebResponse)

            strServer = httpResponse.Server
            strStatusCode = httpResponse.StatusCode.ToString
            strStatusDescription = httpResponse.StatusDescription

            ' Open the stream using StreamReader for easy access
            Dim reader As New StreamReader(httpResponse.GetResponseStream())
            ' Read the content
            strResponse = reader.ReadToEnd()

            Return strResponse
        Catch ex As Exception
            Console.WriteLine("Error retrieving data from " + strUrl)
            Console.WriteLine("Server: " + strServer)
            Console.WriteLine("Server response: " + strStatusCode)
            Console.WriteLine("Description: " + strStatusDescription)

            ' Request failed, return nothing so other code doesn't blow up on unexpected response data
            Return Nothing
        Finally
            ' If the request sucessfully went through, close our response.
            If Not httpResponse Is Nothing Then httpResponse.Close()
        End Try
    End Function

    Public Function makePostRequest(strUrl As String, dicData As Dictionary(Of String, String)) As String
        Dim httpRequest As HttpWebRequest
        Dim httpResponse As HttpWebResponse = Nothing
        Dim postStream As Stream = Nothing
        Dim strResponse As String = String.Empty
        Dim data As StringBuilder = New StringBuilder()

        Dim strServer As String = String.Empty
        Dim strStatusCode As String = String.Empty
        Dim strStatusDescription As String = String.Empty

        ' Create a request object to operate
        httpRequest = DirectCast(WebRequest.Create(strUrl), HttpWebRequest)

        ' Specify we want to POST
        httpRequest.Method = "POST"
        httpRequest.ContentType = "application/x-www-form-urlencoded"

        ' Store some cookies
        httpRequest.CookieContainer = cookies

        If dicData IsNot Nothing Then
            'Convert the data in the Dictionary to params to post
            Dim first As Boolean = True
            For Each pair As KeyValuePair(Of String, String) In dicData
                If first Then
                    first = False
                Else
                    data.Append("&")
                End If
                data.Append(HttpUtility.UrlEncode(pair.Key) + "=" + HttpUtility.UrlEncode(pair.Value))
            Next
        End If

        ' Create byte array of data we want to send
        Dim byteData As Byte() = UTF8Encoding.UTF8.GetBytes(data.ToString())

        ' Set content length header of the request
        httpRequest.ContentLength = byteData.Length

        ' Write the data
        Try
            postStream = httpRequest.GetRequestStream()
            postStream.Write(byteData, 0, byteData.Length)
        Catch ex As Exception
            Console.WriteLine("Error posting data to server.")
        Finally
            If Not postStream Is Nothing Then postStream.Close()
        End Try

        Try
            ' Get the response from the server
            httpResponse = DirectCast(httpRequest.GetResponse(), HttpWebResponse)

            strServer = httpResponse.Server
            strStatusCode = httpResponse.StatusCode.ToString
            strStatusDescription = httpResponse.StatusDescription

            ' Open the stream using StreamReader for easy access
            Dim reader As New StreamReader(httpResponse.GetResponseStream())
            ' Read the content
            strResponse = reader.ReadToEnd()


            Return strResponse
        Catch ex As Exception
            Console.WriteLine("Error retrieving data from " + strUrl)
            Console.WriteLine("Server: " + strServer)
            Console.WriteLine("Server response: " + strStatusCode)
            Console.WriteLine("Description: " + strStatusDescription)

            ' Request failed, return nothing so other code doesn't blow up on unexpected response data
            Return Nothing
        Finally
            ' If the request sucessfully went through, close our response.
            If Not httpResponse Is Nothing Then httpResponse.Close()
        End Try
    End Function

End Module

