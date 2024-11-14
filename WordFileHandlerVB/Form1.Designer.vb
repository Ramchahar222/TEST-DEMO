<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Me.btnUpload = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.rtbDocument = New System.Windows.Forms.RichTextBox()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.AxEDOffice1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.SuspendLayout()
        '
        'btnUpload
        '
        Me.btnUpload.Location = New System.Drawing.Point(12, 54)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(75, 23)
        Me.btnUpload.TabIndex = 0
        Me.btnUpload.Text = "Upload"
        Me.btnUpload.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(700, 57)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(155, 23)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog"
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(192, 59)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(192, 20)
        Me.txtFileName.TabIndex = 2
        '
        'rtbDocument
        '
        Me.rtbDocument.Location = New System.Drawing.Point(4, 175)
        Me.rtbDocument.Name = "rtbDocument"
        Me.rtbDocument.Size = New System.Drawing.Size(1062, 224)
        Me.rtbDocument.TabIndex = 3
        Me.rtbDocument.Text = ""
        '
        'btnsave
        '
        Me.btnsave.Location = New System.Drawing.Point(1071, 59)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(183, 23)
        Me.btnsave.TabIndex = 4
        Me.btnsave.Text = "Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'AxEDOffice1
        '
        Me.AxEDOffice1.Text = "NotifyIcon1"
        Me.AxEDOffice1.Visible = True
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1370, 579)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.rtbDocument)
        Me.Controls.Add(Me.txtFileName)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnUpload)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnUpload As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents OpenFileDialog As OpenFileDialog
    Friend WithEvents txtFileName As TextBox
    Friend WithEvents rtbDocument As RichTextBox
    Friend WithEvents btnsave As Button
    Friend WithEvents AxEDOffice1 As NotifyIcon
    Friend WithEvents NotifyIcon1 As NotifyIcon
End Class
