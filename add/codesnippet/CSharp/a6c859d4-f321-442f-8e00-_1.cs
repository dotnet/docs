            // Adds an array of CodeExpression objects to the collection.
            CodeExpression[] expressions = { new CodePrimitiveExpression(true), new CodePrimitiveExpression(true) };
            collection.AddRange( expressions );

            // Adds a collection of CodeExpression objects to the collection.
            CodeExpressionCollection expressionsCollection = new CodeExpressionCollection();
            expressionsCollection.Add( new CodePrimitiveExpression(true) );
            expressionsCollection.Add( new CodePrimitiveExpression(true) );
            collection.AddRange( expressionsCollection );