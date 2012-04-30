<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMenu
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
        Me.btnQuestions = New System.Windows.Forms.Button()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.lblWelcome = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnQuestions
        '
        Me.btnQuestions.Location = New System.Drawing.Point(12, 227)
        Me.btnQuestions.Name = "btnQuestions"
        Me.btnQuestions.Size = New System.Drawing.Size(75, 23)
        Me.btnQuestions.TabIndex = 0
        Me.btnQuestions.Text = "Questions"
        Me.btnQuestions.UseVisualStyleBackColor = True
        '
        'btnSettings
        '
        Me.btnSettings.Location = New System.Drawing.Point(197, 227)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(75, 23)
        Me.btnSettings.TabIndex = 1
        Me.btnSettings.Text = "Settings"
        Me.btnSettings.UseVisualStyleBackColor = True
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(106, 227)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(75, 23)
        Me.btnTest.TabIndex = 2
        Me.btnTest.Text = "Take Test"
        Me.btnTest.UseVisualStyleBackColor = True
        '
        'lblWelcome
        '
        Me.lblWelcome.AutoSize = True
        Me.lblWelcome.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWelcome.Location = New System.Drawing.Point(13, 13)
        Me.lblWelcome.Name = "lblWelcome"
        Me.lblWelcome.Size = New System.Drawing.Size(248, 26)
        Me.lblWelcome.TabIndex = 3
        Me.lblWelcome.Text = "Welcome to Math Clinic!"
        '
        'frmMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.lblWelcome)
        Me.Controls.Add(Me.btnTest)
        Me.Controls.Add(Me.btnSettings)
        Me.Controls.Add(Me.btnQuestions)
        Me.Name = "frmMenu"
        Me.Text = "Menu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnQuestions As System.Windows.Forms.Button
    Friend WithEvents btnSettings As System.Windows.Forms.Button
    Friend WithEvents btnTest As System.Windows.Forms.Button
    Friend WithEvents lblWelcome As System.Windows.Forms.Label
End Class
