        ' Creates an empty CodeTypeMemberCollection.
        Dim collection As New CodeTypeMemberCollection()

        ' Adds a CodeTypeMember to the collection.
        collection.Add(New CodeMemberField("System.String", "TestStringField"))

        ' Adds an array of CodeTypeMember objects to the collection.
        Dim members As CodeTypeMember() = {New CodeMemberField("System.String", "TestStringField1"), New CodeMemberField("System.String", "TestStringField2")}
        collection.AddRange(members)

        ' Adds a collection of CodeTypeMember objects to the collection.
        Dim membersCollection As New CodeTypeMemberCollection()
        membersCollection.Add(New CodeMemberField("System.String", "TestStringField1"))
        membersCollection.Add(New CodeMemberField("System.String", "TestStringField2"))
        collection.AddRange(membersCollection)

        ' Tests for the presence of a CodeTypeMember within the collection, and retrieves its index if it is within the collection.
        Dim testMember = New CodeMemberField("System.String", "TestStringField")
        Dim itemIndex As Integer = -1
        If collection.Contains(testMember) Then
            itemIndex = collection.IndexOf(testMember)
        End If

        ' Copies the contents of the collection, beginning at index 0, 
        ' to the specified CodeTypeMember array.
        ' 'members' is a CodeTypeMember array.
        collection.CopyTo(members, 0)

        ' Retrieves the count of the items in the collection.
        Dim collectionCount As Integer = collection.Count

        ' Inserts a CodeTypeMember at index 0 of the collection.
        collection.Insert(0, New CodeMemberField("System.String", "TestStringField"))

        ' Removes the specified CodeTypeMember from the collection.
        Dim member = New CodeMemberField("System.String", "TestStringField")
        collection.Remove(member)

        ' Removes the CodeTypeMember at index 0.
        collection.RemoveAt(0)