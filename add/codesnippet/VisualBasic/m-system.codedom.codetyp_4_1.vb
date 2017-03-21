        Dim kType As New CodeTypeParameter("TKey")
        kType.HasConstructorConstraint = True
        kType.Constraints.Add(New CodeTypeReference(GetType(IComparable)))
        kType.CustomAttributes.Add _
            (New CodeAttributeDeclaration("System.ComponentModel.DescriptionAttribute", _
                New CodeAttributeArgument(New CodePrimitiveExpression("KeyType"))))
        Dim iComparableT As New CodeTypeReference("IComparable")
        iComparableT.TypeArguments.Add(New CodeTypeReference(kType))

        kType.Constraints.Add(iComparableT)

        Dim vType As New CodeTypeParameter("TValue")
        vType.Constraints.Add(New CodeTypeReference(GetType(IList(Of System.String))))
        vType.CustomAttributes.Add _
            (New CodeAttributeDeclaration("System.ComponentModel.DescriptionAttribute", _
                New CodeAttributeArgument(New CodePrimitiveExpression("ValueType"))))

        class1.TypeParameters.Add(kType)
        class1.TypeParameters.Add(vType)