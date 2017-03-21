            // Adds an array of CodeParameterDeclarationExpression objects 
            // to the collection.
            CodeParameterDeclarationExpression[] parameters = { new CodeParameterDeclarationExpression(typeof(int), "testIntArgument"), new CodeParameterDeclarationExpression(typeof(bool), "testBoolArgument") };
            collection.AddRange( parameters );

            // Adds a collection of CodeParameterDeclarationExpression objects 
            // to the collection.
            CodeParameterDeclarationExpressionCollection parametersCollection = new CodeParameterDeclarationExpressionCollection();
            parametersCollection.Add( new CodeParameterDeclarationExpression(typeof(int), "testIntArgument") );
            parametersCollection.Add( new CodeParameterDeclarationExpression(typeof(bool), "testBoolArgument") );
            collection.AddRange( parametersCollection );