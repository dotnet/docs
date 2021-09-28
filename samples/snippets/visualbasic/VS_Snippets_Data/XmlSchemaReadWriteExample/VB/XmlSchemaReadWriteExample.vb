'<snippet1>
Imports System.IO
Imports System.Text
Imports System.Xml
Imports System.Xml.Schema

Class XmlSchemaReadWriteExample

    Shared Sub Main()
        Try
            Dim reader As XmlTextReader = New XmlTextReader("example.xsd")
            Dim myschema As XmlSchema = XmlSchema.Read(reader, AddressOf ValidationCallback)
            myschema.Write(Console.Out)

            Dim file As FileStream = New FileStream("new.xsd", FileMode.Create, FileAccess.ReadWrite)
            Dim xwriter As XmlTextWriter = New XmlTextWriter(file, New UTF8Encoding())
            xwriter.Formatting = Formatting.Indented
            myschema.Write(xwriter)
        Catch e As Exception
            Console.WriteLine(e)
        End Try
    End Sub

    Shared Sub ValidationCallback(ByVal sender As Object, ByVal args As ValidationEventArgs)
        If args.Severity = XmlSeverityType.Warning Then
            Console.Write("WARNING: ")
        Else
            If args.Severity = XmlSeverityType.Error Then
                Console.Write("ERROR: ")
            End If
        End If
        Console.WriteLine(args.Message)
    End Sub
End Class
'</snippet1>
