Imports System
Imports System.IO
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
' <Snippet1>
 Private Sub GetMyFormatInfomation()
     ' Creates a DataFormats.Format for the Unicode data format.
     Dim myFormat As DataFormats.Format = _
        DataFormats.GetFormat(DataFormats.UnicodeText)
        
     ' Displays the contents of myFormat.
     textBox1.Text = "ID value: " + myFormat.Id.ToString() + ControlChars.Cr _
                   + "Format name: " + myFormat.Name
 End Sub

' </Snippet1>
End Class


