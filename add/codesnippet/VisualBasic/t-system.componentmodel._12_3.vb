        Dim attributes As AttributeCollection = TypeDescriptor.GetAttributes(MyProperty)
        If attributes(GetType(RecommendedAsConfigurableAttribute)).Equals(RecommendedAsConfigurableAttribute.Yes) Then
            ' Insert code here.
        End If 