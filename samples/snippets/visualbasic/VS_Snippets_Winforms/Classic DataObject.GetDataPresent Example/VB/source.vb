Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms
Imports Microsoft.VisualBasic



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    ' <Snippet1>
    Private Sub GetIfPresent2()
        ' Creates a component to store in the data object.
        Dim myComponent As New Component()
        
        ' Creates a new data object and assigns it the component.
        Dim myDataObject As New DataObject(myComponent)
        
        ' Creates a type to store the type of data.
        Dim myType As Type = myComponent.GetType()
        
        ' Determines if the DataObject has data of the Type format.
        textBox1.Text = "Is the specified data type available in the " & "DataObject? " & _
            myDataObject.GetDataPresent(myType).ToString() & ControlChars.Cr
        
        ' Retrieves the data using its type format, and displays the type.
        Dim myObject As Object = myDataObject.GetData(myType)
        textBox1.Text += "The data type stored in the DataObject is: " + myObject.GetType().Name
    End Sub 'GetIfPresent2
    ' </Snippet1>
End Class 'Form1


