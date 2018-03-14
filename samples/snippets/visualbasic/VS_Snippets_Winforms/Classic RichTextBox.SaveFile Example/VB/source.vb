Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected richTextBox1 As RichTextBox
    
' <Snippet1>
    Public Sub SaveMyFile()
        ' Create a SaveFileDialog to request a path and file name to save to.
        Dim saveFile1 As New SaveFileDialog()
        
        ' Initialize the SaveFileDialog to specify the RTF extention for the file.
        saveFile1.DefaultExt = "*.rtf"
        saveFile1.Filter = "RTF Files|*.rtf"
        
        ' Determine whether the user selected a file name from the saveFileDialog.
        If (saveFile1.ShowDialog() = System.Windows.Forms.DialogResult.OK) _
            And (saveFile1.FileName.Length > 0) Then
            
            ' Save the contents of the RichTextBox into the file.
            richTextBox1.SaveFile(saveFile1.FileName)
        End If
    End Sub

' </Snippet1>
End Class

