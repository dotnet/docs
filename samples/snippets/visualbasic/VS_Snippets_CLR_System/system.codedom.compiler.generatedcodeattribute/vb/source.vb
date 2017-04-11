' <Snippet1>
Imports System
Imports System.CodeDom
Imports System.CodeDom.Compiler

Public Class CodeGenExample

    Shared Sub Main
        ' Declare a new type called Class1.
        Dim class1 as New CodeTypeDeclaration("Class1")

        ' Declare a new generated code attribute
        Dim generatedCodeAttribute As _
            New GeneratedCodeAttribute("SampleCodeGenerator", "2.0.0.0")

        ' Use the generated code attribute members in the attribute declaration
        Dim  codeAttrDecl As _
            New CodeAttributeDeclaration(generatedCodeAttribute.GetType().Name,
                New CodeAttributeArgument(
                    New CodePrimitiveExpression(generatedCodeAttribute.Tool)),
                New CodeAttributeArgument(
                    New CodePrimitiveExpression(generatedCodeAttribute.Version)))
        class1.CustomAttributes.Add(codeAttrDecl)

        ' Create a Visual Basic code provider
        Dim provider As CodeDomProvider = CodeDomProvider.CreateProvider("VisualBasic")

        ' Generate code and send the output to the console
        provider.GenerateCodeFromType(class1, Console.Out, New CodeGeneratorOptions())
    End Sub

End Class

' The Visual Basic code generator produces the following source code for the preceeding example code:
'
' <GeneratedCodeAttribute("SampleCodeGenerator", "2.0.0.0")>  _
' Public Class Class1
' End Class
' </Snippet1>
