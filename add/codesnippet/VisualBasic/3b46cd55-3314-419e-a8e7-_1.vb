    Public Function GetItemProperties(ByVal listAccessors() As System.ComponentModel.PropertyDescriptor) As System.ComponentModel.PropertyDescriptorCollection Implements System.ComponentModel.ITypedList.GetItemProperties

        Dim pdc As PropertyDescriptorCollection

        If (Not (listAccessors Is Nothing)) And (listAccessors.Length > 0) Then
            ' Return child list shape
            pdc = ListBindingHelper.GetListItemProperties(listAccessors(0).PropertyType)
        Else
            ' Return properties in sort order
            pdc = properties
        End If

        Return pdc

    End Function