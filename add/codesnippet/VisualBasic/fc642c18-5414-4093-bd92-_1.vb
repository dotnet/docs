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