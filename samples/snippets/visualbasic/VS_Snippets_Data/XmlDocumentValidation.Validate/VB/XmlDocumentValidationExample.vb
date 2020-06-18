'<snippet1>
Imports System.Xml
Imports System.Xml.Schema

Class XmlDocumentValidationExample

    Shared Sub Main()

        Try

            ' Create a new XmlDocument instance and load
            ' the XML document into the DOM.
            Dim document As XmlDocument = New XmlDocument()
            document.Load("contosoBooks.xml")

            ' Add the XML schema for the XML document to the
            ' Schemas property of the XmlDocument.
            document.Schemas.Add("http://www.contoso.com/books", "contosoBooks.xsd")

            ' Validate the XML document loaded into the DOM.
            document.Validate(AddressOf ValidationEventHandler)

            ' Make an invalid change to the first and last 
            ' price elements in the XML document, and write
            ' the XmlSchemaInfo values assigned to the price
            ' element during validation to the console.
            Dim manager As XmlNamespaceManager = New XmlNamespaceManager(document.NameTable)
            manager.AddNamespace("bk", "http://www.contoso.com/books")

            Dim priceNode As XmlNode = document.SelectSingleNode("/bk:bookstore/bk:book/bk:price", manager)

            Console.WriteLine("SchemaInfo.IsDefault: {0}", priceNode.SchemaInfo.IsDefault)
            Console.WriteLine("SchemaInfo.IsNil: {0}", priceNode.SchemaInfo.IsNil)
            Console.WriteLine("SchemaInfo.SchemaElement: {0}", priceNode.SchemaInfo.SchemaElement)
            Console.WriteLine("SchemaInfo.SchemaType: {0}", priceNode.SchemaInfo.SchemaType)
            Console.WriteLine("SchemaInfo.Validity: {0}", priceNode.SchemaInfo.Validity)

            priceNode.InnerXml = "A"

            Dim priceNodes As XmlNodeList = document.SelectNodes("/bk:bookstore/bk:book/bk:price", manager)
            Dim lastprice As XmlNode = priceNodes(priceNodes.Count - 1)

            lastprice.InnerXml = "B"

            ' Validate the XML document with the invalid changes.
            ' The invalid changes cause schema validation errors.
            document.Validate(AddressOf ValidationEventHandler)

            ' Correct the invalid change to the first price element.
            priceNode.InnerXml = "8.99"

            ' Validate only the first book element. The last book
            ' element is invalid, but not included in validation.
            Dim bookNode As XmlNode = document.SelectSingleNode("/bk:bookstore/bk:book", manager)
            document.Validate(AddressOf ValidationEventHandler, bookNode)

        Catch ex As XmlException
            Console.WriteLine("XmlDocumentValidationExample.XmlException: {0}", ex.Message)

        Catch ex As XmlSchemaValidationException
            Console.WriteLine("XmlDocumentValidationExample.XmlSchemaValidationException: {0}", ex.Message)

        Catch ex As Exception
            Console.WriteLine("XmlDocumentValidationExample.Exception: {0}", ex.Message)

        End Try

    End Sub

    Shared Sub ValidationEventHandler(ByVal sender As Object, ByVal args As ValidationEventArgs)

        If args.Severity = XmlSeverityType.Warning Then
            Console.Write(vbCrLf & "WARNING: ")
        Else
            If args.Severity = XmlSeverityType.Error Then
                Console.Write(vbCrLf & "ERROR: ")
            End If
        End If
        Console.WriteLine(args.Message)

    End Sub

End Class
'</snippet1>
