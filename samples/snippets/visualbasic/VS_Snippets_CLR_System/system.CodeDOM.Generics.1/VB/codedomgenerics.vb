'<Snippet1>
Imports System.CodeDom
Imports System.CodeDom.Compiler
Imports System.Collections
Imports System.Collections.Specialized
Imports System.IO
Imports System.Reflection
Imports System.Text.RegularExpressions
Imports System.Globalization
Imports System.Collections.Generic


Class CodeDomGenericsDemo

    Shared Sub Main()
        Try
            CreateGenericsCode("vb", "Generic.vb", "GenericVB.exe")
        Catch e As Exception
            LogMessage(("Unexpected Exception:" + e.ToString()))
        End Try

    End Sub 'Main


    Shared Sub CreateGenericsCode(ByVal providerName As String, ByVal sourceFileName As String, ByVal assemblyName As String)

        Dim provider As CodeDomProvider = CodeDomProvider.CreateProvider(providerName)

        LogMessage("Building CodeDOM graph...")

        Dim cu As New CodeCompileUnit()

        CreateGraph(provider, cu)

        Dim sw As New StringWriter()

        LogMessage("Generating code...")
        provider.GenerateCodeFromCompileUnit(cu, sw, Nothing)

        Dim output As String = sw.ToString()
        output = Regex.Replace(output, "Runtime version:[^" + vbCr + vbLf + "]*", "Runtime version omitted for demo")

        LogMessage("Displaying source code...")
        LogMessage(output)

        LogMessage("Writing source code to file...")
        Dim s As Stream = File.Open(sourceFileName, FileMode.Create)
        Dim t As New StreamWriter(s)
        t.Write(output)
        t.Close()
        s.Close()

        Dim opt As New CompilerParameters(New String() {"System.dll", "System.Xml.dll", "System.Windows.Forms.dll", "System.Data.dll", "System.Drawing.dll"})
        opt.GenerateExecutable = False
        opt.TreatWarningsAsErrors = True
        opt.IncludeDebugInformation = True
        opt.GenerateInMemory = True

        Dim results As CompilerResults

        LogMessage(("Compiling with provider " + providerName))
        results = provider.CompileAssemblyFromFile(opt, sourceFileName)

        OutputResults(results)
        If results.NativeCompilerReturnValue <> 0 Then
            LogMessage("")
            LogMessage("Compilation failed.")
        Else
            LogMessage("")
            LogMessage("Demo completed successfully.")
        End If
        File.Delete(sourceFileName)

    End Sub 'CreateGenericsCode


    ' Create a CodeDOM graph.
    Shared Sub CreateGraph(ByVal provider As CodeDomProvider, ByVal cu As CodeCompileUnit)
        '<Snippet8>
        ' Determine if the generator supports generics.
        If Not provider.Supports(GeneratorSupport.GenericTypeReference Or GeneratorSupport.GenericTypeDeclaration) Then
            ' Return if the generator does not support generics.
            Return
        End If
        '</Snippet8>
        Dim ns As New CodeNamespace("DemoNamespace")
        ns.Imports.Add(New CodeNamespaceImport("System"))
        ns.Imports.Add(New CodeNamespaceImport("System.Collections.Generic"))
        cu.Namespaces.Add(ns)

        ' Declare a generic class.
        Dim class1 As New CodeTypeDeclaration()
        class1.Name = "MyDictionary"
        class1.BaseTypes.Add( _
            New CodeTypeReference("Dictionary", _
                New CodeTypeReference() {New CodeTypeReference("TKey"), _
                    New CodeTypeReference("TValue")}))
        '<Snippet2>
        '<Snippet10>
        Dim kType As New CodeTypeParameter("TKey")
        '</Snippet2>
        '<Snippet3>
        kType.HasConstructorConstraint = True
        '</Snippet3>
        '<Snippet4>
        kType.Constraints.Add(New CodeTypeReference(GetType(IComparable)))
        '</Snippet4>
        '<Snippet5>
        kType.CustomAttributes.Add _
            (New CodeAttributeDeclaration("System.ComponentModel.DescriptionAttribute", _
                New CodeAttributeArgument(New CodePrimitiveExpression("KeyType"))))
        '</Snippet5>
        Dim iComparableT As New CodeTypeReference("IComparable")
        iComparableT.TypeArguments.Add(New CodeTypeReference(kType))

        kType.Constraints.Add(iComparableT)

        Dim vType As New CodeTypeParameter("TValue")
        vType.Constraints.Add(New CodeTypeReference(GetType(IList(Of System.String))))
        vType.CustomAttributes.Add _
            (New CodeAttributeDeclaration("System.ComponentModel.DescriptionAttribute", _
                New CodeAttributeArgument(New CodePrimitiveExpression("ValueType"))))

        class1.TypeParameters.Add(kType)
        class1.TypeParameters.Add(vType)
        '</Snippet10>
        ns.Types.Add(class1)

        '<Snippet6>
        ' Declare a generic method.
        Dim printMethod As New CodeMemberMethod()
        Dim sType As New CodeTypeParameter("S")
        sType.HasConstructorConstraint = True
        Dim tType As New CodeTypeParameter("T")
        tType.HasConstructorConstraint = True

        printMethod.Name = "Print"
        printMethod.TypeParameters.Add(sType)
        printMethod.TypeParameters.Add(tType)

        '</Snippet6>
        '<Snippet7>
        printMethod.Statements.Add(ConsoleWriteLineStatement _
            (New CodeDefaultValueExpression(New CodeTypeReference("T"))))
        printMethod.Statements.Add(ConsoleWriteLineStatement _
            (New CodeDefaultValueExpression(New CodeTypeReference("S"))))
        '</Snippet7>
        printMethod.Attributes = MemberAttributes.Public
        class1.Members.Add(printMethod)

        Dim class2 As New CodeTypeDeclaration()
        class2.Name = "Demo"

        Dim methodMain As New CodeEntryPointMethod()

        Dim [myClass] As New CodeTypeReference("MyDictionary", _
            New CodeTypeReference() {New CodeTypeReference(GetType(Integer)), _
                New CodeTypeReference("List", _
                    New CodeTypeReference() {New CodeTypeReference("System.String")})})

        methodMain.Statements.Add(New CodeVariableDeclarationStatement([myClass], _
            "dict", New CodeObjectCreateExpression([myClass])))

        methodMain.Statements.Add(ConsoleWriteLineStatement _
            (New CodePropertyReferenceExpression _
                (New CodeVariableReferenceExpression("dict"), "Count")))

        '<Snippet9>
        methodMain.Statements.Add _
            (New CodeExpressionStatement _
                (New CodeMethodInvokeExpression _
                    (New CodeMethodReferenceExpression _
                        (New CodeVariableReferenceExpression("dict"), _
                            "Print", New CodeTypeReference() _
                                    {New CodeTypeReference("System.Decimal"), _
                                        New CodeTypeReference("System.Int32")}), _
                                            New CodeExpression(-1) {})))
        '</Snippet9>
        Dim longTypeName As String = GetType( _
            System.Collections.Generic.Dictionary(Of Integer, _
                System.Collections.Generic.List(Of String))()).FullName

        Dim longType As New CodeTypeReference(longTypeName)

        methodMain.Statements.Add(New CodeVariableDeclarationStatement _
            (longType, "dict2", New CodeArrayCreateExpression _
                (longType, New CodeExpression(0) {New CodePrimitiveExpression(Nothing)})))

        methodMain.Statements.Add(ConsoleWriteLineStatement(New CodePropertyReferenceExpression(New CodeVariableReferenceExpression("dict2"), "Length")))

        class2.Members.Add(methodMain)
        ns.Types.Add(class2)

    End Sub 'CreateGraph


    Overloads Shared Function ConsoleWriteLineStatement(ByVal exp As CodeExpression) As CodeStatement
        Return New CodeExpressionStatement(New CodeMethodInvokeExpression _
            (New CodeMethodReferenceExpression _
                (New CodeTypeReferenceExpression _
                    (New CodeTypeReference("Console")), "WriteLine"), _
                        New CodeExpression() {exp}))

    End Function 'ConsoleWriteLineStatement


    Overloads Shared Function ConsoleWriteLineStatement(ByVal [text] As String) As CodeStatement
        Return ConsoleWriteLineStatement(New CodePrimitiveExpression([text]))

    End Function 'ConsoleWriteLineStatement

    Shared Sub LogMessage(ByVal [text] As String)
        Console.WriteLine([text])

    End Sub 'LogMessage


    Shared Sub OutputResults(ByVal results As CompilerResults)
        LogMessage(("NativeCompilerReturnValue=" + results.NativeCompilerReturnValue.ToString()))
        Dim s As String
        For Each s In results.Output
            LogMessage(s)
        Next s

    End Sub 'OutputResults
