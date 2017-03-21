            Dim baseClass As CodeTypeDeclaration = New CodeTypeDeclaration("DocumentProperties")
            baseClass.IsPartial = True
            baseClass.IsClass = True
            baseClass.Attributes = MemberAttributes.Public
            baseClass.BaseTypes.Add(New CodeTypeReference(GetType(System.Object)))

            ' Add the DocumentProperties class to the namespace.
            sampleSpace.Types.Add(baseClass)