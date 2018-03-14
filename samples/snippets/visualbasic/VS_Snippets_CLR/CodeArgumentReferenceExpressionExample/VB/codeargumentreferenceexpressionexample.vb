'<Snippet1>
Imports System
Imports System.CodeDom

Namespace CodeDomSamples
    _
   Public Class CodeArgumentReferenceExpressionExample
      
      Public Sub New()
         '<Snippet2>			
         ' Declare a method that accepts a string parameter named text.
         Dim cmm As New CodeMemberMethod()
         cmm.Parameters.Add(New CodeParameterDeclarationExpression("String", "text"))
         cmm.Name = "WriteString"
         cmm.ReturnType = New CodeTypeReference("System.Void")
         
         ' Create a method invoke statement to output the string passed to the method.
         Dim cmie As New CodeMethodInvokeExpression(New CodeTypeReferenceExpression("Console"), "WriteLine", New CodeArgumentReferenceExpression("text"))
         
         ' Add the method invoke expression to the method's statements collection.
         cmm.Statements.Add(cmie)
        
         ' A Visual Basic code generator produces the following source code for the preceeding example code:
         '		Private Sub WriteString(ByVal [text] As [String])
         '			Console.WriteLine([text])
         '		End Sub
         '</Snippet2>
     End Sub 'New 
   
    End Class 'CodeArgumentReferenceExpressionExample    

End Namespace
'</Snippet1>