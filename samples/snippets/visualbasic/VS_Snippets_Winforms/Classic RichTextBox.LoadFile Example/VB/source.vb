Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected richTextBox1 As RichTextBox
    
' <Snippet1>
    Public Sub LoadMyFile()
        ' Create an OpenFileDialog to request a file to open.
        Dim openFile1 As New OpenFileDialog()
        
        ' Initialize the OpenFileDialog to look for RTF files.
        openFile1.DefaultExt = "*.rtf"
        openFile1.Filter = "RTF Files|*.rtf"
        
        ' Determine whether the user selected a file from the OpenFileDialog.
        If (openFile1.ShowDialog() = System.Windows.Forms.DialogResult.OK) _
            And (openFile1.FileName.Length > 0) Then
            
            ' Load the contents of the file into the RichTextBox.
            richTextBox1.LoadFile(openFile1.FileName)
        End If
    End Sub

' </Snippet1>
End Class

