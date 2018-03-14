 '<Snippet1>
Imports System
Imports System.CodeDom

Namespace CodeDomSamples
    
   Public Class CodeCommentExample
      
      Public Sub New()
         '<Snippet2>
         ' Create a CodeComment with some example comment text.
         Dim comment As New CodeComment( _
            "This comment was generated from a System.CodeDom.CodeComment", _
            False) ' Whether the comment is a documentation comment.
         
         ' Create a CodeCommentStatement that contains the comment, in order
         ' to add the comment to a CodeTypeDeclaration Members collection.
         Dim commentStatement As New CodeCommentStatement(comment)	

         ' A Visual Basic code generator produces the following source code for the preceeding example code:
    
         ' 'This comment was generated from a System.CodeDom.CodeComment
    '</Snippet2>
      End Sub 'New 

   End Class 'CodeCommentExample

End Namespace 'CodeDomSamples 

'</Snippet1>