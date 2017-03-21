    Protected Overrides Sub PerformDataBinding(ByVal retrievedData As IEnumerable)
        MyBase.PerformDataBinding(retrievedData)

        ' If the data is retrieved from an IDataSource as an IEnumerable 
        ' collection, attempt to bind its values to a set of TextBox controls.
        If Not (retrievedData Is Nothing) Then

            Dim dataItem As Object
            For Each dataItem In retrievedData

                Dim box As New TextBox()

                ' The dataItem is not just a string, but potentially
                ' a System.Data.DataRowView or some other container. 
                ' If DataTextField is set, use it to determine which 
                ' field to render. Otherwise, use the first field.                    
                If DataTextField.Length > 0 Then
                    box.Text = DataBinder.GetPropertyValue( _
                    dataItem, DataTextField, Nothing)
                Else
                    Dim props As PropertyDescriptorCollection = _
                        TypeDescriptor.GetProperties(dataItem)

                    ' Set the "default" value of the TextBox.
                    box.Text = String.Empty

                    ' Set the true data-bound value of the TextBox,
                    ' if possible.
                    If props.Count >= 1 Then
                        If props(0).GetValue(dataItem) IsNot Nothing Then
                            box.Text = props(0).GetValue(dataItem).ToString()
                        End If
                    End If
                End If

                BoxSet.Add(box)
            Next dataItem
        End If

    End Sub 'PerformDataBinding
