    Private Sub GetData2()
        ' Creates a component.
        Dim myComponent As New System.ComponentModel.Component()

        ' Creates a data object, and assigns it the component.
        Dim myDataObject As New DataObject(myComponent)

        ' Creates a type, myType, to store the type of data.
        Dim myType As Type = myComponent.GetType()

        ' Retrieves the data using myType to represent its type.
        Dim myObject As [Object] = myDataObject.GetData(myType)
        If (myObject IsNot Nothing) Then
            MessageBox.Show("The data type stored in the data object is " + myObject.GetType().Name + ".")
        Else
            MessageBox.Show("Data of the specified type was not stored " + "in the data object.")
        End If
    End Sub 'GetData2