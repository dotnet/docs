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
   Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
   Friend WithEvents Button1 As System.Windows.Forms.Button
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
      Me.Button1 = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      '
      'RichTextBox1
      '
      Me.RichTextBox1.Location = New System.Drawing.Point(16, 16)
      Me.RichTextBox1.Name = "RichTextBox1"
      Me.RichTextBox1.Size = New System.Drawing.Size(264, 192)
      Me.RichTextBox1.TabIndex = 0
      Me.RichTextBox1.Text = "RichTextBox1"
      '
      'Button1
      '
      Me.Button1.Location = New System.Drawing.Point(208, 216)
      Me.Button1.Name = "Button1"
      Me.Button1.TabIndex = 1
      Me.Button1.Text = "Button1"
      '
      'Form1
      '
      Me.ClientSize = New System.Drawing.Size(292, 266)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button1, Me.RichTextBox1})
      Me.Name = "Form1"
      Me.Text = "Form1"
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
      WriteOffsetTextToRichTextBox()
   End Sub

   '<Snippet1>
   Private Sub WriteOffsetTextToRichTextBox()
      ' Clear all text from the RichTextBox.
      RichTextBox1.Clear()
      ' Set the font for the text.
      RichTextBox1.SelectionFont = New Font("Lucinda Console", 12)
      ' Set the foreground color of the text.
      RichTextBox1.SelectionColor = Color.Purple
      ' Set the baseline text.
      RichTextBox1.SelectedText = "10"
      ' Set the CharOffset to display superscript text.
      RichTextBox1.SelectionCharOffset = 10
      ' Set the superscripted text.	
      RichTextBox1.SelectedText = "2"
      ' Reset the CharOffset to display text at the baseline.
      RichTextBox1.SelectionCharOffset = 0
      RichTextBox1.SelectedText = ControlChars.CrLf + ControlChars.CrLf
      ' Change the forecolor of the next text selection.
      RichTextBox1.SelectionColor = Color.Blue
      ' Set the baseline text.
      RichTextBox1.SelectedText = "777"
      ' Set the CharOffset to display subscript text.
      RichTextBox1.SelectionCharOffset = -10
      ' Set the subscripted text.  
      RichTextBox1.SelectedText = "3"
      ' Reset the CharOffset to display text at the baseline.
      RichTextBox1.SelectionCharOffset = 0
   End Sub
   '</Snippet1>
End Class
