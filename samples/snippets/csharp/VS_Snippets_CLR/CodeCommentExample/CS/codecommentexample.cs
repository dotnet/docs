//<Snippet1>
using System;
using System.CodeDom;

namespace CodeDomSamples
{
    public class CodeCommentExample
    {
        public CodeCommentExample()
        {
            //<Snippet2>
            // Create a CodeComment with some example comment text.
            CodeComment comment = new CodeComment(
                // The text of the comment.
                "This comment was generated from a System.CodeDom.CodeComment",
                // Whether the comment is a comment intended for documentation purposes.
                false );

            // Create a CodeCommentStatement that contains the comment, in order
            // to add the comment to a CodeTypeDeclaration Members collection.
            CodeCommentStatement commentStatement = new CodeCommentStatement( comment );

            // A C# code generator produces the following source code for the preceeding example code:
            
            // // This comment was generated from a System.CodeDom.CodeComment
            //</Snippet2>
        }
    }
}
//</Snippet1>