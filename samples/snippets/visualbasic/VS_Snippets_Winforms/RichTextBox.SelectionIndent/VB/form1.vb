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
      WriteIndentedTextToRichTextBox()
   End Sub

   '<Snippet1>
   Private Sub WriteIndentedTextToRichTextBox()
      ' Clear all text from the RichTextBox;
      RichTextBox1.Clear()
      ' Set the font for the text.
      RichTextBox1.Font = New Font("Lucinda Console", 12)
      ' Specify a 20 pixel indent in all paragraphs.
      RichTextBox1.SelectionIndent = 20
      ' Set the text within the control.
      RichTextBox1.SelectedText = "All text is indented 20 pixels from the left edge of the RichTextBox."
      RichTextBox1.SelectedText = "You can use this property to provide proper indentation such as when writing a letter."
      RichTextBox1.SelectedText = "After this paragraph the indent is returned to normal spacing." + ControlChars.Crlf
      RichTextBox1.SelectionIndent = 0
      RichTextBox1.SelectedText = "No indenation is applied to this paragraph. All text in the paragraph flows from each control edge."
   End Sub
   '</Snippet1>
End Class
