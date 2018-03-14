Imports System
Imports System.Windows.Forms
Imports System.Diagnostics

Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    ' <Snippet1>
    Sub GetComments()
        ' Get the file version for the notepad.
        Dim myFileVersionInfo As FileVersionInfo = _
           FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\Notepad.exe")

        ' Print the comments in a text box.
        textBox1.Text = "Comments: " & myFileVersionInfo.Comments
    End Sub 'GetComments
    ' </Snippet1>
End Class 'Form1 
