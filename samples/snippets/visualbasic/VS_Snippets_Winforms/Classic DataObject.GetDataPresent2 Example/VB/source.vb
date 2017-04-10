Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    ' <Snippet1>
    Private Sub GetIfPresent()
        ' Creates a new data object using a string and the text format.
        Dim myDataObject As New DataObject(DataFormats.Text, "A new string")
        
        ' Prints whether data is present in text format.
        textBox1.Text = "Data in text format is: " & _
            myDataObject.GetDataPresent(DataFormats.Text).ToString()
    End Sub 'GetIfPresent
    ' </Snippet1>
End Class 'Form1


