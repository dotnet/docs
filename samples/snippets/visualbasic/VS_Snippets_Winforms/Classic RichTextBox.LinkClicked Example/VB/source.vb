

Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms



Public Class Form1
   Inherits Form
   Private richTextBox1 As New RichTextBox()
   
   
   Public Sub New()
      AddHandler richTextBox1.LinkClicked, AddressOf Me.Link_Clicked
      
      richTextBox1.SelectedText = "To see Microsoft go to www.microsoft.com"
      richTextBox1.Location = New System.Drawing.Point(10, 10)
      richTextBox1.Size = New System.Drawing.Size(100, 100)
      
      Me.Controls.Add(richTextBox1)
   End Sub 'New
   
   ' <Snippet1>
   Private Sub Link_Clicked(sender As Object, e As System.Windows.Forms.LinkClickedEventArgs)
      System.Diagnostics.Process.Start(e.LinkText)
   End Sub 'Link_Clicked
   ' </Snippet1>

   '/ <summary>
   '/ The main entry point for the application.
   '/ </summary>
   <STAThread()>  _
   Shared Sub Main()
      Application.Run(New Form1())
   End Sub 'Main
End Class 'Form1 
