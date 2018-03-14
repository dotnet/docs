Imports System
Imports System.Windows.Forms
Imports System.Diagnostics

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    ' <Snippet1>
    Private Sub GetFileDescription()
        ' Get the file version for the notepad.
        Dim myFileVersionInfo As FileVersionInfo = _
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\Notepad.exe")
        
        ' Print the file description.
        textBox1.Text = "File description: " & myFileVersionInfo.FileDescription
    End Sub 'GetFileDescription
    ' </Snippet1>
End Class 'Form1 

