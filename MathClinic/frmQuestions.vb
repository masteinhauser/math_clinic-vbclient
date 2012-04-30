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
        txtNumberToGenerate.Text = "5"
        For Each q As data.Question In questions
            lstQuestions.Items.Add(q.equation)
        Next
    End Sub

    Private Sub btnGenerateQuestions_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerateQuestions.Click
        Dim strQuestion As String = lstQuestions.SelectedItem.ToString
        Dim numGenerate As String = txtNumberToGenerate.Text
        Dim questionsGenerated As data.QuestionsGenerated

        lstGenerateQuestions.Items.Clear()

        questionsGenerated = buildQuestions(strQuestion, numGenerate)
        txtMaxGenerated.Text = questionsGenerated.total
        txtNumberGenerated.Text = questionsGenerated.count

        For Each strQ As String In questionsGenerated.questions
            lstGenerateQuestions.Items.Add(strQ)
        Next
    End Sub

    Private Sub btnTakeTest_Click(sender As System.Object, e As System.EventArgs) Handles btnTakeTest.Click
        Dim strQuestion As String = lstQuestions.SelectedItem.ToString
        Dim numGenerate As String = txtNumberToGenerate.Text
        Dim questionsGenerated As data.QuestionsGenerated = Nothing

        If strQuestion = String.Empty Then
            MsgBox("You must select question on the left!")
        Else
            If questionsGenerated Is Nothing Then
                questionsGenerated = buildQuestions(strQuestion, numGenerate)
            End If

            AppShared.data.QuestionDictionary.Add(New data.Question(lstQuestions.SelectedItem.ToString, Nothing, Nothing, Nothing), questionsGenerated.questions)

            frmTest.Show()
            Me.Hide()
        End If
    End Sub

    Private Function buildQuestions(strQuestion As String, strCount As String) As data.QuestionsGenerated
        Dim strQUrl As String = strQuestionsUrl.Replace(":eq", strQuestion).Replace(":count", strCount)
        Dim genQuestions As data.QuestionsGenerated

        jsonQuestions = AppShared.makeGetRequest(strQUrl)

        genQuestions = jss.Deserialize(Of data.QuestionsGenerated)(jsonQuestions)

        Return genQuestions
    End Function

    Private Sub btnAddQuestion_Click(sender As System.Object, e As System.EventArgs) Handles btnAddQuestion.Click
        Dim strQuestion As String = txtNewQuestion.Text
        Dim strUrl As String = AppShared.strBaseUrl + "test/create/" + strQuestion + "/addition/easy"

        Dim strResponse As String = AppShared.makePostRequest(strUrl, Nothing)
        Dim jsonResponse As data.CreateQuestionResponse = jss.Deserialize(Of data.CreateQuestionResponse)(strResponse)

        lstQuestions.Items.Add(jsonResponse.question.equation)
    End Sub

    Private Sub btnGenerateNew_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerateNew.Click
        Dim strQuestion As String = txtNewQuestion.Text
        Dim numGenerate As String = txtNumberToGenerate.Text
        Dim questionsGenerated As data.QuestionsGenerated

        lstGenerateQuestions.Items.Clear()

        questionsGenerated = buildQuestions(strQuestion, numGenerate)
        txtMaxGenerated.Text = questionsGenerated.total
        txtNumberGenerated.Text = questionsGenerated.count

        For Each strQ As String In questionsGenerated.questions
            lstGenerateQuestions.Items.Add(strQ)
        Next
    End Sub

    Private Sub btnDownloadQuestions_Click(sender As System.Object, e As System.EventArgs) Handles btnDownloadQuestions.Click
        For Each strQuestion As String In lstQuestions.Items
            ' "0" is used as a reserved value on the backend to return the max allowed combinations for that question.
            buildQuestions(strQuestion, "0")
        Next
    End Sub
End Class