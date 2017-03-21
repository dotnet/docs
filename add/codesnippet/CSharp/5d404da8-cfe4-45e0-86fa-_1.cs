            // Removes the specified CodeAttributeDeclaration from 
            // the collection.
            CodeAttributeDeclaration declaration = new CodeAttributeDeclaration("DescriptionAttribute", new CodeAttributeArgument(new CodePrimitiveExpression("Test Description")) );
            collection.Remove( declaration );