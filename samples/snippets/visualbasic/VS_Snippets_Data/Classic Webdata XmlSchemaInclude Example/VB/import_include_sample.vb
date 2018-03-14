'<snippet1>
Imports System
Imports System.Collections
Imports System.IO
Imports System.Xml
Imports System.Xml.Xsl
Imports System.Xml.Schema


Public Class ImportIncludeSample

    Private Shared Sub ValidationCallBack(ByVal sender As Object, ByVal args As ValidationEventArgs)

        If args.Severity = XmlSeverityType.Warning Then
            Console.Write("WARNING: ")
        Else
            If args.Severity = XmlSeverityType.Error Then
                Console.Write("ERROR: ")
            End If
        End If
        Console.WriteLine(args.Message)
    End Sub 'ValidationCallBack


    Public Shared Sub Main()

        Dim schema As New XmlSchema()
        schema.ElementFormDefault = XmlSchemaForm.Qualified
        schema.TargetNamespace = "http://www.w3.org/2001/05/XMLInfoset"

        ' <xs:import namespace="http://www.example.com/IPO" />             
        Dim import As New XmlSchemaImport()
        import.Namespace = "http://www.example.com/IPO"
        schema.Includes.Add(import)

        ' <xs:include schemaLocation="example.xsd" />     
        Dim include As New XmlSchemaInclude()
        include.SchemaLocation = "example.xsd"
        schema.Includes.Add(include)

        Dim schemaSet As New XmlSchemaSet()
        AddHandler schemaSet.ValidationEventHandler, AddressOf ValidationCallBack

        schemaSet.Add(schema)
        schemaSet.Compile()

        Dim compiledSchema As XmlSchema = Nothing

        For Each schema1 As XmlSchema In schemaSet.Schemas()
            compiledSchema = schema1
        Next

        Dim nsmgr As XmlNamespaceManager = New XmlNamespaceManager(New NameTable())
        nsmgr.AddNamespace("xs", "http://www.w3.org/2001/XMLSchema")
        compiledSchema.Write(Console.Out, nsmgr)

    End Sub 'Main 
End Class 'ImportIncludeSample ' Main() 

'ImportIncludeSample
'</snippet1>