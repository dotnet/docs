Imports System
Imports System.Windows.Forms
Imports System.Diagnostics



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    ' <Snippet1>
    Private Sub GetProductPrivatePart()
        ' Get the file version for the notepad.
        Dim myFileVersionInfo As FileVersionInfo = _
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\Notepad.exe")
        
        ' Print the product private part number.
        textBox1.Text = "Product private part number: " & myFileVersionInfo.ProductPrivatePart
    End Sub 'GetProductPrivatePart
    ' </Snippet1>
End Class 'Form1 

