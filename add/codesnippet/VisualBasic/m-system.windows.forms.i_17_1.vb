    Private Sub GetDataPresent2()
        ' Creates a component to store in the data object.
        Dim myComponent As New System.ComponentModel.Component()

        ' Creates a new data object and assigns it the component.
        Dim myDataObject As New DataObject(myComponent)

        'Creates a type to store the type of data.
        Dim myType As Type = myComponent.GetType()

        ' Checks whether the specified data type exists in the object.
        If myDataObject.GetDataPresent(myType) Then
            MessageBox.Show("The specified data is stored in the data object.")
            ' Displays the type of data.
            TextBox1.Text = "The data type is " & myDataObject.GetData(myType).GetType().Name & "."
        Else
            MessageBox.Show("The specified data is not stored in the data object.")
        End If
    End Sub 'GetDataPresent2