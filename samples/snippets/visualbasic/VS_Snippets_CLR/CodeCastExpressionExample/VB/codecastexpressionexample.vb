 '<Snippet1>
Imports System
Imports System.CodeDom

Namespace CodeDomSamples
    
   Public Class CodeCastExpressionExample
      
      Public Sub New()
        '<Snippet2>
        ' This CodeCastExpression casts an Int32 of 1000 to an Int64.		
        Dim castExpression As New CodeCastExpression( _
            "System.Int64", New CodePrimitiveExpression(1000) )
            
        ' A Visual Basic code generator produces the following source code for the preceeding example code:
        
        ' CType(1000,Long)
        '</Snippet2>
      End Sub 'New 

   End Class 'CodeCastExpressionExample

End Namespace 'CodeDomSamples 

'</Snippet1>