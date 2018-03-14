'<Snippet1>
Imports System
Imports System.CodeDom

Namespace CodeDomSamples
    
   Public Class CodeVariableDeclarationStatementExample
      
      Public Sub New()
        '<Snippet2>
         Dim variableDeclaration As New CodeVariableDeclarationStatement( _
            GetType(String), "TestString", _ 
            New CodePrimitiveExpression("Testing")) 
        
        ' The first two parameters indicate the type and name of the variable to declare.
        ' The optional initExpression parameter initializes the variable.

        ' A Visual Basic code generator produces the following source code for the preceeding example code:

        ' Dim TestString As String = "Testing"
    '</Snippet2>
      End Sub 'New 

   End Class 'CodeVariableDeclarationStatementExample

End Namespace 'CodeDomSamples 

'</Snippet1>