End Class 'CodeDomGenericsDemo 
'
' This example generates the following code:
'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.1434
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

'Option Strict Off
'Option Explicit On

'Imports System
'Imports System.Collections.Generic

'Namespace DemoNamespace

'    Public Class MyDictionary(Of TKey As  {System.IComparable, IComparable(Of TKey), New}, TValue As System.Collections.
'Generic.IList(Of String))
'        Inherits Dictionary(Of TKey, TValue)

'        Public Overridable Sub Print(Of S As New, T As New)()
'            Console.WriteLine(CType(Nothing, T))
'            Console.WriteLine(CType(Nothing, S))
'        End Sub
'    End Class

'    Public Class Demo

'        Public Shared Sub Main()
'            Dim dict As MyDictionary(Of Integer, List(Of String)) = New MyDictionary(Of Integer, List(Of String))
'            Console.WriteLine(dict.Count)
'            dict.Print(Of Decimal, Integer)()
'            Dim dict2() As System.Collections.Generic.Dictionary(Of Integer, System.Collections.Generic.List(Of String))
' = New System.Collections.Generic.Dictionary(Of Integer, System.Collections.Generic.List(Of String))() {Nothing}
'            Console.WriteLine(dict2.Length)
'        End Sub
'    End Class
'End Namespace
'</Snippet1>