' Myles A. K. Steinhauser

Option Strict On
Option Explicit On

Imports System.Web.Script.Serialization

Public Class frmMenu

    Private Sub frmMenu_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadQuestions()
    End Sub

    Private Sub LoadQuestions()
        Dim strResponse As String = String.Empty
        Dim questions As data.QuestionsList
        Dim jss As JavaScriptSerializer = New JavaScriptSerializer()

        Try
            ' Fire the request and get the response
            strResponse = AppShared.makeGetRequest(AppShared.strBaseUrl + "questions")
        Catch ex As Exception
            Console.WriteLine("Error retrieving questions from server.")
            Exit Sub
        End Try

        Try
            ' Parse JSON response into a response object
            questions = jss.Deserialize(Of data.QuestionsList)(strResponse)

            ' Pass the questions on if they decide to view the questions list
            frmQuestions.setList(questions.questions)

        Catch ex As Exception
            Console.WriteLine("Error parsing questions JSON")
            Exit Sub
        End Try
    End Sub

    Private Sub frmMenu_Close(sender As System.Object, e As System.EventArgs) Handles MyBase.FormClosed
        AppShared.close()
    End Sub

    Private Sub btnQuestions_Click(sender As System.Object, e As System.EventArgs) Handles btnQuestions.Click
        frmQuestions.Show()
    End Sub

    Private Sub btnTest_Click(sender As System.Object, e As System.EventArgs) Handles btnTest.Click
        frmTest.Show()
    End Sub

    Private Sub btnSettings_Click(sender As System.Object, e As System.EventArgs) Handles btnSettings.Click
        frmSettings.Show()
    End Sub
End Class