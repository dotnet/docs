'<Snippet1>
Imports System
Imports System.CodeDom
Imports System.CodeDom.Compiler

Namespace CodeDomSamples
    Public Class CodeTypeOfExample
        Public Shared Sub Main()
            ShowTypeReference()
            Console.WriteLine()
            ShowTypeReferenceExpression()
        End Sub

        Public Shared Sub ShowTypeReference()
            '<Snippet2>
            ' Creates a reference to the System.DateTime type.
            Dim typeRef1 As New CodeTypeReference("System.DateTime")

            ' Creates a typeof expression for the specified type reference.
            Dim typeof1 As New CodeTypeOfExpression(typeRef1)

            ' Create a Visual Basic code provider
            Dim provider As CodeDomProvider = CodeDomProvider.CreateProvider("VisualBasic")

            ' Generate code and send the output to the console
            provider.GenerateCodeFromExpression(typeof1, Console.Out, new CodeGeneratorOptions())
            ' The code generator produces the following source code for the preceeding example code:
            '    GetType(Date)
            '</Snippet2>
        End Sub

        Public Shared Sub ShowTypeReferenceExpression()
            '<Snippet3>
            ' Creates an expression referencing the System.DateTime type.
            Dim typeRef1 As new CodeTypeReferenceExpression("System.DateTime")

            ' Create a Visual Basic code provider
            Dim provider As CodeDomProvider = CodeDomProvider.CreateProvider("VisualBasic")

            ' Generate code and send the output to the console
            provider.GenerateCodeFromExpression(typeRef1, Console.Out, New CodeGeneratorOptions())
            ' The code generator produces the following source code for the preceeding example code:

            '    Date

            '</Snippet3>
        End Sub
    End Class
End Namespace
'</Snippet1>