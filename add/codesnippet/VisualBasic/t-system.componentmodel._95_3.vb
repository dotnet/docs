        Dim attributes As AttributeCollection = TypeDescriptor.GetAttributes(MyProperty)
        If attributes(GetType(ReadOnlyAttribute)).Equals(ReadOnlyAttribute.Yes) Then
            ' Insert code here.
        End If 