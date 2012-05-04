' Myles A. K. Steinhauser

Option Strict On
Option Explicit On

Imports System.Web.Script.Serialization

Public Class frmMenu

    Private Sub frmMenu_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        frmQuestions.LoadQuestions()
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