Option Strict On
Option Explicit On

Imports System
Imports System.IO
Imports System.Net
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Text

Public Class frmQuestions

    Dim questions As data.Question()
    Dim questionsGenerated As data.QuestionsGenerated

    Dim request As HttpWebRequest
    Dim response As HttpWebResponse = Nothing
    Dim jss As JavaScriptSerializer = New JavaScriptSerializer()

    Dim jsonQuestions As String
    Dim qs As data.QuestionsList

    Public Sub Questions_setList(questions As data.Question())
        Me.questions = questions
    End Sub

    Private Sub Questions_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        For Each q As data.Question In questions
            lstQuestions.Items.Add(q.equation)
        Next
    End Sub

    Private Sub Questions_Close(sender As System.Object, e As System.EventArgs) Handles MyBase.FormClosed
        frmLogin.Close()
        frmTest.Close()
    End Sub

    Private Sub btnGenerateQuestions_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerateQuestions.Click
        Dim url As String = "http://vps.kastlersteinhauser.com/math/questions/" + lstQuestions.SelectedItem.ToString + "/" + "20"

        ' Create a request object to operate
        request = DirectCast(WebRequest.Create(url), HttpWebRequest)

        ' Store some cookies
        request.CookieContainer = AppShared.cookies

        Try
            ' Fire the request and get the response
            response = DirectCast(request.GetResponse(), HttpWebResponse)
            ' Open the stream using StreamReader for easy access
            Dim reader As New StreamReader(response.GetResponseStream())
            ' Read the content
            jsonQuestions = reader.ReadToEnd()

            ' Parse JSON response into a response object
            questionsGenerated = jss.Deserialize(Of data.QuestionsGenerated)(jsonQuestions)

            ' Clear out the old list before we add more
            lstGenerateQuestions.Items.Clear()

            ' Update the Number and Max Generated
            txtNumberGenerated.Text = questionsGenerated.count
            txtMaxGenerated.Text = questionsGenerated.total

            For Each q As String In questionsGenerated.questions
                lstGenerateQuestions.Items.Add(q)
            Next
        Catch ex As Exception
            Console.WriteLine("Error loading generated questions from server." + response.StatusCode.ToString + ": " + response.StatusDescription)
        Finally
            If Not response Is Nothing Then response.Close()
        End Try

        Try

        Catch ex As Exception
            Console.WriteLine("Error parsing questions JSON")
        End Try
    End Sub
End Class