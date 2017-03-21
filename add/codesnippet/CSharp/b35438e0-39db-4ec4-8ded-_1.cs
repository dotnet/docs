            // Copies the contents of the collection beginning at index 0 to the specified CodeStatement array.
            // 'statements' is a CodeStatement array.
            CodeStatement[] statementArray = new CodeStatement[collection.Count];
            collection.CopyTo( statementArray, 0 );