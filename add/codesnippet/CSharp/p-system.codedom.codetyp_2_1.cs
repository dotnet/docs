            CodeTypeDeclaration baseClass = new CodeTypeDeclaration("DocumentProperties");
            baseClass.IsPartial = true;
            baseClass.IsClass = true;
            baseClass.Attributes = MemberAttributes.Public;
            baseClass.BaseTypes.Add(new CodeTypeReference(typeof(System.Object
)));

            // Add the DocumentProperties class to the namespace.
            sampleSpace.Types.Add(baseClass);