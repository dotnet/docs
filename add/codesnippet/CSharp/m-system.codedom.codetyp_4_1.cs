            CodeTypeParameter kType = new CodeTypeParameter("TKey");
            kType.HasConstructorConstraint = true;
            kType.Constraints.Add(new CodeTypeReference(typeof(IComparable)));
            kType.CustomAttributes.Add(new CodeAttributeDeclaration(
                "System.ComponentModel.DescriptionAttribute",
                    new CodeAttributeArgument(new CodePrimitiveExpression("KeyType"))));

            CodeTypeReference iComparableT = new CodeTypeReference("IComparable");
            iComparableT.TypeArguments.Add(new CodeTypeReference(kType));

            kType.Constraints.Add(iComparableT);

            CodeTypeParameter vType = new CodeTypeParameter("TValue");
            vType.Constraints.Add(new CodeTypeReference(typeof(IList<System.String>)));
            vType.CustomAttributes.Add(new CodeAttributeDeclaration(
                "System.ComponentModel.DescriptionAttribute",
                    new CodeAttributeArgument(new CodePrimitiveExpression("ValueType"))));

            class1.TypeParameters.Add(kType);
            class1.TypeParameters.Add(vType);