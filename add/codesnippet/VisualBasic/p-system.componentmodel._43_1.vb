 ' Gets the attributes for the property.
 Dim attributes As AttributeCollection = _
    TypeDescriptor.GetProperties(Me)("MyProperty").Attributes
        
 ' Checks to see if the property needs to be localized.
 Dim myAttribute As LocalizableAttribute = _
    CType(attributes(GetType(LocalizableAttribute)), LocalizableAttribute)
    
 If myAttribute.IsLocalizable Then
      ' Insert code here.
 End If
