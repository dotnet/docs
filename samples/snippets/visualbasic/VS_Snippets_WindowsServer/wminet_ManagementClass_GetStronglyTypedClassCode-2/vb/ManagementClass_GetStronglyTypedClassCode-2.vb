'<Snippet1>
Imports System
Imports System.Management
Imports System.CodeDom
Imports System.IO
Imports System.CodeDom.Compiler
Imports System.Security.Permissions

Namespace Sample

    <EnvironmentPermissionAttribute(SecurityAction.LinkDemand)> _
    Public Class GenerateVBCode

        <EnvironmentPermissionAttribute(SecurityAction.LinkDemand)> _
                Public Overloads Shared Function _
                    Main(ByVal args() As String) As Integer

            Dim strFilePath As String
            strFilePath = "C:\temp\LogicalDisk.vb"
            Dim ClsDom As CodeTypeDeclaration

            Dim cls1 As ManagementClass
            cls1 = New ManagementClass( _
                Nothing, "Win32_LogicalDisk", Nothing)
            ClsDom = cls1.GetStronglyTypedClassCode(False, False)


            Dim cg As ICodeGenerator
            cg = (New VBCodeProvider).CreateGenerator()
            Dim cn As CodeNamespace
            cn = New CodeNamespace("TestNamespace")

            ' Add any imports to the code
            cn.Imports.Add( _
                New CodeNamespaceImport("System"))
            cn.Imports.Add( _
                New CodeNamespaceImport("System.ComponentModel"))
            cn.Imports.Add( _
                New CodeNamespaceImport("System.Management"))
            cn.Imports.Add( _
                New CodeNamespaceImport("System.Collections"))

            ' Add class to the namespace
            cn.Types.Add(ClsDom)

            ' Now create the filestream (output file)
            Dim tw As TextWriter
            tw = New StreamWriter(New _
                FileStream(strFilePath, FileMode.Create))

            Dim options As New CodeGeneratorOptions
            ' And write it to the file
            cg.GenerateCodeFromNamespace( _
            cn, tw, options)

            tw.Close()

        End Function
    End Class
End Namespace
'</Snippet1>