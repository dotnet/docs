            ' Gets the attributes for the property.
            Dim attributes As AttributeCollection = _
                TypeDescriptor.GetProperties(Me)("MyProperty").Attributes
            
            ' Checks to see if the value of the MergablePropertyAttribute is Yes.
            If attributes(GetType(MergablePropertyAttribute)).Equals(MergablePropertyAttribute.Yes) Then
                ' Insert code here.
            End If 
            
            ' This is another way to see if the property is bindable.
            Dim myAttribute As MergablePropertyAttribute = _
                CType(attributes(GetType(MergablePropertyAttribute)), MergablePropertyAttribute)
            If myAttribute.AllowMerge Then
                ' Insert code here.
            End If 