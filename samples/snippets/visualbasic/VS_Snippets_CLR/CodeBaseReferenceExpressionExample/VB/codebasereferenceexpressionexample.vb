 '<Snippet1>
Imports System
Imports System.CodeDom

Namespace CodeDomSamples
    
   Public Class CodeBaseReferenceExpressionExample
      
      Public Sub New()
         '<Snippet2>
         ' Example method invoke expression uses CodeBaseReferenceExpression to produce 
         ' a base.Dispose method call
         Dim methodInvokeExpression As New CodeMethodInvokeExpression( New CodeBaseReferenceExpression(), "Dispose", New CodeExpression() {})    

         ' A Visual Basic code generator produces the following source code for the preceeding example code:

         ' MyBase.Dispose
        '</Snippet2>
      End Sub 'New 

   End Class 'CodeBaseReferenceExpressionExample ' Creates a method invoke expression

End Namespace 'CodeDomSamples


'</Snippet1>