<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDatabasePath = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkOfflineMode = New System.Windows.Forms.CheckBox()
        Me.btnSaveSettings = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Allow Offline Mode:"
        '
        'txtDatabasePath
        '
        Me.txtDatabasePath.Location = New System.Drawing.Point(111, 29)
        Me.txtDatabasePath.Name = "txtDatabasePath"
        Me.txtDatabasePath.Size = New System.Drawing.Size(161, 20)
        Me.txtDatabasePath.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Path to Database:"
        '
        'chkOfflineMode
        '
        Me.chkOfflineMode.AutoSize = True
        Me.chkOfflineMode.Location = New System.Drawing.Point(111, 9)
        Me.chkOfflineMode.Name = "chkOfflineMode"
        Me.chkOfflineMode.Size = New System.Drawing.Size(15, 14)
        Me.chkOfflineMode.TabIndex = 3
        Me.chkOfflineMode.UseVisualStyleBackColor = True
        '
        'btnSaveSettings
        '
        Me.btnSaveSettings.Location = New System.Drawing.Point(15, 227)
        Me.btnSaveSettings.Name = "btnSaveSettings"
        Me.btnSaveSettings.Size = New System.Drawing.Size(90, 23)
        Me.btnSaveSettings.TabIndex = 4
        Me.btnSaveSettings.Text = "Save Settings"
        Me.btnSaveSettings.UseVisualStyleBackColor = True
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.btnSaveSettings)
        Me.Controls.Add(Me.chkOfflineMode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDatabasePath)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmSettings"
        Me.Text = "Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDatabasePath As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkOfflineMode As System.Windows.Forms.CheckBox
    Friend WithEvents btnSaveSettings As System.Windows.Forms.Button
End Class
