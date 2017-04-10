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
   Friend WithEvents textBox2 As System.Windows.Forms.TextBox
   Friend WithEvents textBox1 As System.Windows.Forms.TextBox
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.button1 = New System.Windows.Forms.Button()
      Me.textBox2 = New System.Windows.Forms.TextBox()
      Me.textBox1 = New System.Windows.Forms.TextBox()
      Me.SuspendLayout()
      '
      'button1
      '
      Me.button1.Location = New System.Drawing.Point(201, 123)
      Me.button1.Name = "button1"
      Me.button1.TabIndex = 5
      Me.button1.Text = "button1"
      '
      'textBox2
      '
      Me.textBox2.Location = New System.Drawing.Point(17, 139)
      Me.textBox2.Name = "textBox2"
      Me.textBox2.Size = New System.Drawing.Size(144, 20)
      Me.textBox2.TabIndex = 4
      Me.textBox2.Text = "textBox2"
      '
      'textBox1
      '
      Me.textBox1.Location = New System.Drawing.Point(17, 107)
      Me.textBox1.Name = "textBox1"
      Me.textBox1.Size = New System.Drawing.Size(144, 20)
      Me.textBox1.TabIndex = 3
      Me.textBox1.Text = "textBox1"
      '
      'Form1
      '
      Me.ClientSize = New System.Drawing.Size(292, 266)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.button1, Me.textBox2, Me.textBox1})
      Me.Name = "Form1"
      Me.Text = "Form1"
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click
      AppendTextBox1Text()
   End Sub

   '<Snippet1>
   Private Sub AppendTextBox1Text()
      ' Determine if text is selected in textBox1.
      If textBox1.SelectionLength = 0 Then
         ' No selection made, return.
         Return
      End If
      ' Determine if the text being appended to textBox2 exceeds the MaxLength property.
      If textBox1.SelectedText.Length + textBox2.TextLength > textBox2.MaxLength Then
         MessageBox.Show("The text to paste in is larger than the maximum number of characters allowed")
         ' Append the text from textBox1 into textBox2.
      Else
         textBox2.AppendText(textBox1.SelectedText)
      End If
   End Sub
   '</Snippet1>
End Class
