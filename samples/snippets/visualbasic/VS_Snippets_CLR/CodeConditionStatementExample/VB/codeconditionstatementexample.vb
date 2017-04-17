 '<Snippet1>
Imports System
Imports System.CodeDom

Namespace CodeDomSamples
    
   Public Class CodeConditionStatementExample
      
      Public Sub New()
          '<Snippet2>
          ' Create a CodeConditionStatement that tests a boolean value named boolean.
           Dim conditionalStatement As New CodeConditionStatement( _
                New CodeVariableReferenceExpression("boolean"), _
                New CodeStatement() {New CodeCommentStatement("If condition is true, execute these statements.")}, _
                New CodeStatement() {New CodeCommentStatement("Else block. If condition is false, execute these statements.")})

          ' A Visual Basic code generator produces the following source code for the preceeding example code:

          ' If [boolean] Then
          '     'If condition is true, execute these statements.
          ' Else
          '     'Else block. If condition is false, execute these statements.
          
          '</Snippet2>
      End Sub 'New 

   End Class 'CodeConditionStatementExample

End Namespace 'CodeDomSamples 		
        
'</Snippet1>