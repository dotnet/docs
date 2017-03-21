            Dim baseClass As CodeTypeDeclaration = New CodeTypeDeclaration("DocumentProperties")
            baseClass.IsPartial = True
            baseClass.IsClass = True
            baseClass.Attributes = MemberAttributes.Public

            ' Extend the DocumentProperties class in the unit namespace.
            docPropUnit.Namespaces(0).Types.Add(baseClass)