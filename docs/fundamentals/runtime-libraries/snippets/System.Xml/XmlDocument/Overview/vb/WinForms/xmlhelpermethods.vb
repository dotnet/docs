Imports System.Collections
Imports System.IO
Imports System.Xml
Imports System.Xml.Schema
Imports System.Text

Public Class XMLHelperMethods

#Region "Load and Save XML"
    '************************************************************************************
    '
    '  Loads XML from a file. If the file is not found, load XML from a string.
    '
    '************************************************************************************
    Public Function LoadDocument(ByVal generateXML As Boolean) As XmlDocument
        '<Snippet1>
        Dim doc As XmlDocument = New XmlDocument
        doc.PreserveWhitespace = True
        Try
            doc.Load("booksData.xml")
        Catch ex As System.IO.FileNotFoundException
            ' If no file is found, generate some XML.
            doc.LoadXml("<?xml version=""1.0""?> " & ControlChars.NewLine & _
                "<books xmlns=""http://www.contoso.com/books""> " & ControlChars.NewLine & _
                "  <book genre=""novel"" ISBN=""1-861001-57-8"" publicationdate=""1823-01-28""> " & ControlChars.NewLine & _
                "    <title>Pride And Prejudice</title> " & ControlChars.NewLine & _
                "    <price>24.95</price> " & ControlChars.NewLine & _
                "  </book> " & ControlChars.NewLine & _
                "  <book genre=""novel"" ISBN=""1-861002-30-1"" publicationdate=""1985-01-01""> " & ControlChars.NewLine & _
                "    <title>The Handmaid's Tale</title> " & ControlChars.NewLine & _
                "    <price>29.95</price> " & ControlChars.NewLine & _
                "  </book> " & ControlChars.NewLine & _
                "</books>")
        End Try
        '</Snippet1>
        Return doc
    End Function

    '************************************************************************************
    '
    '  Helper method that generates an XML string.
    '
    '************************************************************************************
    Private Function generateXMLString() As String
        Dim xml As String = "<?xml version=""1.0""?> " & ControlChars.NewLine & _
                "<books xmlns=""http://www.contoso.com/books""> " & ControlChars.NewLine & _
                "  <book genre=""novel"" ISBN=""1-861001-57-8"" publicationdate=""1823-01-28""> " & ControlChars.NewLine & _
                "    <title>Pride And Prejudice</title> " & ControlChars.NewLine & _
                "    <price>24.95</price> " & ControlChars.NewLine & _
                "  </book> " & ControlChars.NewLine & _
                "  <book genre=""novel"" ISBN=""1-861002-30-1"" publicationdate=""1985-01-01""> " & ControlChars.NewLine & _
                "    <title>The Handmaid's Tale</title> " & ControlChars.NewLine & _
                "    <price>29.95</price> " & ControlChars.NewLine & _
                "  </book> " & ControlChars.NewLine & _
                "  <book genre=""novel"" ISBN=""1-861001-45-3"" publicationdate=""1811-01-01""> " & ControlChars.NewLine &
                "    <title>Sense and Sensibility</title> " & ControlChars.NewLine & _
                "    <price>19.95</price> " & ControlChars.NewLine & _
                "  </book> " & ControlChars.NewLine & _
                "</books>"
        Return xml
    End Function

    '************************************************************************************
    '
    '  Summery: Loads XML from a file. If the file is not found, load XML from a string.
    '
    '************************************************************************************
    Public Sub SaveXML(ByVal doc As XmlDocument)
        doc.Save(Constants.booksFileName)
    End Sub

#End Region

