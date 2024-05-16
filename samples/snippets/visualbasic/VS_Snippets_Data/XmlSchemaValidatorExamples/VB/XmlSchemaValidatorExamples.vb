'<snippet1>
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization
Imports System.Collections


Namespace Microsoft.Samples.Xml.Schema

    Class XmlSchemaValidatorExamples

        Shared Sub Main()

            ' The XML document to deserialize into the XmlSerializer object.
            Dim reader As XmlReader = XmlReader.Create("contosoBooks.xml")

            ' The XmlSerializer object.
            Dim serializer As XmlSerializer = New XmlSerializer(GetType(ContosoBooks))
            Dim books As ContosoBooks = CType(serializer.Deserialize(reader), ContosoBooks)

            ' The XmlSchemaSet object containing the schema used to validate the XML document.
            Dim schemaSet As XmlSchemaSet = New XmlSchemaSet()
            schemaSet.Add("http://www.contoso.com/books", "contosoBooks.xsd")

            ' The XmlNamespaceManager object used to handle namespaces.
            Dim manager As XmlNamespaceManager = New XmlNamespaceManager(reader.NameTable)

            ' Assign a ValidationEventHandler to handle schema validation warnings and errors.
            Dim validator As XmlSchemaValidator = New XmlSchemaValidator(reader.NameTable, schemaSet, manager, XmlSchemaValidationFlags.None)
            'validator.ValidationEventHandler += New ValidationEventHandler(SchemaValidationEventHandler)
            AddHandler validator.ValidationEventHandler, AddressOf SchemaValidationEventHandler

            ' Initialize the XmlSchemaValidator object.
            validator.Initialize()

            ' Validate the bookstore element, verify that all required attributes are present
            ' and prepare to validate child content.
            validator.ValidateElement("bookstore", "http://www.contoso.com/books", Nothing)

            validator.GetUnspecifiedDefaultAttributes(New ArrayList())
            validator.ValidateEndOfAttributes(Nothing)

            ' Get the next expected element in the bookstore context.
            Dim particles() As XmlSchemaParticle = validator.GetExpectedParticles()
            Dim nextElement As XmlSchemaElement = particles(0)
            Console.WriteLine("Expected Element: '{0}'", nextElement.Name)

            For Each book As BookType In books.book
                ' Validate the book element.
                validator.ValidateElement("book", "http://www.contoso.com/books", Nothing)

                ' Get the expected attributes for the book element.
                Console.Write(vbCrLf & "Expected attributes: ")
                Dim attributes() As XmlSchemaAttribute = validator.GetExpectedAttributes()
                For Each attribute As XmlSchemaAttribute In attributes
                    Console.Write("'{0}' ", attribute.Name)
                Next
                Console.WriteLine()

                ' Validate the genre attribute and display its post schema validation information.
                If Not book.Genre Is Nothing Then
                    validator.ValidateAttribute("genre", "", book.Genre, schemaInfo)
                End If
                DisplaySchemaInfo()

                ' Validate the publicationdate attribute and display its post schema validation information.
                If Not book.PublicationDate = Nothing Then
                    validator.ValidateAttribute("publicationdate", "", dateTimeGetter(book.PublicationDate), schemaInfo)
                End If
                DisplaySchemaInfo()

                ' Validate the ISBN attribute and display its post schema validation information.
                If Not book.Isbn Is Nothing Then
                    validator.ValidateAttribute("ISBN", "", book.Isbn, schemaInfo)
                End If
                DisplaySchemaInfo()

                ' After validating all the attributes for the current element with ValidateAttribute method,
                ' you must call GetUnspecifiedDefaultAttributes to validate the default attributes.
                validator.GetUnspecifiedDefaultAttributes(New ArrayList())

                ' Verify that all required attributes of the book element are present
                ' and prepare to validate child content.
                validator.ValidateEndOfAttributes(Nothing)

                ' Validate the title element and its content.
                validator.ValidateElement("title", "http://www.contoso.com/books", Nothing)
                validator.ValidateEndElement(Nothing, book.Title)

                ' Validate the author element, verify that all required attributes are present
                ' and prepare to validate child content.
                validator.ValidateElement("author", "http://www.contoso.com/books", Nothing)

                validator.GetUnspecifiedDefaultAttributes(New ArrayList())
                validator.ValidateEndOfAttributes(Nothing)

                If Not book.Author.Name Is Nothing Then
                    ' Validate the name element and its content.
                    validator.ValidateElement("name", "http://www.contoso.com/books", Nothing)
                    validator.ValidateEndElement(Nothing, book.Author.Name)
                End If

                If Not book.Author.FirstName Is Nothing Then
                    ' Validate the first-name element and its content.
                    validator.ValidateElement("first-name", "http://www.contoso.com/books", Nothing)
                    validator.ValidateEndElement(Nothing, book.Author.FirstName)

                End If

                If Not book.Author.LastName Is Nothing Then
                    ' Validate the last-name element and its content.
                    validator.ValidateElement("last-name", "http://www.contoso.com/books", Nothing)
                    validator.ValidateEndElement(Nothing, book.Author.LastName)
                End If

                ' Validate the content of the author element.
                validator.ValidateEndElement(Nothing)

                ' Validate the price element and its content.
                validator.ValidateElement("price", "http://www.contoso.com/books", Nothing)
                validator.ValidateEndElement(Nothing, book.Price)

                ' Validate the content of the book element.
                validator.ValidateEndElement(Nothing)
            Next

            ' Validate the content of the bookstore element.
            validator.ValidateEndElement(Nothing)

            ' Close the XmlReader object.
            reader.Close()

        End Sub

        Shared schemaInfo As XmlSchemaInfo = New XmlSchemaInfo()
        Shared dateTimeGetterContent As Object

        Shared Function dateTimeGetterHandle() As Object

            Return dateTimeGetterContent

        End Function

        Shared Function dateTimeGetter(ByVal dateTime As DateTime) As XmlValueGetter

            dateTimeGetterContent = dateTime
            Return New XmlValueGetter(AddressOf dateTimeGetterHandle)

        End Function

        Shared Sub DisplaySchemaInfo()

            If Not schemaInfo.SchemaElement Is Nothing Then
                Console.WriteLine("Element '{0}' with type '{1}' is '{2}'", schemaInfo.SchemaElement.Name, schemaInfo.SchemaType, schemaInfo.Validity)
            ElseIf Not schemaInfo.SchemaAttribute Is Nothing Then
                Console.WriteLine("Attribute '{0}' with type '{1}' is '{2}'", schemaInfo.SchemaAttribute.Name, schemaInfo.SchemaType, schemaInfo.Validity)
            End If

        End Sub

        Shared Sub SchemaValidationEventHandler(ByVal sender As Object, ByVal e As ValidationEventArgs)

            Select Case e.Severity
                Case XmlSeverityType.Error
                    Console.WriteLine(vbCrLf & "Error: {0}", e.Message)
                    Exit Sub
                Case XmlSeverityType.Warning
                    Console.WriteLine(vbCrLf & "Warning: {0}", e.Message)
                    Exit Sub
            End Select

        End Sub

    End Class

    <XmlRootAttribute("bookstore", Namespace:="http://www.contoso.com/books", IsNullable:=False)> _
    Public Class ContosoBooks

        <XmlElementAttribute("book")> _
        Public book() As BookType

    End Class

    Public Class BookType

        <XmlAttributeAttribute("genre")> _
        Public Genre As String

        <XmlAttributeAttribute("publicationdate", DataType:="date")> _
        Public PublicationDate As DateTime

        <XmlAttributeAttribute("ISBN")> _
        Public Isbn As String

        <XmlElementAttribute("title")> _
        Public Title As String

        <XmlElementAttribute("author")> _
        Public Author As BookAuthor

        <XmlElementAttribute("price")> _
        Public Price As Decimal

    End Class

    Public Class BookAuthor

        <XmlElementAttribute("name")> _
        Public Name As String

        <XmlElementAttribute("first-name")> _
        Public FirstName As String

        <XmlElementAttribute("last-name")> _
        Public LastName As String

    End Class

End Namespace
'</snippet1>
