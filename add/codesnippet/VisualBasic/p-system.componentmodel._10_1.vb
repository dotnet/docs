 ' Gets the attributes for the property.
 Dim attributes As AttributeCollection = _
    TypeDescriptor.GetProperties(Me)("MyPropertyProperty").Attributes
        
 ' Checks to see if the property is bindable.
 Dim myAttribute As MergablePropertyAttribute = _
    CType(attributes(GetType(MergablePropertyAttribute)), _
    MergablePropertyAttribute)
 If myAttribute.AllowMerge Then
     ' Insert code here.
 End If