#Region "Validate XML against a Schema"
    '<Snippet2>
    '************************************************************************************
    '
    '  Associate the schema with XML. Then, load the XML and validate it against
    '  the schema.
    '
    '************************************************************************************
    Public Function LoadDocumentWithSchemaValidation(ByVal generateXML As Boolean, ByVal generateSchema As Boolean) As XmlDocument
        Dim reader As XmlReader
        Dim settings As XmlReaderSettings = New XmlReaderSettings
        ' Helper method to retrieve schema.
        Dim schema As XmlSchema = getSchema(generateSchema)
        If (schema Is Nothing) Then
            Return Nothing
        End If
        settings.Schemas.Add(schema)
        AddHandler settings.ValidationEventHandler, AddressOf settings_ValidationEventHandler
        settings.ValidationFlags = (settings.ValidationFlags Or XmlSchemaValidationFlags.ReportValidationWarnings)
        settings.ValidationType = ValidationType.Schema
        Try
            reader = XmlReader.Create("booksData.xml", settings)
        Catch ex As System.IO.FileNotFoundException
            If generateXML Then
                Dim xml As String = generateXMLString()
                Dim byteArray() As Byte = Encoding.UTF8.GetBytes(xml)
                Dim stream As MemoryStream = New MemoryStream(byteArray)
                reader = XmlReader.Create(stream, settings)
            Else
                Return Nothing
            End If
        End Try
        Dim doc As XmlDocument = New XmlDocument
        doc.PreserveWhitespace = True
        doc.Load(reader)
        reader.Close()
        Return doc
    End Function

    '************************************************************************************
    '
    '  Helper method that generates an XML Schema.
    '
    '************************************************************************************
    Private Function generateXMLSchema() As String

        Dim generatedXmlSchema As String = "<?xml version=""1.0"" encoding=""utf-8""?> " & _
                "<xs:schema attributeFormDefault=""unqualified"" " & _
                "elementFormDefault=""qualified"" targetNamespace=""http://www.contoso.com/books"" " & _
                "xmlns:xs=""http://www.w3.org/2001/XMLSchema""> " & _
                "<xs:element name=""books""> " & _
                "<xs:complexType> " & _
                "<xs:sequence> " & _
                "<xs:element maxOccurs=""unbounded"" name=""book""> " & _
                "<xs:complexType> " & _
                "<xs:sequence> " & _
                "<xs:element name=""title"" type=""xs:string"" /> " & _
                "<xs:element name=""price"" type=""xs:decimal"" /> " & _
                "</xs:sequence> " & _
                "<xs:attribute name=""genre"" type=""xs:string"" use=""required"" /> " & _
                "<xs:attribute name=""publicationdate"" type=""xs:date"" use=""required"" /> " & _
                "<xs:attribute name=""ISBN"" type=""xs:string"" use=""required"" /> " & _
                "</xs:complexType> " & _
                "</xs:element> " & _
                "</xs:sequence> " & _
                "</xs:complexType> " & _
                "</xs:element> " & _
                "</xs:schema> "


        Return generatedXmlSchema

    End Function

    '************************************************************************************
    '
    '  Helper method that gets a schema
    '
    '************************************************************************************
    Private Function getSchema(ByVal generateSchema As Boolean) As XmlSchema
        Dim xs As XmlSchemaSet = New XmlSchemaSet
        Dim schema As XmlSchema
        Try
            schema = xs.Add("http://www.contoso.com/books", "booksData.xsd")
        Catch ex As System.IO.FileNotFoundException
            If generateSchema Then
                Dim xmlSchemaString As String = generateXMLSchema()
                Dim byteArray() As Byte = Encoding.UTF8.GetBytes(xmlSchemaString)
                Dim stream As MemoryStream = New MemoryStream(byteArray)
                Dim reader As XmlReader = XmlReader.Create(stream)
                schema = xs.Add("http://www.contoso.com/books", reader)
            Else
                Return Nothing
            End If
        End Try
        Return schema
    End Function

    '************************************************************************************
    '
    '  Helper method to validate the XML against the schema.
    '
    '************************************************************************************
    Private Sub validateXML(ByVal generateSchema As Boolean, ByVal doc As XmlDocument)
        If (doc.Schemas.Count = 0) Then
            ' Helper method to retrieve schema.
            Dim schema As XmlSchema = getSchema(generateSchema)
            doc.Schemas.Add(schema)
        End If
        ' Use an event handler to validate the XML node against the schema.
        doc.Validate(AddressOf settings_ValidationEventHandler)
    End Sub

    '************************************************************************************
    '
    '  Event handler that is raised when XML doesn't validate against the schema.
    '
    '************************************************************************************
    Private Sub settings_ValidationEventHandler(ByVal sender As Object, ByVal e As System.Xml.Schema.ValidationEventArgs)
        If (e.Severity = XmlSeverityType.Warning) Then
            System.Windows.Forms.MessageBox.Show(("The following validation warning occurred: " & e.Message))
        ElseIf (e.Severity = XmlSeverityType.Error) Then
            System.Windows.Forms.MessageBox.Show(("The following critical validation errors occurred: " & e.Message))
            Dim objectType As Type = sender.GetType
        End If
    End Sub
    '</Snippet2>

#End Region

