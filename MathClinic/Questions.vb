Imports System
Imports System.IO
Imports System.Net
Imports System.Text



Public Class Questions
    Dim questions As String()

    Public Sub Questions_setList(questions As String())
        Me.questions = questions
    End Sub

    Private Sub Questions_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' Write response to console
        Console.WriteLine(questions)
    End Sub

    Private Sub Questions_Close(sender As System.Object, e As System.EventArgs) Handles MyBase.FormClosed
        Login.Close()
        Test.Close()
    End Sub
End Class