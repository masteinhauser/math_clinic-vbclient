Option Strict On
Option Explicit On

Imports System
Imports System.IO
Imports System.Net
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Text

Public Class frmQuestions

    Dim strQuestionsUrl As String = AppShared.strBaseUrl + "questions/:eq/:count"
    Dim questions As data.Question()
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
        Dim strQuestion As String = lstQuestions.SelectedItem.ToString
        Dim numGenerate As String = txtNumberToGenerate.Text
        Dim questionsGenerated As data.QuestionsGenerated

        lstGenerateQuestions.Items.Clear()

        questionsGenerated = buildQuestions(strQuestion, numGenerate)
        For Each strQ As String In questionsGenerated.questions
            lstGenerateQuestions.Items.Add(strQ)
        Next
    End Sub

    Private Sub btnTakeTest_Click(sender As System.Object, e As System.EventArgs) Handles btnTakeTest.Click
        Dim strQuestion As String = lstQuestions.SelectedItem.ToString
        Dim numGenerate As String = txtNumberToGenerate.Text
        Dim questionsGenerated As data.QuestionsGenerated = Nothing

        If questionsGenerated Is Nothing Then
            questionsGenerated = buildQuestions(strQuestion, numGenerate)
        End If

        AppShared.data.QuestionDictionary.Add(New data.Question(lstQuestions.SelectedItem.ToString, Nothing, Nothing, Nothing), questionsGenerated.questions)

        frmTest.Show()
        Me.Hide()
    End Sub

    Private Function buildQuestions(strQuestion As String, strCount As String) As data.QuestionsGenerated
        Dim strQUrl As String = strQuestionsUrl.Replace(":eq", strQuestion).Replace(":count", strCount)
        Dim genQuestions As data.QuestionsGenerated

        jsonQuestions = AppShared.makeGetRequest(strQUrl)

        genQuestions = jss.Deserialize(Of data.QuestionsGenerated)(jsonQuestions)

        Return genQuestions
    End Function
End Class