' <Snippet1>
Imports System
Imports System.CodeDom
Imports System.CodeDom.Compiler
Imports Microsoft.CSharp

Namespace CompilerError_Example
    _
    Class Class1

        Shared Sub Main()
            ' Output some program information using Console.WriteLine.
            Console.WriteLine("This program compiles a CodeDOM program that incorrectly declares multiple data")
            Console.WriteLine("types to demonstrate handling compiler errors programatically.")
            Console.WriteLine("")

            ' Compile the CodeCompileUnit retrieved from the GetCompileUnit() method.
            Dim provider As CodeDomProvider
            provider = CodeDomProvider.CreateProvider("CSharp")

            ' Initialize a CompilerParameters with the options for compilation.
            Dim assemblies() As String = New [String]() {"System.dll"}
            Dim options As New CompilerParameters(assemblies, "output.exe")

            ' Compile the CodeDOM graph and store the results in a CompilerResults.
            Dim results As CompilerResults = provider.CompileAssemblyFromDom(options, GetCompileUnit())

            ' Compilation produces errors. Print out each error.
            Console.WriteLine("Listing errors from compilation: ")
            Console.WriteLine("")
            Dim i As Integer
            For i = 0 To results.Errors.Count - 1
                Console.WriteLine(results.Errors(i).ToString())
            Next i
        End Sub

        Public Shared Function GetCompileUnit() As CodeCompileUnit
            ' Create a compile unit to contain a CodeDOM graph.
            Dim cu As New CodeCompileUnit()

            ' Create a namespace named TestSpace.
            Dim cn As New CodeNamespace("TestSpace")

            ' Declare a new type named TestClass.
            Dim cd As New CodeTypeDeclaration("TestClass")

            ' Declare a new member string field named TestField.
            Dim cmf As New CodeMemberField("System.String", "TestField")

            ' Add the field to the type.
            cd.Members.Add(cmf)

            ' Declare a new member method named TestMethod.
            Dim cm As New CodeMemberMethod()
            cm.Name = "TestMethod"

            ' Declare a string variable named TestVariable.
            Dim cvd As New CodeVariableDeclarationStatement("System.String1", "TestVariable")
            cm.Statements.Add(cvd)

            ' Cast the TestField reference expression to string and assign it to the TestVariable.
            Dim ca As New CodeAssignStatement(New CodeVariableReferenceExpression("TestVariable"), New CodeCastExpression("System.String2", New CodeFieldReferenceExpression(New CodeThisReferenceExpression(), "TestField")))

            ' This code can be used to generate the following code in C#:
            '            TestVariable = ((string)(this.TestField));

            cm.Statements.Add(ca)
            ' Add the TestMethod member to the TestClass type.
            cd.Members.Add(cm)

            ' Add the TestClass type to the namespace.
            cn.Types.Add(cd)
            ' Add the TestSpace namespace to the compile unit.
            cu.Namespaces.Add(cn)
            Return cu
        End Function
    End Class
End Namespace
' </Snippet1>