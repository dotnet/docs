Imports System
Imports System.Windows.Forms
Imports System.Diagnostics



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    ' <Snippet1>
    Private Sub GetIsPatched()
        ' Get the file version for the notepad.
        Dim myFileVersionInfo As FileVersionInfo = _
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\Notepad.exe")
        
        ' Print whether the file has a patch installed.
        textBox1.Text = "File has patch installed: " & myFileVersionInfo.IsPatched
    End Sub 'GetIsPatched
    ' </Snippet1>
End Class 'Form1 

