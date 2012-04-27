Public Class frmTest
    Dim questions As data.Question()

    
    Private Sub frmTest_Close(sender As System.Object, e As System.EventArgs) Handles MyBase.FormClosed
        AppShared.close()
    End Sub
End Class