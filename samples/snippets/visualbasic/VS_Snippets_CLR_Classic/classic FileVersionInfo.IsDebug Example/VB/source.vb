Imports System
Imports System.Windows.Forms
Imports System.Diagnostics



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    ' <Snippet1>
    Private Sub GetIsDebug()
        ' Get the file version for the notepad.
        Dim myFileVersionInfo As FileVersionInfo = _
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\Notepad.exe")
        
        ' Print whether the file contains debugging information.
        textBox1.Text = "File contains debugging information: " & myFileVersionInfo.IsDebug
    End Sub 'GetIsDebug
    ' </Snippet1>
End Class 'Form1
