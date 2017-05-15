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
      WriteTextToRichTextBox()
   End Sub

   '<Snippet1>
   Private Sub WriteTextToRichTextBox()
      ' Clear all text from the RichTextBox;
      richTextBox1.Clear()
      ' Indent bulleted text 30 pixels away from the bullet.
      richTextBox1.BulletIndent = 30
      ' Set the font for the opening text to a larger Arial font;
      richTextBox1.SelectionFont = New Font("Arial", 16)
      ' Assign the introduction text to the RichTextBox control.
      RichTextBox1.SelectedText = "The following is a list of bulleted items:" + ControlChars.Cr
      ' Set the Font for the first item to a smaller size Arial font.
      richTextBox1.SelectionFont = New Font("Arial", 12)
      ' Specify that the following items are to be added to a bulleted list.
      richTextBox1.SelectionBullet = True
      ' Set the color of the item text.
      richTextBox1.SelectionColor = Color.Red
      ' Assign the text to the bulleted item.
      richTextBox1.SelectedText = "Apples" + ControlChars.Cr
      ' Apply same font since font settings do not carry to next line.
      richTextBox1.SelectionFont = New Font("Arial", 12)
      richTextBox1.SelectionColor = Color.Orange
      richTextBox1.SelectedText = "Oranges" + ControlChars.Cr
      richTextBox1.SelectionFont = New Font("Arial", 12)
      richTextBox1.SelectionColor = Color.Purple
      richTextBox1.SelectedText = "Grapes" + ControlChars.Cr
      ' End the bulleted list.
      richTextBox1.SelectionBullet = False
      ' Specify the font size and string for text displayed below bulleted list.
      richTextBox1.SelectionFont = New Font("Verdana", 10)
      richTextBox1.SelectedText = "The bulleted text is indented 30 pixels from the bullet symbol using the BulletIndent property." + ControlChars.Cr
   End Sub
   '</Snippet1>
End Class