#Region "Find Elements and attributes"

    '************************************************************************************
    '
    '  Search the XML tree for a specific XMLNode element by using an attribute value.
    '  Description: Must identify the namespace of the nodes and define a prefix. Also include the 
    '  prefix in the XPath string.
    '
    '************************************************************************************
    '<Snippet3>
    Public Function GetBook(ByVal uniqueAttribute As String, ByVal doc As XmlDocument) As XmlNode
        Dim nsmgr As XmlNamespaceManager = New XmlNamespaceManager(doc.NameTable)
        nsmgr.AddNamespace("bk", "http://www.contoso.com/books")
        Dim xPathString As String = ("//bk:books/bk:book[@ISBN='" _
                    & (uniqueAttribute & "']"))
        Dim xmlNode As XmlNode = doc.DocumentElement.SelectSingleNode(xPathString, nsmgr)
        Return xmlNode
    End Function
    '</Snippet3>

    '************************************************************************************
    '
    '  Get information about a specific book. Pass in an XMLNode that 
    '  represents the book and populate strings passed in by reference.
    '
    '************************************************************************************
    '<Snippet4>
    Public Sub GetBookInformation(ByRef title As String, ByRef ISBN As String, ByRef publicationDate As String, ByRef price As String, ByRef genre As String, ByVal book As XmlNode)
        Dim bookElement As XmlElement = CType(book, XmlElement)
        ' Get the attributes of a book.        
        Dim attr As XmlAttribute = bookElement.GetAttributeNode("ISBN")
        ISBN = attr.InnerXml
        attr = bookElement.GetAttributeNode("genre")
        genre = attr.InnerXml
        attr = bookElement.GetAttributeNode("publicationdate")
        publicationDate = attr.InnerXml
        ' Get the values of child elements of a book.
        title = bookElement("title").InnerText
        price = bookElement("price").InnerText
    End Sub
    '</Snippet4>

    '************************************************************************************
    '
    '  Uses filter criteria collection in the UI to retrieve specific elements and attributes.
    '
    '************************************************************************************
    Public Function ApplyFilters(ByVal conditions As ArrayList, ByVal operatorSymbols As ArrayList, ByVal values As ArrayList, ByVal doc As XmlDocument, ByVal matchString As String) As XmlNodeList
        Dim nsmgr As XmlNamespaceManager = New XmlNamespaceManager(doc.NameTable)

        nsmgr.AddNamespace("bk", "http://www.contoso.com/books")
        Dim xPathQueryString As String = "//bk:books/bk:book["
        Dim xPathQueryEnding As String = "]"
        Dim xPathQueryStrings As ArrayList = New ArrayList
        Dim booleanOperator As String
        If (matchString = "Any") Then
            booleanOperator = "or "
        Else
            booleanOperator = "and "
        End If
        Dim counter As Integer = 0
        Dim operatorArray() As String = CType(operatorSymbols.ToArray(GetType(System.String)), String())
        Dim valueArray() As String = CType(values.ToArray(GetType(System.String)), String())
        For Each condition As String In conditions
            Dim xPathQueryPart As String = ""
            Dim operatorSymbol As String = operatorArray(counter)
            Dim value As String = valueArray(counter)
            If (counter > 0) Then
                xPathQueryString = (xPathQueryString & booleanOperator)
            End If
            counter = (counter + 1)
            Select Case (condition)
                Case Constants.Title
                    Select Case (operatorSymbol)
                        Case "Contains"
                            xPathQueryPart = ("contains(bk:title,'" _
                                        & (value & "')"))
                        Case "Excludes"
                            xPathQueryPart = ("not(contains(bk:title,'" _
                                        & (value & "'))"))
                        Case "="
                            xPathQueryPart = ("bk:title='" _
                                        & (value & "'"))
                    End Select
                Case Constants.ISBN
                    Select Case (operatorSymbol)
                        Case "Contains"
                            xPathQueryPart = ("contains(@ISBN, '" _
                                        & (value & "')"))
                        Case "Excludes"
                            xPathQueryPart = ("not(contains(@ISBN, '" _
                                        & (value & "'))"))
                        Case "="
                            xPathQueryPart = ("@ISBN='" _
                                        & (value & "'"))
                    End Select
                Case Constants.PubDate
                    xPathQueryPart = ("contains(@publicationdate, '" _
                                & (value & "')"))
                Case Constants.Price
                    Select Case (operatorSymbol)
                        Case "="
                            xPathQueryPart = ("bk:price='" _
                                        & (value & "'"))
                        Case ">"
                            xPathQueryPart = ("bk:price>'" _
                                        & (value & "'"))
                        Case "<"
                            xPathQueryPart = ("bk:price<'" _
                                        & (value & "'"))
                        Case ">="
                            xPathQueryPart = ("bk:price>='" _
                                        & (value & "'"))
                        Case "<="
                            xPathQueryPart = ("bk:price<='" _
                                        & (value & "'"))
                        Case "<>"
                            xPathQueryPart = ("bk:price!='" _
                                        & (value & "'"))
                    End Select
                Case Constants.Genre
                    xPathQueryPart = ("@genre='" _
                                & (value & "'"))
            End Select
            xPathQueryString = (xPathQueryString & xPathQueryPart)
        Next
        xPathQueryString = (xPathQueryString & xPathQueryEnding)
        Dim nodeList As XmlNodeList = doc.DocumentElement.SelectNodes(xPathQueryString, nsmgr)
        Return nodeList
    End Function

