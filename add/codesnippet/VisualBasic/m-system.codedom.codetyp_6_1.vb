        ' Tests for the presence of a CodeTypeMember within the collection, and retrieves its index if it is within the collection.
        Dim testMember = New CodeMemberField("System.String", "TestStringField")
        Dim itemIndex As Integer = -1
        If collection.Contains(testMember) Then
            itemIndex = collection.IndexOf(testMember)
        End If