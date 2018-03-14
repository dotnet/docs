Imports System
Imports System.Windows.Forms
Imports System.Diagnostics



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    ' <Snippet1>
    Private Sub GetSpecialBuild()
        ' Get the file version for the notepad.
        Dim myFileVersionInfo As FileVersionInfo = _
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\Notepad.exe")
        
        ' Print the special build information.
        textBox1.Text = "Special build information: " & myFileVersionInfo.SpecialBuild
    End Sub 'GetSpecialBuild
    ' </Snippet1>
End Class 'Form1 

