Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    ' <Snippet1>
    Private Sub GetAllFormats()
        ' Creates a new data object using a string and the text format.
        Dim myDataObject As New DataObject(DataFormats.Text, "Another string")
        
        ' Gets all the data formats and data conversion formats in the DataObject.
        Dim arrayOfFormats As String() = myDataObject.GetFormats()
        
        ' Prints the results.
        textBox1.Text = "The format(s) associated with the data are: " & ControlChars.Cr
        Dim i As Integer
        For i = 0 To arrayOfFormats.Length - 1
            textBox1.Text += arrayOfFormats(i) & ControlChars.Cr
        Next i
    End Sub 'GetAllFormats 
    ' </Snippet1>
End Class 'Form1 
