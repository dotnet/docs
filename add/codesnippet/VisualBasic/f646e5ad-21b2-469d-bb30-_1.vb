        ' Adds an array of CodeTypeMember objects to the collection.
        Dim members As CodeTypeMember() = {New CodeMemberField("System.String", "TestStringField1"), New CodeMemberField("System.String", "TestStringField2")}
        collection.AddRange(members)

        ' Adds a collection of CodeTypeMember objects to the collection.
        Dim membersCollection As New CodeTypeMemberCollection()
        membersCollection.Add(New CodeMemberField("System.String", "TestStringField1"))
        membersCollection.Add(New CodeMemberField("System.String", "TestStringField2"))
        collection.AddRange(membersCollection)