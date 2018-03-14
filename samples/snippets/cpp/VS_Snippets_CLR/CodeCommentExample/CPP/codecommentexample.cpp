

//<Snippet1>
#using <System.dll>

using namespace System;
using namespace System::CodeDom;

namespace CodeDomSamples
{
   public ref class CodeCommentExample
   {
   public:
      CodeCommentExample()
      {
         
         //<Snippet2>
         // Create a CodeComment with some example comment text.
         
         // The text of the comment.
         // Whether the comment is a comment intended for documentation purposes.
         CodeComment^ comment = gcnew CodeComment( "This comment was generated from a System.CodeDom.CodeComment",false );
         
         // Create a CodeCommentStatement that contains the comment, in order
         // to add the comment to a CodeTypeDeclaration Members collection.
         CodeCommentStatement^ commentStatement = gcnew CodeCommentStatement( comment );
         
         // A C# code generator produces the following source code for the preceeding example code:
         // // This comment was generated from a System.CodeDom.CodeComment
         //</Snippet2>
      }

   };

}

//</Snippet1>
