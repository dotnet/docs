Imports System
Imports System.Windows.Forms
Imports System.Diagnostics



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    ' <Snippet1>
    Private Sub GetInternalName()
        ' Get the file version for the notepad.
        Dim myFileVersionInfo As FileVersionInfo = _
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\Notepad.exe")
        
        ' Print the internal name.
        textBox1.Text = "Internal name: " & myFileVersionInfo.InternalName
    End Sub 'GetInternalName
    ' </Snippet1>
End Class 'Form1 

