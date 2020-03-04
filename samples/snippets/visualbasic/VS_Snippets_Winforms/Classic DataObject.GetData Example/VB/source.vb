Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    ' <Snippet1>
    Private Sub GetMyData3()
        ' Creates a new data object using a string and the text format.
        Dim myString As String = "My new text string"
        Dim myDataObject As New DataObject(DataFormats.Text, myString)
        
        ' Prints the string in a text box with autoconvert = false.
        If (myDataObject.GetData("System.String", False) IsNot Nothing) Then
            ' Prints the string in a text box.
            textBox1.Text = myDataObject.GetData("System.String", False).ToString() & ControlChars.Cr
        Else
            textBox1.Text = "Could not find data of the specified format" & ControlChars.Cr
        End If 
        ' Prints the string in a text box with autoconvert = true.
        textBox1.Text += myDataObject.GetData("System.String", True).ToString()
    End Sub
    ' </Snippet1>
End Class

