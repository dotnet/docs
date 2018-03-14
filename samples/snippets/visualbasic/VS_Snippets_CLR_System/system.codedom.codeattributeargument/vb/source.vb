' <Snippet1>
Imports System
Imports System.CodeDom
Imports System.CodeDom.Compiler

Public Class CodeGenExample

    Shared Sub Main
        ' Declare a new type called Class1.
        Dim class1 as New CodeTypeDeclaration("Class1")

        ' Use attributes to mark the class as serializable and obsolete.
        Dim codeAttrDecl As New CodeAttributeDeclaration("System.Serializable")
        class1.CustomAttributes.Add(codeAttrDecl)

        Dim codeAttr As _
            New CodeAttributeArgument( new CodePrimitiveExpression("This class is obsolete."))
        codeAttrDecl = New CodeAttributeDeclaration("System.Obsolete", codeAttr)
        class1.CustomAttributes.Add(codeAttrDecl)

        ' Create a Visual Basic code provider
        Dim provider As CodeDomProvider = CodeDomProvider.CreateProvider("VisualBasic")

        ' Generate code and send the output to the console
        provider.GenerateCodeFromType(class1, Console.Out, New CodeGeneratorOptions())
    End Sub

End Class

' The Visual Basic code generator produces the following source code for the preceeding example code:
'
' <System.Serializable(),  _
'  System.Obsolete("This class is obsolete.")>  _
' Public Class Class1
' End Class
' </Snippet1>
