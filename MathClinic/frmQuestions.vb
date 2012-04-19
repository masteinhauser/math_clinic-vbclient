Imports System
Imports System.IO
Imports System.Net
Imports System.Text



Public Class frmQuestions
    Dim questions As dataQuestion()

    Public Sub Questions_setList(questions As dataQuestion())
        Me.questions = questions
    End Sub

    Private Sub Questions_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        For Each q As dataQuestion In questions
            lstQuestions.Items.Add(q.equation)

            ' Write question to console
            Console.WriteLine(q.equation)
        Next
    End Sub

    Private Sub Questions_Close(sender As System.Object, e As System.EventArgs) Handles MyBase.FormClosed
        frmLogin.Close()
        frmTest.Close()
    End Sub
End Class