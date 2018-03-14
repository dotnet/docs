' <Snippet1>
' <Snippet2>
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.IO
Imports System.Text
Imports System.Web
Imports System.Web.Compilation
Imports System.CodeDom.Compiler
Imports System.CodeDom
Imports System.Security
Imports System.Security.Permissions

<PermissionSet(SecurityAction.Demand, Unrestricted := true)> _
Public Class SampleBuildProvider
    Inherits BuildProvider

    Protected _compilerType As CompilerType = Nothing

    Public Sub New()
        _compilerType = GetDefaultCompilerType()
    End Sub

    ' Return the internal CompilerType member 
    ' defined in this implementation.
    Public Overrides ReadOnly Property CodeCompilerType() As CompilerType
        Get
            CodeCompilerType = _compilerType
        End Get
    End Property


    ' Define the build provider implementation of the GenerateCode method.
    Public Overrides Sub GenerateCode(ByVal assemBuilder As AssemblyBuilder)
        ' Generate a code compile unit, and add it to
        ' the assembly builder.

        Dim tw As TextWriter = assemBuilder.CreateCodeFile(Me)
        If Not tw Is Nothing Then
            Try
                ' Generate the code compile unit from the virtual path.
                Dim compileUnit As CodeCompileUnit = _
                        SampleClassGenerator.BuildCompileUnitFromPath(VirtualPath)

                ' Generate the source for the code compile unit, 
                ' and write it to a file specified by the assembly builder.
                Dim provider As CodeDomProvider = assemBuilder.CodeDomProvider
                provider.GenerateCodeFromCompileUnit(compileUnit, tw, Nothing)
            Finally
                tw.Close()
            End Try

        End If
    End Sub

    Public Overrides Function GetGeneratedType(ByVal results As CompilerResults) As System.Type
        Dim typeName As String = SampleClassGenerator.TypeName

        Return results.CompiledAssembly.GetType(typeName)
    End Function

End Class
' </Snippet2>

' Define a class that generates a type using CodeDOM.
Public Class SampleClassGenerator

    Private Shared genNamespace As String = "HelloWorldSample"
    Private Shared genClassName As String = "HelloWorldClass"
    Private Shared genTypeName As String = genNamespace & "." & genClassName

    ' Define the public property that returns the type name.
    Public Shared ReadOnly Property TypeName() As String
        Get
            TypeName = genTypeName
        End Get
    End Property

    ' Build a Hello World program graph using System.CodeDom types.
    ' For simplicity, this method builds a fixed code compile unit.
    ' In most scenarios, this method would use the virtual path,
    ' and build a code compile unit from the parsed file.

    Public Shared Function BuildCompileUnitFromPath(ByVal virtualPath As String) As CodeCompileUnit
        ' Create a new CodeCompileUnit to contain the program graph
        Dim compileUnit As CodeCompileUnit = New CodeCompileUnit()

        ' Declare the HelloWorldSample namespace.
        Dim helloNamespace As CodeNamespace = New CodeNamespace("HelloWorldSample")
        ' Add the new namespace to the compile unit.
        compileUnit.Namespaces.Add(helloNamespace)

        ' Add the new namespace import for the System namespace.
        helloNamespace.Imports.Add(New CodeNamespaceImport("System"))

        ' Declare a class named HelloWorldClass.
        Dim helloClass As CodeTypeDeclaration = New CodeTypeDeclaration("HelloWorldClass")

        ' Add the HelloWorldClass to the namespace.
        helloNamespace.Types.Add(helloClass)

        ' Declare the Main method of the class.
        Dim helloMain As CodeEntryPointMethod = New CodeEntryPointMethod()

        ' Add the code entry point method to the Members
        ' collection of the type.
        helloClass.Members.Add(helloMain)

        ' Create a type reference for the System.Console class.
        Dim csSystemConsoleType As CodeTypeReferenceExpression = New CodeTypeReferenceExpression("System.Console")

        ' Build Console.WriteLine("Hello World!").
        Dim cs1 As CodeMethodInvokeExpression = New CodeMethodInvokeExpression( _
            csSystemConsoleType, "WriteLine", _
            New CodePrimitiveExpression("Hello World!"))

        ' Add the WriteLine call to the statement collection.
        helloMain.Statements.Add(cs1)

        ' Build another Console.WriteLine statement.
        Dim cs2 As CodeMethodInvokeExpression = New CodeMethodInvokeExpression( _
            csSystemConsoleType, "WriteLine", _
            New CodePrimitiveExpression("Press the Enter key to continue."))

        ' Add the new code statement.
        helloMain.Statements.Add(cs2)

        ' Build a call to Console.ReadLine.
        Dim csReadLine As CodeMethodInvokeExpression = New CodeMethodInvokeExpression( _
            csSystemConsoleType, "ReadLine")

        ' Add the new code statement.
        helloMain.Statements.Add(csReadLine)

        Return compileUnit
    End Function

End Class

' </Snippet1>
