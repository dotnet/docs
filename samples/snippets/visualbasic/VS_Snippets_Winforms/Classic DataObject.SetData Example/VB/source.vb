Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic


Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    ' <Snippet1>
    Private Sub AddMyData4()
        ' Creates a new data object, and assigns it the component.
        Dim myDataObject As New DataObject()
        
        ' Adds data to the DataObject, and specifies no format conversion.
        myDataObject.SetData(DataFormats.UnicodeText, False, "My Unicode data")
        
        ' Gets the data formats in the DataObject.
        Dim arrayOfFormats As String() = myDataObject.GetFormats()
        
        ' Prints the results.
        textBox1.Text = "The format(s) associated with the data are: " & ControlChars.Cr
        Dim i As Integer
        For i = 0 To arrayOfFormats.Length - 1
            textBox1.Text += arrayOfFormats(i) & ControlChars.Cr
        Next i
    End Sub 'AddMyData4 
    ' </Snippet1>
End Class 'Form1 
