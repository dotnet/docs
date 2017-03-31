
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms


Public Class Form1
    Inherits Form
    
' <Snippet1>
    Public Sub CreateMyRichTextBox()
        Dim richTextBox1 As New RichTextBox()
        richTextBox1.Dock = DockStyle.Fill
        
        
        richTextBox1.LoadFile("C:\MyDocument.rtf")
        richTextBox1.Find("Text", RichTextBoxFinds.MatchCase)
        
        richTextBox1.SelectionFont = New Font("Verdana", 12, FontStyle.Bold)
        richTextBox1.SelectionColor = Color.Red
        
        richTextBox1.SaveFile("C:\MyDocument.rtf", RichTextBoxStreamType.RichText)
        
        Me.Controls.Add(richTextBox1)
    End Sub

' </Snippet1>
End Class

