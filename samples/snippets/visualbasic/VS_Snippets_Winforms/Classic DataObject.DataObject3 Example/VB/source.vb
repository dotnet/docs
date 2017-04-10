Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    ' <Snippet1>
    Private Sub CreateTextDataObject()
        ' Creates a new data object using a string.
        Dim myString As String = "My text string"
        Dim myDataObject As New DataObject(myString)
        
        ' Prints the string in a text box.
        textBox1.Text = myDataObject.GetData(DataFormats.Text).ToString()
    End Sub 'CreateTextDataObject
    ' </Snippet1>
End Class 'Form1 

