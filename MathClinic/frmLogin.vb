Option Strict On
Option Explicit On

Imports System
Imports System.IO
Imports System.Net
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Text

Public Class frmLogin

    Private Sub btnLogin_Click(sender As System.Object, e As System.EventArgs) Handles btnLogin.Click
        Dim strUsername As String = txtUsername.Text
        Dim strPassword As String = txtPassword.Text

        Dim cookies As CookieContainer = New CookieContainer()
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim postStream As Stream = Nothing
        Dim jsonQuestions As String
        Dim questions As dataQuestions
        Dim jss As JavaScriptSerializer = New JavaScriptSerializer()

        ' Create a request object to operate
        request = DirectCast(WebRequest.Create("http://vps.kastlersteinhauser.com/math/login"), HttpWebRequest)
        ' Specify we want to POST
        request.Method = "POST"
        request.ContentType = "application/x-www-form-urlencoded"

        ' Add data we want to send, username and password
        Dim data As StringBuilder = New StringBuilder()
        data.Append("username=" + HttpUtility.UrlEncode(strUsername))
        data.Append("&password=" + HttpUtility.UrlEncode(strPassword))
        data.Append("&submit=" + HttpUtility.UrlEncode("Login"))

        ' Create byte array of data we want to send
        Dim byteData As Byte() = UTF8Encoding.UTF8.GetBytes(data.ToString())

        ' Set content length of the request
        request.ContentLength = byteData.Length

        ' Store some cookies
        request.CookieContainer = cookies

        ' Write the data
        Try
            postStream = request.GetRequestStream()
            postStream.Write(byteData, 0, byteData.Length)
        Catch ex As Exception
            Console.WriteLine("Error writing data to server.")
        Finally
            If Not postStream Is Nothing Then postStream.Close()
        End Try

        Try
            ' Get the response
            response = DirectCast(request.GetResponse(), HttpWebResponse)
            ' Open the stream using StreamReader for easy access
            'Dim reader As New StreamReader(response.GetResponseStream())
            ' Read the content
            'Dim content As String = reader.ReadToEnd()

            cookies = request.CookieContainer

            ' Write response to console
            'Console.WriteLine(content)
        Catch ex As Exception
            Console.WriteLine("Error receiving response from server.")
        Finally
            If Not response Is Nothing Then response.Close()
        End Try

        ' Create a request object to operate
        request = DirectCast(WebRequest.Create("http://vps.kastlersteinhauser.com/math/questions"), HttpWebRequest)

        ' Store some cookies
        request.CookieContainer = cookies

        Try
            ' Fire the request and get the response
            response = DirectCast(request.GetResponse(), HttpWebResponse)
            ' Open the stream using StreamReader for easy access
            Dim reader As New StreamReader(response.GetResponseStream())
            ' Read the content
            jsonQuestions = reader.ReadToEnd()

            ' Parse JSON response into a response object
            questions = jss.Deserialize(Of dataQuestions)(jsonQuestions)
        Catch ex As Exception
            Console.WriteLine("Error receiving response from server.")
        Finally
            If Not response Is Nothing Then response.Close()
        End Try

        Try

        Catch ex As Exception
            Console.WriteLine("Error parsing questions JSON")
        End Try

        frmQuestions.Questions_setList(questions.questions)
        frmQuestions.Show()
        Me.Hide()
    End Sub
End Class
