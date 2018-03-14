Imports System
Imports System.IO
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
' <Snippet1>
 Private Sub CreateMyFormat2()
     Dim myFormat As New DataFormats.Format("AnotherNewFormat", 20916)
        
     ' Displays the contents of myFormat.
     textBox1.Text = "ID value: " + myFormat.Id.ToString() + ControlChars.Cr _
                   + "Format name: " + myFormat.Name
 End Sub
 
' </Snippet1>
End Class

