 '<Snippet1>
Imports System
Imports System.CodeDom

Namespace CodeDomSamples
    
   Public Class CodeIterationStatementExample
      
      Public Sub New()
         '<Snippet2>
         ' Declares and initializes an integer variable named testInt.
         Dim testInt As New CodeVariableDeclarationStatement(GetType(Integer), "testInt", New CodePrimitiveExpression(0))
         
         ' Creates a for loop that sets testInt to 0 and continues incrementing testInt by 1 each loop until testInt is not less than 10.
            ' initStatement parameter for pre-loop initialization.
            ' testExpression parameter indicates the epxression to test for continuation condition.
            ' incrementStatement parameter indicates statement to execute after each iteration.
            ' statements parameter contains the statements to execute during each interation of the loop.
            ' Each loop iteration the value of the integer is output using the Console.WriteLine method.

         Dim forLoop As New CodeIterationStatement( _
            New CodeAssignStatement(New CodeVariableReferenceExpression("testInt"), New CodePrimitiveExpression(1)), _
            New CodeBinaryOperatorExpression(New CodeVariableReferenceExpression("testInt"), _ 
                CodeBinaryOperatorType.LessThan, New CodePrimitiveExpression(10)), _
            New CodeAssignStatement(New CodeVariableReferenceExpression("testInt"), _
            New CodeBinaryOperatorExpression(New CodeVariableReferenceExpression("testInt"), _
                CodeBinaryOperatorType.Add, New CodePrimitiveExpression(1))), _
            New CodeStatement() {New CodeExpressionStatement( _
                New CodeMethodInvokeExpression(New CodeMethodReferenceExpression(New CodeTypeReferenceExpression("Console"), "WriteLine"), _ 
                        New CodeMethodInvokeExpression(New CodeVariableReferenceExpression("testInt"), "ToString")))})


        ' A Visual Basic code generator produces the following source code for the preceeding example code:

        '     Dim testInt As Integer = 0
        '     testInt = 1
        '     Do While (testInt < 10)
        '         Console.WriteLine(testInt.ToString)
        '         testInt = (testInt + 1)
        '</Snippet2>      
      End Sub 'New 

   End Class 'CodeIterationStatementExample

End Namespace 'CodeDomSamples 

'</Snippet1>