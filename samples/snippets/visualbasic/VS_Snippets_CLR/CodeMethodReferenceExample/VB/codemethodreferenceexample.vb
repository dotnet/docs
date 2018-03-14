'<Snippet1>
Imports System
Imports System.CodeDom

Namespace CodeDomSamples

    Public Class CodeMethodReferenceExample

        Public Sub New()
            '<Snippet2>
            ' Declares a type to contain the example code.
            Dim type1 As New CodeTypeDeclaration("Type1")

            ' Declares a method.
            Dim method1 As New CodeMemberMethod()
            method1.Name = "TestMethod"
            type1.Members.Add(method1)

            ' Declares a type constructor that calls a method.
            Dim constructor1 As New CodeConstructor()
            constructor1.Attributes = MemberAttributes.Public
            type1.Members.Add(constructor1)

            ' Invokes the TestMethod method of the current type object.
            Dim methodRef1 As New CodeMethodReferenceExpression(New CodeThisReferenceExpression(), "TestMethod")
            Dim invoke1 As New CodeMethodInvokeExpression(methodRef1, New CodeParameterDeclarationExpression() {})
            constructor1.Statements.Add(invoke1)
        End Sub 'New
        '</Snippet2>

        Public Sub InvokeExample()
            '<Snippet3>
            ' Invokes the TestMethod method of the current type object.
            Dim methodRef1 As New CodeMethodReferenceExpression(New CodeThisReferenceExpression(), "TestMethod")
            Dim invoke1 As New CodeMethodInvokeExpression(methodRef1, New CodeParameterDeclarationExpression() {})

            ' A Visual Basic code generator produces the following source code for the preceeding example code:

            '       Me.TestMethod

            '</Snippet3>
        End Sub 'InvokeExample 
    End Class 'CodeMethodReferenceExample 
End Namespace 'CodeDomSamples
'</Snippet1>