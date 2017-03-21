        ' Gets the attributes for the property.
        Dim attributes As AttributeCollection = _
            TypeDescriptor.GetProperties(Me)("MyProperty").Attributes
        
        ' Checks to see whether the value of the ReadOnlyAttribute is Yes.
        If attributes(GetType(ReadOnlyAttribute)).Equals(ReadOnlyAttribute.Yes) Then
            ' Insert code here.
        End If 
        
        ' This is another way to see whether the property is read-only.
        Dim myAttribute As ReadOnlyAttribute = _
            CType(attributes(GetType(ReadOnlyAttribute)), ReadOnlyAttribute)
            
        If myAttribute.IsReadOnly Then
            ' Insert code here.
        End If 