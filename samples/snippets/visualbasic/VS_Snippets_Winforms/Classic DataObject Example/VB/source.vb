Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    ' <Snippet1>
    Private Sub AddMyData3()
        ' Creates a component to store in the data object.
        Dim myComponent As New Component()
        
        ' Creates a new data object.
        Dim myDataObject As New DataObject()
        
        ' Adds the component to the DataObject.
        myDataObject.SetData(myComponent)
        
        ' Prints whether data of the specified type is in the DataObject.
        Dim myType As Type = myComponent.GetType()
        If myDataObject.GetDataPresent(myType) Then
            textBox1.Text = "Data of type " & myType.ToString() & _
                " is present in the DataObject"
        Else
            textBox1.Text = "Data of type " & myType.ToString() & _
                " is not present in the DataObject"
        End If
    End Sub 'AddMyData3
    
    ' </Snippet1>
    ' <Snippet2>
    Private Sub GetMyData2()
        ' Creates a new data object using a string and the text format.
        Dim myDataObject As New DataObject(DataFormats.Text, "Text to Store")
        
        ' Prints the string in a text box.
        textBox1.Text = myDataObject.GetData(DataFormats.Text).ToString()
    End Sub 'GetMyData2
    ' </Snippet2>
End Class 'Form1 
