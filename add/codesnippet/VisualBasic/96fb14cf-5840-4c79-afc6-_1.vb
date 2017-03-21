        ' Adds an array of CodeCommentStatement objects to the collection.
        Dim comments As CodeCommentStatement() = {New CodeCommentStatement("Test comment"), New CodeCommentStatement("Another test comment")}
        collection.AddRange(comments)

        ' Adds a collection of CodeCommentStatement objects to the 
        ' collection.
        Dim commentsCollection As New CodeCommentStatementCollection()
        commentsCollection.Add(New CodeCommentStatement("Test comment"))
        commentsCollection.Add(New CodeCommentStatement("Another test comment"))
        collection.AddRange(commentsCollection)