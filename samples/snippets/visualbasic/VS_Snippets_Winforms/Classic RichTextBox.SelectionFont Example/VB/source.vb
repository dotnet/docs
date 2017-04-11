Imports System
Imports System.Collections
Imports System.Drawing
Imports System.Diagnostics
Imports System.Windows.Forms


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

   Friend WithEvents richTextBox1 As System.Windows.Forms.RichTextBox
   Friend WithEvents Button1 As System.Windows.Forms.Button

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.Container

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.richTextBox1 = New System.Windows.Forms.RichTextBox()
      Me.Button1 = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      '
      'richTextBox1
      '
      Me.richTextBox1.Location = New System.Drawing.Point(16, 16)
      Me.richTextBox1.Name = "richTextBox1"
      Me.richTextBox1.Size = New System.Drawing.Size(240, 24)
      Me.richTextBox1.TabIndex = 0
      Me.richTextBox1.Text = "Make me BOLD"
      '
      'Button1
      '
      Me.Button1.Location = New System.Drawing.Point(16, 56)
      Me.Button1.Name = "Button1"
      Me.Button1.Size = New System.Drawing.Size(56, 24)
      Me.Button1.TabIndex = 1
      Me.Button1.Text = "Bold"
      '
      'Form1
      '
      Me.ClientSize = New System.Drawing.Size(292, 109)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button1, Me.richTextBox1})
      Me.Name = "Form1"
      Me.Text = "Form1"
      Me.ResumeLayout(False)

   End Sub

#End Region


   Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
      ToggleBold()
   End Sub

   ' <Snippet1>
   Private Sub ToggleBold()
      If richTextBox1.SelectionFont IsNot Nothing Then
         Dim currentFont As System.Drawing.Font = richTextBox1.SelectionFont
         Dim newFontStyle As System.Drawing.FontStyle

         If richTextBox1.SelectionFont.Bold = True Then
            newFontStyle = FontStyle.Regular
         Else
            newFontStyle = FontStyle.Bold
         End If

         richTextBox1.SelectionFont = New Font( _
            currentFont.FontFamily, _
            currentFont.Size, _
            newFontStyle _
         )
      End If
   End sub
   ' </Snippet1>

   Private Sub richTextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles richTextBox1.GotFocus
      richTextBox1.SelectionStart = 8
      richTextBox1.SelectionLength = 4
   End Sub

   Public Shared Sub Main()
      Application.Run(new Form1())
   End sub
End Class
