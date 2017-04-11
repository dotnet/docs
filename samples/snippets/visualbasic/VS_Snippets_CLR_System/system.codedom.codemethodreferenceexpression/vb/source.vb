' <Snippet1>
Imports System
Imports System.CodeDom
Imports System.CodeDom.Compiler

Public Class CodeGenExample

    Shared Sub Main
        ' Declare a new type called Class1.
        Dim class1 as New CodeTypeDeclaration("Class1")

        ' Declares a type constructor that calls a method.
        Dim constructor1 As New CodeConstructor()
        constructor1.Attributes = MemberAttributes.Public
        class1.Members.Add( constructor1 )

        ' Creates a method reference for dict.Init.
        Dim methodRef1 as New CodeMethodReferenceExpression(
            New CodeVariableReferenceExpression("dict"),
            "Init",
            New CodeTypeReference() {
                New CodeTypeReference("System.Decimal"),
                New CodeTypeReference("System.Int32")})

        ' Invokes the dict.Init method from the constructor.
        Dim invoke1 As New CodeMethodInvokeExpression( methodRef1, new CodeParameterDeclarationExpression() {} )
        constructor1.Statements.Add( invoke1 )

        ' Create a Visual Basic code provider
        Dim provider As CodeDomProvider = CodeDomProvider.CreateProvider("VisualBasic")

        ' Generate code and send the output to the console
        provider.GenerateCodeFromType(class1, Console.Out, New CodeGeneratorOptions())
    End Sub

End Class

' The Visual Basic code generator produces the following source code for the preceeding example code:
'
' Public Class Class1
'
'     Public Sub New()
'         MyBase.New
'         dict.Init(Of Decimal, Integer)
'     End Sub
' End Class'
' </Snippet1>
