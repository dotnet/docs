'<snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Schema

Public Class Sample

    Public Shared Sub Main()

        'Load the XmlSchemaSet.
        Dim schemaSet As New XmlSchemaSet()
        schemaSet.Add("urn:bookstore-schema", "books.xsd")

        'Validate the file using the schema stored in the schema set.
        'Any elements belonging to the namespace "urn:cd-schema" generate
        'a warning because there is no schema matching that namespace.
        Validate("store.xml", schemaSet)

    End Sub

    Shared Sub Validate(ByVal filename As String, ByVal schemaSet As XmlSchemaSet)

        Console.WriteLine()
        Console.WriteLine("\r\nValidating XML file {0}...", filename.ToString())

        Dim compiledSchema As XmlSchema = Nothing

        For Each schema As XmlSchema In schemaSet.Schemas()
            compiledSchema = schema
        Next

        Dim settings As New XmlReaderSettings()
        settings.Schemas.Add(compiledSchema)
        AddHandler settings.ValidationEventHandler, AddressOf ValidationCallBack
        settings.ValidationType = ValidationType.Schema

        'Create the schema validating reader.
        Dim vreader As XmlReader = XmlReader.Create(filename, settings)

        While (vreader.Read())

        End While

        'Close the reader.
        vreader.Close()
    End Sub

    'Display any warnings or errors.
    Private Shared Sub ValidationCallBack(ByVal sender As Object, ByVal args As ValidationEventArgs)
        If (args.Severity = XmlSeverityType.Warning) Then
            Console.WriteLine("  Warning: Matching schema not found.  No validation occurred." + args.Message)
        Else
            Console.WriteLine("  Validation error: " + args.Message)
        End If
    End Sub

End Class
'</snippet1>



