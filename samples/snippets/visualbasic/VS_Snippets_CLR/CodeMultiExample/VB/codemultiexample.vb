'<Snippet1>
Imports System
Imports System.CodeDom

Namespace CodeDomSamples

    Public Class CodeMultiExample

        Public Sub New()
        End Sub 'New

        Public Sub CodeEventReferenceExample()
            '<Snippet2>
            ' Represents a reference to an event.
            Dim eventRef1 As New CodeEventReferenceExpression(New CodeThisReferenceExpression(), "TestEvent")

            ' A Visual Basic code generator produces the following source code for the preceeding example code:

            '       Me.TestEvent
            '</Snippet2>
        End Sub 'CodeEventReferenceExample

        Public Sub CodeIndexerExample()
            '<Snippet3>						
            Dim indexerExpression = New CodeIndexerExpression(New CodeThisReferenceExpression(), New CodePrimitiveExpression(1))

            ' A Visual Basic code generator produces the following source code for the preceeding example code:

            '       Me(1)            		
            '</Snippet3>
        End Sub 'CodeIndexerExample

        Public Sub CodeDirectionExample()
            '<Snippet4>			
            ' Declares a parameter passed by reference using a CodeDirectionExpression.
            Dim param1 As New CodeDirectionExpression(FieldDirection.Ref, New CodeFieldReferenceExpression(New CodeThisReferenceExpression(), "TestParameter"))
            ' Invokes a method on this named TestMethod using the direction expression as a parameter.
            Dim methodInvoke1 As New CodeMethodInvokeExpression(New CodeThisReferenceExpression(), "TestMethod", param1)

            ' A Visual Basic code generator produces the following source code for the preceeding example code:	

            '      Me.TestMethod("TestParameter")
            '</Snippet4>			
        End Sub 'CodeDirectionExample

        Public Sub CreateExpressionExample()
            '<Snippet5>
            Dim objectCreate1 As New CodeObjectCreateExpression("System.DateTime", New CodeExpression() {})

            ' A Visual Basic code generator produces the following source code for the preceeding example code:	

            '       New Date
            '</Snippet5>

        End Sub 'CreateExpressionExample 
    End Class 'CodeMultiExample 
End Namespace 'CodeDomSamples
'</Snippet1>