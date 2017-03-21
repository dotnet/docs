            // Adds an array of CodeTypeMember objects to the collection.
            CodeTypeMember[] members = { new CodeMemberField("System.String", "TestStringField1"), new CodeMemberField("System.String", "TestStringField2") };
            collection.AddRange( members );

            // Adds a collection of CodeTypeMember objects to the collection.
            CodeTypeMemberCollection membersCollection = new CodeTypeMemberCollection();
            membersCollection.Add( new CodeMemberField("System.String", "TestStringField1") );
            membersCollection.Add( new CodeMemberField("System.String", "TestStringField2") );
            collection.AddRange( membersCollection );