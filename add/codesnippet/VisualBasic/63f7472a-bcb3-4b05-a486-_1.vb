    ' PropertyValueUIHandler delegate that provides PropertyValueUIItem
    ' objects to any properties named HorizontalMargin or VerticalMargin.
    Private Sub marginPropertyValueUIHandler(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal propDesc As System.ComponentModel.PropertyDescriptor, ByVal itemList As ArrayList)
        ' A PropertyValueUIHandler added to the IPropertyValueUIService
        ' is queried once for each property of a component and passed
        ' a PropertyDescriptor that represents the characteristics of 
        ' the property when the Properties window is set to a new 
        ' component. A PropertyValueUIHandler can determine whether 
        ' to add a PropertyValueUIItem for the object to its ValueUIItem 
        ' list depending on the values of the PropertyDescriptor.
        If propDesc.DisplayName.Equals("HorizontalMargin") Then
            Dim img As Image = DeserializeFromBase64Text(imageBlob1)
            itemList.Add(New PropertyValueUIItem(img, New PropertyValueUIItemInvokeHandler(AddressOf Me.marginInvoke), "Test ToolTip"))
        End If
        If propDesc.DisplayName.Equals("VerticalMargin") Then
            Dim img As Image = DeserializeFromBase64Text(imageBlob1)
            img.RotateFlip(RotateFlipType.Rotate90FlipNone)
            itemList.Add(New PropertyValueUIItem(img, New PropertyValueUIItemInvokeHandler(AddressOf Me.marginInvoke), "Test ToolTip"))
        End If
    End Sub