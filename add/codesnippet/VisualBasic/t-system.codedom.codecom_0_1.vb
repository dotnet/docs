        ' Creates an empty CodeCommentStatementCollection.
        Dim collection As New CodeCommentStatementCollection()

        ' Adds a CodeCommentStatement to the collection.
        collection.Add(New CodeCommentStatement("Test comment"))

        ' Adds an array of CodeCommentStatement objects to the collection.
        Dim comments As CodeCommentStatement() = {New CodeCommentStatement("Test comment"), New CodeCommentStatement("Another test comment")}
        collection.AddRange(comments)

        ' Adds a collection of CodeCommentStatement objects to the 
        ' collection.
        Dim commentsCollection As New CodeCommentStatementCollection()
        commentsCollection.Add(New CodeCommentStatement("Test comment"))
        commentsCollection.Add(New CodeCommentStatement("Another test comment"))
        collection.AddRange(commentsCollection)

        ' Tests for the presence of a CodeCommentStatement in the 
        ' collection, and retrieves its index if it is found.
        Dim testComment As New CodeCommentStatement("Test comment")
        Dim itemIndex As Integer = -1
        If collection.Contains(testComment) Then
            itemIndex = collection.IndexOf(testComment)
        End If

        ' Copies the contents of the collection beginning at index 0 to the specified CodeCommentStatement array.
        ' 'comments' is a CodeCommentStatement array.
        collection.CopyTo(comments, 0)

        ' Retrieves the count of the items in the collection.
        Dim collectionCount As Integer = collection.Count

        ' Inserts a CodeCommentStatement at index 0 of the collection.
        collection.Insert(0, New CodeCommentStatement("Test comment"))

        ' Removes the specified CodeCommentStatement from the collection.
        Dim comment As New CodeCommentStatement("Test comment")
        collection.Remove(comment)

        ' Removes the CodeCommentStatement at index 0.
        collection.RemoveAt(0)