#End Region

#Region "Add XML elements and attributes"
    '************************************************************************************
    '
    '  Add an element to the XML document.
    '  This method creates a new book element and saves that element to the 
    '  XMLDocument object. It addes attributes for the new element and introduces
    '  newline characters between elements fora nice readable format.
    '  
    '
    '************************************************************************************
    '<Snippet5>
    Public Function AddNewBook(ByVal genre As String, ByVal ISBN As String, ByVal misc As String, ByVal title As String, ByVal price As String, ByVal doc As XmlDocument) As XmlElement
        ' Create a new book element.
        Dim bookElement As XmlElement = doc.CreateElement("book", "http://www.contoso.com/books")

        ' Create attributes for book and append them to the book element.
        Dim attribute As XmlAttribute = doc.CreateAttribute("genre")
        attribute.Value = genre
        bookElement.Attributes.Append(attribute)

        attribute = doc.CreateAttribute("ISBN")
        attribute.Value = ISBN
        bookElement.Attributes.Append(attribute)

        attribute = doc.CreateAttribute("publicationdate")
        attribute.Value = misc
        bookElement.Attributes.Append(attribute)

        ' Create and append a child element for the title of the book.
        Dim titleElement As XmlElement = doc.CreateElement("title")
        titleElement.InnerText = title
        bookElement.AppendChild(titleElement)

        ' Introduce a newline character so that XML is nicely formatted.
        bookElement.InnerXml = bookElement.InnerXml.Replace(titleElement.OuterXml, _
                               "\n   " & titleElement.OuterXml & " " & ControlChars.NewLine + "    ")
        ' Create and append a child element for the price of the book.
        Dim priceElement As XmlElement = doc.CreateElement("price")
        priceElement.InnerText = price
        bookElement.AppendChild(priceElement)

        ' Introduce a newline character so that XML is nicely formatted.
        bookElement.InnerXml = bookElement.InnerXml.Replace(priceElement.OuterXml,
                                                            (priceElement.OuterXml & "   " & ControlChars.NewLine & "  "))
        Return bookElement
    End Function
    '</Snippet5>

    '************************************************************************************
    '
    '  Add an element to the XML document at a specific location
    '  Takes a string that describes where the user wants the new node
    '  to be positioned. The string comes from a series of radio buttons in a UI.
    '  this method also accepts the XMLDocument in context. You have to use the 
    '  this instance because it is the object that was used to generate the 
    '  selectedBook XMLNode.
    '
    '************************************************************************************
    Public Sub InsertBookElement(ByVal bookElement As XmlElement, ByVal position As String,
                                 ByVal selectedBook As XmlNode, ByVal validateNode As Boolean,
                                 ByVal generateSchema As Boolean)
        Dim doc As XmlDocument = bookElement.OwnerDocument
        Dim stringThatContainsNewline As String = bookElement.OuterXml

        Dim sigWhiteSpace As XmlSignificantWhitespace

        Select Case (position)

            Case Constants.positionTop
                ' Add newline characters and spaces to make XML more readable.
                sigWhiteSpace = doc.CreateSignificantWhitespace(ControlChars.NewLine & "  ")
                doc.DocumentElement.InsertBefore(sigWhiteSpace, doc.DocumentElement.FirstChild)
                doc.DocumentElement.InsertAfter(bookElement, doc.DocumentElement.FirstChild)

            Case Constants.positionBottom
                ' Add newline characters to make XML more readable.
                Dim whitespace As XmlWhitespace = doc.CreateWhitespace("  ")
                Dim appendedNode As XmlNode = doc.DocumentElement.AppendChild(bookElement)
                doc.DocumentElement.InsertBefore(whitespace, appendedNode)
                sigWhiteSpace = doc.CreateSignificantWhitespace(ControlChars.NewLine)
                doc.DocumentElement.InsertAfter(sigWhiteSpace, appendedNode)

            Case Constants.positionAbove
                ' Add newline characters to make XML more readable.
                Dim currNode As XmlNode = doc.DocumentElement.InsertBefore(bookElement, selectedBook)
                sigWhiteSpace = doc.CreateSignificantWhitespace(ControlChars.NewLine & "  ")
                doc.DocumentElement.InsertAfter(sigWhiteSpace, currNode)

            Case Constants.positionBelow
                ' Add newline characters to make XML more readable.
                sigWhiteSpace = doc.CreateSignificantWhitespace(ControlChars.NewLine & "  ")
                Dim whiteSpaceNode As XmlNode = doc.DocumentElement.InsertAfter(sigWhiteSpace, selectedBook)
                doc.DocumentElement.InsertAfter(bookElement, whiteSpaceNode)

            Case Else
                doc.DocumentElement.AppendChild(bookElement)

        End Select

        If validateNode Then
            validateXML(generateSchema, doc)
        End If
    End Sub
