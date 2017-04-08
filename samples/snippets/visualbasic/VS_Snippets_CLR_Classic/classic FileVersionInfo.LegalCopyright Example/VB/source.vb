Imports System
Imports System.Windows.Forms
Imports System.Diagnostics

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    ' <Snippet1>
    Private Sub GetCopyright()
        ' Get the file version for the notepad.
        Dim myFileVersionInfo As FileVersionInfo = _
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\Notepad.exe")
        
        ' Print the copyright notice.
        textBox1.Text = "Copyright notice: " & myFileVersionInfo.LegalCopyright
    End Sub 'GetCopyright
    ' </Snippet1>
End Class 'Form1 

