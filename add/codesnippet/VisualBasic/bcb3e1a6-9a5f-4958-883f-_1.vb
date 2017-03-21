 ' Gets the attributes for the property.
 Dim attributes As AttributeCollection = _
    TypeDescriptor.GetProperties(Me)("MyProperty").Attributes
        
 ' Checks to see if the property is recommended as configurable.
 Dim myAttribute As RecommendedAsConfigurableAttribute = _
    CType(attributes(GetType(RecommendedAsConfigurableAttribute)), _
    RecommendedAsConfigurableAttribute)
    
 If myAttribute.RecommendedAsConfigurable Then
     ' Insert code here.
 End If