#End Region

#Region "Edit XML elements and attributes"
    '************************************************************************************
    '
    '  Edit an XML element
    '  
    '
    '************************************************************************************
    '<Snippet7>
    Public Sub editBook(ByVal title As String, ByVal ISBN As String,
                        ByVal publicationDate As String, ByVal genre As String,
                        ByVal price As String, ByVal book As XmlNode, ByVal validateNode As Boolean,
                        ByVal generateSchema As Boolean)

        Dim bookElement As XmlElement = CType(book, XmlElement)

        ' Get the attributes of a book.        
        bookElement.SetAttribute("ISBN", ISBN)
        bookElement.SetAttribute("genre", genre)
        bookElement.SetAttribute("publicationdate", publicationDate)

        ' Get the values of child elements of a book.
        bookElement("title").InnerText = title
        bookElement("price").InnerText = price
        If validateNode Then
            validateXML(generateSchema, bookElement.OwnerDocument)
        End If

    End Sub
    '</Snippet7>

#End Region

#Region "Remove elements"
    '************************************************************************************
    '
    '  Summary: Delete a book node from the XMLDocument.
    '  
    '
    '************************************************************************************
    '<Snippet6>
    Public Sub deleteBook(ByVal book As XmlNode)

        Dim prevNode As XmlNode = book.PreviousSibling
        book.OwnerDocument.DocumentElement.RemoveChild(book)

        If ((prevNode.NodeType = XmlNodeType.Whitespace) _
                    OrElse (prevNode.NodeType = XmlNodeType.SignificantWhitespace)) Then
            prevNode.OwnerDocument.DocumentElement.RemoveChild(prevNode)

        End If
    End Sub
    '</Snippet6>

#End Region

#Region "Position elements"
'<Snippet8>
    '************************************************************************************
    '
    '  Summary: Move elements up in the XML.
    '  
    '
    '************************************************************************************
    Public Sub MoveElementUp(ByVal book As XmlNode)
        Dim previousNode As XmlNode = book.PreviousSibling

        While ((Not (previousNode) Is Nothing) _
                    AndAlso (previousNode.NodeType <> XmlNodeType.Element))
            previousNode = previousNode.PreviousSibling

        End While
        If (Not (previousNode) Is Nothing) Then
            Dim newLineNode As XmlNode = book.NextSibling
            book.OwnerDocument.DocumentElement.RemoveChild(book)

            If ((newLineNode.NodeType = XmlNodeType.Whitespace) _
                        Or (newLineNode.NodeType = XmlNodeType.SignificantWhitespace)) Then
                newLineNode.OwnerDocument.DocumentElement.RemoveChild(newLineNode)
            End If

            InsertBookElement(CType(book, XmlElement), Constants.positionAbove,
                              previousNode, False, False)
        End If
    End Sub

    '************************************************************************************
    '
    '  Summary: Move elements down in the XML.
    '  
    '
    '************************************************************************************
    Public Sub MoveElementDown(ByVal book As XmlNode)
        ' Walk backwards until we find an element - ignore text nodes
        Dim NextNode As XmlNode = book.NextSibling

        While ((Not (NextNode) Is Nothing) _
                    AndAlso (NextNode.NodeType <> XmlNodeType.Element))
            NextNode = NextNode.NextSibling

        End While

        If (Not (NextNode) Is Nothing) Then
            Dim newLineNode As XmlNode = book.PreviousSibling
            book.OwnerDocument.DocumentElement.RemoveChild(book)

            If ((newLineNode.NodeType = XmlNodeType.Whitespace) _
                        Or (newLineNode.NodeType = XmlNodeType.SignificantWhitespace)) Then
                newLineNode.OwnerDocument.DocumentElement.RemoveChild(newLineNode)
            End If

            InsertBookElement(CType(book, XmlElement), Constants.positionBelow,
                              NextNode, False, False)
        End If
    End Sub
'</Snippet8>
#End Region

End Class
