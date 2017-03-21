            Dim attributes As AttributeCollection = TypeDescriptor.GetAttributes(MyProperty)
            If attributes(GetType(BrowsableAttribute)).Equals(BrowsableAttribute.Yes) Then
                ' Insert code here.
            End If 