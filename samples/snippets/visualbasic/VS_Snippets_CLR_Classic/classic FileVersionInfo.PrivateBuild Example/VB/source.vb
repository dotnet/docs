Imports System
Imports System.Windows.Forms
Imports System.Diagnostics



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    ' <Snippet1>
    Private Sub GetPrivateBuild()
        ' Get the file version for the notepad.
        Dim myFileVersionInfo As FileVersionInfo = _
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\Notepad.exe")
        
        ' Print the private build number.
        textBox1.Text = "Private build number: " & myFileVersionInfo.PrivateBuild
    End Sub 'GetPrivateBuild
    ' </Snippet1>
End Class 'Form1 

