    ' Returns the properties of the specified component extended with 
    ' a CategoryAttribute reflecting the name of the type of the property.
    Public Overloads Overrides Function GetProperties(ByVal component As Object, ByVal attributes() As System.Attribute) As System.ComponentModel.PropertyDescriptorCollection
        Dim props As PropertyDescriptorCollection
        If attributes Is Nothing Then
            props = TypeDescriptor.GetProperties(component)
        Else
            props = TypeDescriptor.GetProperties(component, attributes)
        End If
        Dim propArray(props.Count - 1) As PropertyDescriptor
        Dim i As Integer
        For i = 0 To props.Count - 1
            ' Create a new PropertyDescriptor from the old one, with 
            ' a CategoryAttribute matching the name of the type.
            propArray(i) = TypeDescriptor.CreateProperty(props(i).ComponentType, props(i), New CategoryAttribute(props(i).PropertyType.Name))
        Next i
        Return New PropertyDescriptorCollection(propArray)
    End Function

    Public Overloads Overrides Function GetProperties(ByVal component As Object) As System.ComponentModel.PropertyDescriptorCollection
        Return Me.GetProperties(component, Nothing)
    End Function