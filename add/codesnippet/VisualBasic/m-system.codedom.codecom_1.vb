        ' Declare a new code entry point method.
        Dim start As New CodeEntryPointMethod()
        start.Comments.Add(New CodeCommentStatement("<summary>", True))
        start.Comments.Add(New CodeCommentStatement( _
            "Main method for HelloWorld application.", True))
        start.Comments.Add(New CodeCommentStatement( _
            "<para>Add a new paragraph to the description.</para>", True))
        start.Comments.Add(New CodeCommentStatement("</summary>", True))