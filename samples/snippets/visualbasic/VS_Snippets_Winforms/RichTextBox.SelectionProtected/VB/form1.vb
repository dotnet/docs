Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If (components IsNot Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
   Friend WithEvents button1 As System.Windows.Forms.Button
   Friend WithEvents richTextBox1 As System.Windows.Forms.RichTextBox
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.button1 = New System.Windows.Forms.Button()
      Me.richTextBox1 = New System.Windows.Forms.RichTextBox()
      Me.SuspendLayout()
      '
      'button1
      '
      Me.button1.Location = New System.Drawing.Point(339, 143)
      Me.button1.Name = "button1"
      Me.button1.TabIndex = 5
      Me.button1.Text = "button1"
      '
      'richTextBox1
      '
      Me.richTextBox1.Location = New System.Drawing.Point(27, 95)
      Me.richTextBox1.Name = "richTextBox1"
      Me.richTextBox1.Size = New System.Drawing.Size(296, 168)
      Me.richTextBox1.TabIndex = 4
      Me.richTextBox1.Text = "richTextBox1"
      '
      'Form1
      '
      Me.ClientSize = New System.Drawing.Size(440, 358)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.button1, Me.richTextBox1})
      Me.Name = "Form1"
      Me.Text = "Form1"
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub richTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles richTextBox1.TextChanged

   End Sub
   Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click
      richTextBox1.Clear()
      richTextBox1.AppendText("This text is being added to the RichTextBox control to protect")
      ProtectMySelectedText()
   End Sub

   '<Snippet1>
   Private Sub ProtectMySelectedText()
      ' Determine if the selected text in the control contains the word "RichTextBox".
      If richTextBox1.SelectedText <> "RichTextBox" Then
         ' Search for the word RichTextBox in the control.
         If richTextBox1.Find("RichTextBox", RichTextBoxFinds.WholeWord) = -1 Then
            'Alert the user that the word was not foun and return.
            MessageBox.Show("The text ""RichTextBox"" was not found!")
            Return
         End If
      End If
      ' Protect the selected text in the control from being altered.
      richTextBox1.SelectionProtected = True
   End Sub
   '</Snippet1>
End Class
