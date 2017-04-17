Imports System
Imports System.Windows.Forms
Imports System.Diagnostics



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    ' <Snippet1>
    Private Sub GetIsPrivateBuild()
        ' Get the file version for the notepad.
        Dim myFileVersionInfo As FileVersionInfo = _
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\Notepad.exe")
        
        ' Print whether the version is a private build.
        textBox1.Text = "Version is a private build: " & myFileVersionInfo.IsPrivateBuild
    End Sub 'GetIsPrivateBuild
    ' </Snippet1>
End Class 'Form1 

