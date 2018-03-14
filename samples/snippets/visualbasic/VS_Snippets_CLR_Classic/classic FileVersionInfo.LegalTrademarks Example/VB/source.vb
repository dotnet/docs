Imports System
Imports System.Windows.Forms
Imports System.Diagnostics



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    ' <Snippet1>
    Private Sub GetTrademarks()
        ' Get the file version for the notepad.
        Dim myFileVersionInfo As FileVersionInfo = _
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\Notepad.exe")
        
        ' Print the trademarks.
        textBox1.Text = "Trademarks: " & myFileVersionInfo.LegalTrademarks
    End Sub 'GetTrademarks
    ' </Snippet1>
End Class 'Form1 

