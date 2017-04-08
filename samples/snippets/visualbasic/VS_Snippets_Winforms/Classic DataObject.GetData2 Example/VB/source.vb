Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    ' <Snippet1>
    Private Sub GetMyData()
        ' Creates a component to store in the data object.
        Dim myComponent As New Component()
        
        ' Creates a new data object and assigns it the component.
        Dim myDataObject As New DataObject(myComponent)
        
        ' Creates a type to store the type of data.
        Dim myType As Type = myComponent.GetType()
        
        ' Retrieves the data using myType to represent its type.
        Dim myObject As Object = myDataObject.GetData(myType)
        If (myObject IsNot Nothing) Then
            textBox1.Text = "The data type stored in the DataObject is: " & myObject.GetType().Name
        Else
            textBox1.Text = "Data of the specified type was not stored " & "in the DataObject."
        End If
    End Sub 'GetMyData
    ' </Snippet1>
End Class 'Form1 

