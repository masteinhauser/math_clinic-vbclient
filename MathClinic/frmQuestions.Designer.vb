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
        Me.lstGenerateQuestions = New System.Windows.Forms.ListBox()
        Me.btnGenerateQuestions = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblNumberGenerated = New System.Windows.Forms.Label()
        Me.lblMaxGenerated = New System.Windows.Forms.Label()
        Me.txtNumberGenerated = New System.Windows.Forms.TextBox()
        Me.txtMaxGenerated = New System.Windows.Forms.TextBox()
        Me.txtNumberToGenerate = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnTakeTest = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'lstQuestions
        '
        Me.lstQuestions.FormattingEnabled = True
        Me.lstQuestions.Location = New System.Drawing.Point(13, 39)
        Me.lstQuestions.Name = "lstQuestions"
        Me.lstQuestions.Size = New System.Drawing.Size(279, 511)
        Me.lstQuestions.TabIndex = 0
        '
        'lstGenerateQuestions
        '
        Me.lstGenerateQuestions.FormattingEnabled = True
        Me.lstGenerateQuestions.Location = New System.Drawing.Point(493, 39)
        Me.lstGenerateQuestions.MultiColumn = True
        Me.lstGenerateQuestions.Name = "lstGenerateQuestions"
        Me.lstGenerateQuestions.Size = New System.Drawing.Size(279, 511)
        Me.lstGenerateQuestions.TabIndex = 1
        '
        'btnGenerateQuestions
        '
        Me.btnGenerateQuestions.Location = New System.Drawing.Point(331, 90)
        Me.btnGenerateQuestions.Name = "btnGenerateQuestions"
        Me.btnGenerateQuestions.Size = New System.Drawing.Size(116, 23)
        Me.btnGenerateQuestions.TabIndex = 2
        Me.btnGenerateQuestions.Text = "Generate Questions"
        Me.btnGenerateQuestions.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(181, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Select a Question series to generate:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(493, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(163, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Review the generated questions:"
        '
        'lblNumberGenerated
        '
        Me.lblNumberGenerated.AutoSize = True
        Me.lblNumberGenerated.Location = New System.Drawing.Point(340, 240)
        Me.lblNumberGenerated.Name = "lblNumberGenerated"
        Me.lblNumberGenerated.Size = New System.Drawing.Size(103, 13)
        Me.lblNumberGenerated.TabIndex = 5
        Me.lblNumberGenerated.Text = "Number Generated: "
        '
        'lblMaxGenerated
        '
        Me.lblMaxGenerated.AutoSize = True
        Me.lblMaxGenerated.Location = New System.Drawing.Point(333, 279)
        Me.lblMaxGenerated.Name = "lblMaxGenerated"
        Me.lblMaxGenerated.Size = New System.Drawing.Size(123, 13)
        Me.lblMaxGenerated.TabIndex = 6
        Me.lblMaxGenerated.Text = "Max Unique Generated: "
        '
        'txtNumberGenerated
        '
        Me.txtNumberGenerated.Location = New System.Drawing.Point(340, 256)
        Me.txtNumberGenerated.Name = "txtNumberGenerated"
        Me.txtNumberGenerated.Size = New System.Drawing.Size(100, 20)
        Me.txtNumberGenerated.TabIndex = 7
        '
        'txtMaxGenerated
        '
        Me.txtMaxGenerated.Location = New System.Drawing.Point(340, 295)
        Me.txtMaxGenerated.Name = "txtMaxGenerated"
        Me.txtMaxGenerated.Size = New System.Drawing.Size(100, 20)
        Me.txtMaxGenerated.TabIndex = 8
        '
        'txtNumberToGenerate
        '
        Me.txtNumberToGenerate.Location = New System.Drawing.Point(338, 55)
        Me.txtNumberToGenerate.Name = "txtNumberToGenerate"
        Me.txtNumberToGenerate.Size = New System.Drawing.Size(100, 20)
        Me.txtNumberToGenerate.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(335, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Number To Generated: "
        '
        'btnTakeTest
        '
        Me.btnTakeTest.Location = New System.Drawing.Point(354, 423)
        Me.btnTakeTest.Name = "btnTakeTest"
        Me.btnTakeTest.Size = New System.Drawing.Size(75, 23)
        Me.btnTakeTest.TabIndex = 11
        Me.btnTakeTest.Text = "Take Test"
        Me.btnTakeTest.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(298, 341)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(189, 76)
        Me.TextBox1.TabIndex = 12
        Me.TextBox1.Text = "Select a Question on the left, review the questions on the right, then Take a Tes" & _
    "t!"
        '
        'frmQuestions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.btnTakeTest)
        Me.Controls.Add(Me.txtNumberToGenerate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtMaxGenerated)
        Me.Controls.Add(Me.txtNumberGenerated)
        Me.Controls.Add(Me.lblMaxGenerated)
        Me.Controls.Add(Me.lblNumberGenerated)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnGenerateQuestions)
        Me.Controls.Add(Me.lstGenerateQuestions)
        Me.Controls.Add(Me.lstQuestions)
        Me.Name = "frmQuestions"
        Me.Text = "Questions"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstQuestions As System.Windows.Forms.ListBox
    Friend WithEvents lstGenerateQuestions As System.Windows.Forms.ListBox
    Friend WithEvents btnGenerateQuestions As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblNumberGenerated As System.Windows.Forms.Label
    Friend WithEvents lblMaxGenerated As System.Windows.Forms.Label
    Friend WithEvents txtNumberGenerated As System.Windows.Forms.TextBox
    Friend WithEvents txtMaxGenerated As System.Windows.Forms.TextBox
    Friend WithEvents txtNumberToGenerate As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnTakeTest As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
