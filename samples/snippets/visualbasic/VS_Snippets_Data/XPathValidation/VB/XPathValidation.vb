'<snippet1>
Imports System
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.XPath

Class XPathValidation

    Shared Sub Main()

        Try

            Dim settings As XmlReaderSettings = New XmlReaderSettings()
            settings.Schemas.Add("http://www.contoso.com/books", "contosoBooks.xsd")
            settings.ValidationType = ValidationType.Schema

            Dim reader As XmlReader = XmlReader.Create("contosoBooks.xml", settings)
            Dim document As XmlDocument = New XmlDocument()
            document.Load(reader)

            Dim eventHandler As ValidationEventHandler = New ValidationEventHandler(AddressOf ValidationEventHandler)

            ' the following call to Validate succeeds.
            document.Validate(eventHandler)

            ' add a node so that the document is no longer valid
            Dim navigator As XPathNavigator = document.CreateNavigator()
            navigator.MoveToFollowing("price", "http://www.contoso.com/books")
            Dim writer As XmlWriter = navigator.InsertAfter()
            writer.WriteStartElement("anotherNode", "http://www.contoso.com/books")
            writer.WriteEndElement()
            writer.Close()

            ' the document will now fail to successfully validate
            document.Validate(eventHandler)

        Catch ex As Exception

            Console.WriteLine(ex.Message)

        End Try

    End Sub

    Shared Sub ValidationEventHandler(ByVal sender As Object, ByVal e As ValidationEventArgs)

        Select Case e.Severity
            Case XmlSeverityType.Error
                Console.WriteLine("Error: {0}", e.Message)
            Case XmlSeverityType.Warning
                Console.WriteLine("Warning {0}", e.Message)
        End Select

    End Sub

End Class
'</snippet1>

