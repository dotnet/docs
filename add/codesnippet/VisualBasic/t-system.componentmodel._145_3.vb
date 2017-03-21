            Dim attributes As AttributeCollection = TypeDescriptor.GetAttributes(MyProperty)
            If attributes(GetType(BindableAttribute)).Equals(BindableAttribute.Yes) Then
                ' Insert code here.
            End If 