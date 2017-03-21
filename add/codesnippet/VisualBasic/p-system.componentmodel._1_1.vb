        ' Gets the attributes for the property.
        Dim attributes As AttributeCollection = TypeDescriptor.GetProperties(Me)("MyProperty").Attributes
        
        ' Checks to see if the property is browsable.
        Dim myAttribute As BrowsableAttribute = CType(attributes(GetType(BrowsableAttribute)), BrowsableAttribute)
        If myAttribute.Browsable Then
            ' Insert code here.
        End If 