Imports System
Imports System.Windows.Forms
Imports System.Diagnostics



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    ' <Snippet1>
    Private Sub GetIsPreRelease()
        ' Get the file version for the notepad.
        Dim myFileVersionInfo As FileVersionInfo = _
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\Notepad.exe")
        
        ' Print whether the file is a prerelease version.
        textBox1.Text = "File is prerelease version " & myFileVersionInfo.IsPreRelease
    End Sub 'GetIsPreRelease
    ' </Snippet1>
End Class 'Form1 

