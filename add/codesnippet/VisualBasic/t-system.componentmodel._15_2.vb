            ' Gets the attributes for the property.
            Dim attributes As AttributeCollection = _
                TypeDescriptor.GetProperties(Me)("MyProperty").Attributes
            
            ' Checks to see if the value of the BrowsableAttribute is Yes.
            If attributes(GetType(BrowsableAttribute)).Equals(BrowsableAttribute.Yes) Then
                ' Insert code here.
            End If 
            
            ' This is another way to see whether the property is browsable.
            Dim myAttribute As BrowsableAttribute = _
                CType(attributes(GetType(BrowsableAttribute)), BrowsableAttribute)
            If myAttribute.Browsable Then
                ' Insert code here.
            End If 