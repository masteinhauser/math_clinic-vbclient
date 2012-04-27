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

        Dim server As String = String.Empty
        Dim statusCode As String = String.Empty
        Dim statusDescription As String = String.Empty

        Dim dicData As Dictionary(Of String, String) = New Dictionary(Of String, String)
        Dim strResponse As String
        Dim questions As data.QuestionsList
        Dim jss As JavaScriptSerializer = New JavaScriptSerializer()

        ' Add data we want to send, username and password
        dicData.Add("username", strUsername)
        dicData.Add("password", strPassword)
        dicData.Add("submit", "Login")
        pgrsLoginBar.PerformStep()

        Try
            strResponse = AppShared.makePostRequest("http://vps.kastlersteinhauser.com/math/login", dicData)
        Catch ex As Exception
            lblServerMessage.Text = "Error logging into server."
            Exit Sub
        Finally
            pgrsLoginBar.PerformStep()
        End Try

        Try
            ' Fire the request and get the response
            strResponse = AppShared.makeGetRequest("http://vps.kastlersteinhauser.com/math/questions")
            pgrsLoginBar.PerformStep()
        Catch ex As Exception
            lblServerMessage.Text = "Error retrieving questions from server."
            Exit Sub
        Finally
            pgrsLoginBar.PerformStep()
        End Try

        Try
            ' Parse JSON response into a response object
            questions = jss.Deserialize(Of data.QuestionsList)(strResponse)
            pgrsLoginBar.PerformStep()

            frmQuestions.setList(questions.questions)
            frmQuestions.Show()
            Me.Hide()
        Catch ex As Exception
            lblServerMessage.Text = "Error parsing questions JSON"
            Exit Sub
        End Try

    End Sub

    Private Sub frmLogin_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' Give the user feedback while logging in, as it can be a length process.
        ' Increment the bar after each processing point in the Login handler
        ' Maximum is a manual count of all processing points.
        pgrsLoginBar.Minimum = 0
        pgrsLoginBar.Maximum = 5
    End Sub

    ' The user submitted by hitting Enter
    Private Sub txtPassword_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            Call btnLogin_Click(Nothing, Nothing)
        End If
    End Sub
End Class
