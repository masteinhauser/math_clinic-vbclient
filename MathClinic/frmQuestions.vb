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

    Dim jss As JavaScriptSerializer = New JavaScriptSerializer()

    Dim jsonQuestions As String
    Dim qs As data.QuestionsList

    Public Sub setList(questions As data.Question())
        Me.questions = questions
    End Sub

    Private Sub frmQuestions_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        For Each q As data.Question In questions
            lstQuestions.Items.Add(q.equation)
        Next
    End Sub

    Private Sub frmQuestions_Close(sender As System.Object, e As System.EventArgs) Handles MyBase.FormClosed
        AppShared.close()
    End Sub

    Private Sub btnGenerateQuestions_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerateQuestions.Click
        Dim numGenerate As String = txtNumberToGenerate.Text
        
    End Sub

    Private Sub btnTakeTest_Click(sender As System.Object, e As System.EventArgs) Handles btnTakeTest.Click
        If questionsGenerated Is Nothing Then

        Else
            AppShared.data.QuestionDictionary.Add(New data.Question(lstQuestions.SelectedItem.ToString, Nothing, Nothing, Nothing), questionsGenerated.questions)
        End If

        frmTest.Show()
        Me.Hide()
    End Sub

    Private Function buildQuestions() As data.QuestionsGenerated
        Dim genQuestions As data.QuestionsGenerated



        Return genQuestions
    End Function
End Class