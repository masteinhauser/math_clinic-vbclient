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
        lblServerMessage.Text = String.Empty
        pgrsLoginBar.Value = 0
        pgrsLoginBar.Visible = True
        pgrsLoginBar.PerformStep()

        Dim strUsername As String = txtUsername.Text
        Dim strPassword As String = txtPassword.Text

        Dim content As String = String.Empty
        Dim server As String = String.Empty
        Dim statusCode As String = String.Empty
        Dim statusDescription As String = String.Empty

        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim postStream As Stream = Nothing
        Dim jsonQuestions As String
        Dim questions As data.QuestionsList
        Dim jss As JavaScriptSerializer = New JavaScriptSerializer()

        ' Create a request object to operate
        request = DirectCast(WebRequest.Create("http://vps.kastlersteinhauser.com/math/login"), HttpWebRequest)
        pgrsLoginBar.PerformStep()

        ' Specify we want to POST
        request.Method = "POST"
        request.ContentType = "application/x-www-form-urlencoded"

        ' Add data we want to send, username and password
        Dim data As StringBuilder = New StringBuilder()
        data.Append("username=" + HttpUtility.UrlEncode(strUsername))
        data.Append("&password=" + HttpUtility.UrlEncode(strPassword))
        data.Append("&submit=" + HttpUtility.UrlEncode("Login"))
        pgrsLoginBar.PerformStep()

        ' Create byte array of data we want to send
        Dim byteData As Byte() = UTF8Encoding.UTF8.GetBytes(data.ToString())
        pgrsLoginBar.PerformStep()

        ' Set content length of the request
        request.ContentLength = byteData.Length

        ' Store some cookies
        request.CookieContainer = AppShared.cookies

        ' Write the data
        Try
            postStream = request.GetRequestStream()
            postStream.Write(byteData, 0, byteData.Length)
            pgrsLoginBar.PerformStep()
        Catch ex As Exception
            lblServerMessage.Text = "Error writing data to server."
        Finally
            If Not postStream Is Nothing Then postStream.Close()
        End Try

        Try
            ' Get the response
            response = DirectCast(request.GetResponse(), HttpWebResponse)
            statusCode = response.Server
            statusCode = response.StatusCode.ToString
            statusDescription = response.StatusDescription
            pgrsLoginBar.PerformStep()
        Catch ex As Exception
            lblServerMessage.Text = "No response received from server."
            Console.WriteLine("Server: " + server)
            Console.WriteLine("Server response: " + statusCode)
            Console.WriteLine("Description: " + statusDescription)
            Console.WriteLine("Cached?: " + response.IsFromCache.ToString)
            Exit Sub
        End Try

        Try
            ' Open the stream using StreamReader for easy access
            'Dim reader As New StreamReader(response.GetResponseStream())
            ' Read the content
            'content = reader.ReadToEnd()

            AppShared.cookies = request.CookieContainer
        Catch ex As Exception
            ' Write response to console
            'Console.WriteLine(content)
            lblServerMessage.Text = "Error logging into server." + statusCode + ": " + statusDescription
            Console.WriteLine("Server: " + server)
            Console.WriteLine("Server response: " + statusCode)
            Console.WriteLine("Description: " + statusDescription)
            Console.WriteLine("Cached?: " + response.IsFromCache.ToString)
            Exit Sub
        Finally
            If Not response Is Nothing Then response.Close()
        End Try

        ' Create a request object to operate
        request = DirectCast(WebRequest.Create("http://vps.kastlersteinhauser.com/math/questions"), HttpWebRequest)

        ' Store some cookies
        request.CookieContainer = AppShared.cookies

        Try
            ' Fire the request and get the response
            response = DirectCast(request.GetResponse(), HttpWebResponse)
            Console.WriteLine(response)
            statusCode = response.StatusCode.ToString
            statusDescription = response.StatusDescription
            pgrsLoginBar.PerformStep()

            ' Open the stream using StreamReader for easy access
            Dim reader As New StreamReader(response.GetResponseStream())
            ' Read the content
            jsonQuestions = reader.ReadToEnd()
            Console.WriteLine(jsonQuestions)

            ' Parse JSON response into a response object
            questions = jss.Deserialize(Of data.QuestionsList)(jsonQuestions)

            pgrsLoginBar.PerformStep()
        Catch ex As Exception
            lblServerMessage.Text = "Error receiving questions from server."
            Console.WriteLine("Server: " + server)
            Console.WriteLine("Server response: " + statusCode)
            Console.WriteLine("Description: " + statusDescription)
            Console.WriteLine("Cached?: " + response.IsFromCache.ToString)
            Exit Sub
        Finally
            If Not response Is Nothing Then response.Close()
        End Try

        Try
            frmQuestions.Questions_setList(questions.questions)
            frmQuestions.Show()
            Me.Hide()
        Catch ex As Exception
            lblServerMessage.Text = "Error parsing questions JSON"
            Console.WriteLine("Server: " + server)
            Console.WriteLine("Server response: " + statusCode)
            Console.WriteLine("Description: " + statusDescription)
            Console.WriteLine("Cached?: " + response.IsFromCache.ToString)
            Exit Sub
        End Try

    End Sub

    Private Sub frmLogin_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' Give the user feedback while logging in, as it can be a length process.
        ' Increment the bar after each processing point in the Login handler
        ' Maximum is a manual count of all processing points.
        pgrsLoginBar.Minimum = 0
        pgrsLoginBar.Maximum = 10
    End Sub
End Class
