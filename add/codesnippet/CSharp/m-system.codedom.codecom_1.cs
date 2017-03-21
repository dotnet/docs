            // Declare a new code entry point method.
            CodeEntryPointMethod start = new CodeEntryPointMethod();
            start.Comments.Add(new CodeCommentStatement("<summary>", true));
            start.Comments.Add(new CodeCommentStatement(
                "Main method for HelloWorld application.", true));
            start.Comments.Add(new CodeCommentStatement(
                @"<para>Add a new paragraph to the description.</para>", true));
            start.Comments.Add(new CodeCommentStatement("</summary>", true));