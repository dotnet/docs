'<snippet1>
Imports System.Xml
Imports System.Xml.Schema

Class XmlSchemaSetExample

    Shared Sub Main()

        Dim booksSettings As XmlReaderSettings = New XmlReaderSettings()
        booksSettings.Schemas.Add("http://www.contoso.com/books", "books.xsd")
        booksSettings.ValidationType = ValidationType.Schema
        AddHandler booksSettings.ValidationEventHandler, New ValidationEventHandler(AddressOf booksSettingsValidationEventHandler)

        Dim books As XmlReader = XmlReader.Create("books.xml", booksSettings)

        While books.Read()

        End While

    End Sub

    Shared Sub booksSettingsValidationEventHandler(ByVal sender As Object, ByVal e As ValidationEventArgs)

        If e.Severity = XmlSeverityType.Warning Then
            Console.Write("WARNING: ")
            Console.WriteLine(e.Message)

        ElseIf e.Severity = XmlSeverityType.Error Then
            Console.Write("ERROR: ")
            Console.WriteLine(e.Message)
        End If

    End Sub

End Class
'</snippet1>
