        ' Gets the attributes for the property.
        Dim attributes As AttributeCollection = TypeDescriptor.GetProperties(Me)("MyProperty").Attributes
        
        ' Checks to see if the value of the RecommendedAsConfigurableAttribute is Yes.
        If attributes(GetType(RecommendedAsConfigurableAttribute)).Equals(RecommendedAsConfigurableAttribute.Yes) Then
            ' Insert code here.
        End If 
        
        ' This is another way to see if the property is recommended as configurable.
        Dim myAttribute As RecommendedAsConfigurableAttribute = _
            CType(attributes(GetType(RecommendedAsConfigurableAttribute)), RecommendedAsConfigurableAttribute)
        If myAttribute.RecommendedAsConfigurable Then
            ' Insert code here.
        End If