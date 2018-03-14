Imports System
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Xml.Schema
Imports System.Xml.Serialization
Imports System.CodeDom
Imports System.CodeDom.Compiler

Public Class Test
    Shared Sub Main() 
        Console.WriteLine("started")
    
    End Sub 'Main 
End Class 'Test


' Replace MyFakeAbstract with System.Xml.Serialization.Advanced.SchemaImporterExtension
' when it becomes integrated into Main. This fake class is only to get the
' implementation to compile.
MustInherit Public Class MyFakeAbstract
    Public Overridable Function ImportSchemaType(ByVal name As String, ByVal ns As String, ByVal context As XmlSchemaObject, ByVal schemas As XmlSchemas, ByVal importer As XmlSchemaImporter, ByVal compileUnit As CodeCompileUnit, ByVal mainNamespace As CodeNamespace, ByVal options As CodeGenerationOptions, ByVal codeProvider As CodeDomProvider) As String 
        Return Nothing
    End Function 'ImportSchemaType 
End Class 'MyFakeAbstract

Public Class MyExtension
    Inherits MyFakeAbstract
    
    '<snippet1>
    Public Overrides Function ImportSchemaType(ByVal name As String, ByVal ns As String, ByVal context As XmlSchemaObject, ByVal schemas As XmlSchemas, ByVal importer As XmlSchemaImporter, ByVal compileUnit As CodeCompileUnit, ByVal codeNamespace As CodeNamespace, ByVal options As CodeGenerationOptions, ByVal codeGenerator As CodeDomProvider) As String 
        If name.Equals("Order") AndAlso ns.Equals("http://orders/") Then
            compileUnit.ReferencedAssemblies.Add("Order.dll")
            codeNamespace.Imports.Add(New CodeNamespaceImport("Microsoft.Samples"))           
            Return "Order"
        End If 
        
        Return Nothing
    
    End Function 'ImportSchemaType 
    '</snippet1>
End Class