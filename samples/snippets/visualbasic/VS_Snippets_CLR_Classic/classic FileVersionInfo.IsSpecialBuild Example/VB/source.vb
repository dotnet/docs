Imports System
Imports System.Windows.Forms
Imports System.Diagnostics



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    ' <Snippet1>
    Private Sub GetIsSpecialBuild()
        ' Get the file version for the notepad.
        Dim myFileVersionInfo As FileVersionInfo = _
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\Notepad.exe")
        
        ' Print whether the file is a special build.
        textBox1.Text = "File is a special build: " & myFileVersionInfo.IsSpecialBuild
    End Sub 'GetIsSpecialBuild
    ' </Snippet1>
End Class 'Form1 

