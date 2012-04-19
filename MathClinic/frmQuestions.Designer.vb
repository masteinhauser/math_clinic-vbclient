<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuestions
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lstQuestions = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'lstQuestions
        '
        Me.lstQuestions.FormattingEnabled = True
        Me.lstQuestions.Location = New System.Drawing.Point(13, 13)
        Me.lstQuestions.Name = "lstQuestions"
        Me.lstQuestions.Size = New System.Drawing.Size(279, 537)
        Me.lstQuestions.TabIndex = 0
        '
        'Questions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.lstQuestions)
        Me.Name = "Questions"
        Me.Text = "Questions"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstQuestions As System.Windows.Forms.ListBox
End Class
