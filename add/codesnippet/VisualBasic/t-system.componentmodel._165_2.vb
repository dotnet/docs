            ' Gets the attributes for the property.
            Dim attributes As AttributeCollection = _
                TypeDescriptor.GetProperties(Me)("MyProperty").Attributes
            
            ' Checks to see if the value of the BindableAttribute is Yes.
            If attributes(GetType(BindableAttribute)).Equals(BindableAttribute.Yes) Then
                ' Insert code here.
            End If 
            
            ' This is another way to see whether the property is bindable.
            Dim myAttribute As BindableAttribute = _
                CType(attributes(GetType(BindableAttribute)), BindableAttribute)
            If myAttribute.Bindable Then
                ' Insert code here.
            End If 

 	    ' Yet another way to see whether the property is bindable.
	    If attributes.Contains(BindableAttribute.Yes) Then
		' Insert code here.
	    End If
