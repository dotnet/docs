   ' Gets the attributes for the property.
   Dim attributes As AttributeCollection = _
      TypeDescriptor.GetProperties(Me)("MyProperty").Attributes
 
        ' Checks to see if the property is bindable.
        Dim myAttribute As BindableAttribute = _
        CType(attributes(System.Type.GetType("BindableAttribute")), BindableAttribute)
        If (myAttribute.Bindable) Then
            ' Insert code here.
        End If
