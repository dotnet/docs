Imports System
Imports System.Windows.Forms
Imports System.Diagnostics

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    ' <Snippet1>
    Private Sub GetFileBuildPart()
        ' Get the file version for the notepad.
        Dim myFileVersionInfo As FileVersionInfo = _
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\Notepad.exe")
        
        ' Print the file build number.
        textBox1.Text = "File build number: " & myFileVersionInfo.FileBuildPart
    End Sub 'GetFileBuildPart
    ' </Snippet1>
End Class 'Form1 
