Imports System
Imports System.Windows.Forms
Imports System.Diagnostics



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    ' <Snippet1>
    Private Sub GetOriginalName()
        ' Get the file version for the notepad.
        Dim myFileVersionInfo As FileVersionInfo = _
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\Notepad.exe")
        
        ' Print the original file name.
        textBox1.Text = "Original file name: " & myFileVersionInfo.OriginalFilename
    End Sub 'GetOriginalName
    ' </Snippet1>
End Class 'Form1 
