Imports System
Imports System.Windows.Forms
Imports System.Diagnostics

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    ' <Snippet1>
    Private Sub GetFileMajorPart()
        ' Get the file version for the notepad.
        Dim myFileVersionInfo As FileVersionInfo = _
            FileVersionInfo.GetVersionInfo("%systemroot%\Notepad.exe")
        
        ' Print the file major part number.
        textBox1.Text = "File major part number: " & myFileVersionInfo.FileMajorPart
    End Sub 'GetFileMajorPart
    ' </Snippet1>
End Class 'Form1 

