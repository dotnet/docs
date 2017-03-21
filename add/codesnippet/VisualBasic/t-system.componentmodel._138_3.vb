            Dim attributes As AttributeCollection = TypeDescriptor.GetAttributes(MyProperty)
            If attributes(GetType(MergablePropertyAttribute)).Equals(MergablePropertyAttribute.Yes) Then
                ' Insert code here.
            End If 