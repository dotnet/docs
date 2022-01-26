<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.buttonEncryptFile = New System.Windows.Forms.Button
        Me.buttonDecryptFile = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.buttonImportPublicKey = New System.Windows.Forms.Button
        Me.buttonExportPublicKey = New System.Windows.Forms.Button
        Me.buttonGetPrivateKey = New System.Windows.Forms.Button
        Me.buttonCreateAsmKeys = New System.Windows.Forms.Button
        Me.closeButton = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me._encryptOpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me._decryptOpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'buttonEncryptFile
        '
        Me.buttonEncryptFile.Location = New System.Drawing.Point(28, 19)
        Me.buttonEncryptFile.Name = "buttonEncryptFile"
        Me.buttonEncryptFile.Size = New System.Drawing.Size(101, 23)
        Me.buttonEncryptFile.TabIndex = 0
        Me.buttonEncryptFile.Text = "Encrypt File"
        Me.buttonEncryptFile.UseVisualStyleBackColor = True
        '
        'buttonDecryptFile
        '
        Me.buttonDecryptFile.Location = New System.Drawing.Point(28, 48)
        Me.buttonDecryptFile.Name = "buttonDecryptFile"
        Me.buttonDecryptFile.Size = New System.Drawing.Size(101, 23)
        Me.buttonDecryptFile.TabIndex = 1
        Me.buttonDecryptFile.Text = "Decrypt File"
        Me.buttonDecryptFile.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.buttonEncryptFile)
        Me.GroupBox1.Controls.Add(Me.buttonDecryptFile)
        Me.GroupBox1.Location = New System.Drawing.Point(30, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(166, 85)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Encryption"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.buttonImportPublicKey)
        Me.GroupBox2.Controls.Add(Me.buttonExportPublicKey)
        Me.GroupBox2.Controls.Add(Me.buttonGetPrivateKey)
        Me.GroupBox2.Controls.Add(Me.buttonCreateAsmKeys)
        Me.GroupBox2.Location = New System.Drawing.Point(30, 103)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(166, 145)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Asymmetric Keys"
        '
        'buttonImportPublicKey
        '
        Me.buttonImportPublicKey.Location = New System.Drawing.Point(28, 77)
        Me.buttonImportPublicKey.Name = "buttonImportPublicKey"
        Me.buttonImportPublicKey.Size = New System.Drawing.Size(101, 23)
        Me.buttonImportPublicKey.TabIndex = 3
        Me.buttonImportPublicKey.Text = "Import Public Key"
        Me.buttonImportPublicKey.UseVisualStyleBackColor = True
        '
        'buttonExportPublicKey
        '
        Me.buttonExportPublicKey.Location = New System.Drawing.Point(28, 48)
        Me.buttonExportPublicKey.Name = "buttonExportPublicKey"
        Me.buttonExportPublicKey.Size = New System.Drawing.Size(101, 23)
        Me.buttonExportPublicKey.TabIndex = 2
        Me.buttonExportPublicKey.Text = "Export Public Key"
        Me.buttonExportPublicKey.UseVisualStyleBackColor = True
        '
        'buttonGetPrivateKey
        '
        Me.buttonGetPrivateKey.Location = New System.Drawing.Point(28, 106)
        Me.buttonGetPrivateKey.Name = "buttonGetPrivateKey"
        Me.buttonGetPrivateKey.Size = New System.Drawing.Size(101, 23)
        Me.buttonGetPrivateKey.TabIndex = 1
        Me.buttonGetPrivateKey.Text = "Get Private Key"
        Me.buttonGetPrivateKey.UseVisualStyleBackColor = True
        '
        'buttonCreateAsmKeys
        '
        Me.buttonCreateAsmKeys.Location = New System.Drawing.Point(28, 19)
        Me.buttonCreateAsmKeys.Name = "buttonCreateAsmKeys"
        Me.buttonCreateAsmKeys.Size = New System.Drawing.Size(101, 23)
        Me.buttonCreateAsmKeys.TabIndex = 0
        Me.buttonCreateAsmKeys.Text = "Create Keys"
        Me.buttonCreateAsmKeys.UseVisualStyleBackColor = True
        '
        'closeButton
        '
        Me.closeButton.Location = New System.Drawing.Point(137, 302)
        Me.closeButton.Name = "closeButton"
        Me.closeButton.Size = New System.Drawing.Size(75, 23)
        Me.closeButton.TabIndex = 4
        Me.closeButton.Text = "Close"
        Me.closeButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 264)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Key not set"
        '
        'OpenFileDialog1
        '
        Me._encryptOpenFileDialog.FileName = "OpenFileDialog1"
        '
        'OpenFileDialog2
        '
        Me._decryptOpenFileDialog.FileName = "OpenFileDialog2"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(224, 337)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.closeButton)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Form1"
        Me.Text = "Crypto WalkThru"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents buttonEncryptFile As System.Windows.Forms.Button
    Friend WithEvents buttonDecryptFile As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents buttonImportPublicKey As System.Windows.Forms.Button
    Friend WithEvents buttonExportPublicKey As System.Windows.Forms.Button
    Friend WithEvents buttonGetPrivateKey As System.Windows.Forms.Button
    Friend WithEvents buttonCreateAsmKeys As System.Windows.Forms.Button
    Friend WithEvents closeButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents _encryptOpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents _decryptOpenFileDialog As System.Windows.Forms.OpenFileDialog

End Class
