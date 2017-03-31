Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    ' <Snippet1>
    Private Sub CreateDefaultDataObject()
        ' Creates a data object.
        Dim myDataObject As DataObject
        
        ' Assigns the string to the data object.
        Dim myString As String = "My text string"
        myDataObject = New DataObject(myString)
        
        ' Prints the string in a text box.
        textBox1.Text = myDataObject.GetData(DataFormats.Text).ToString()
    End Sub 'CreateDefaultDataObject
    ' </Snippet1>
End Class 'Form1 

