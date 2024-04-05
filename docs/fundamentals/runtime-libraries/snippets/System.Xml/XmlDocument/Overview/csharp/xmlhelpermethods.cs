using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.IO;
using System.Collections;

namespace XMLProcessingApp
{
    public class XMLHelperMethods
    {
        #region Load and save XML
        //************************************************************************************
        //
        //  Loads XML from a file. If the file is not found, load XML from a string.
        //
        //************************************************************************************

        public XmlDocument LoadDocument(bool generateXML)
        {
            //<Snippet1>
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            try { doc.Load("booksData.xml"); }
            catch (System.IO.FileNotFoundException)
            {
                doc.LoadXml("<?xml version=\"1.0\"?> \n" +
                "<books xmlns=\"http://www.contoso.com/books\"> \n" +
                "  <book genre=\"novel\" ISBN=\"1-861001-57-8\" publicationdate=\"1823-01-28\"> \n" +
                "    <title>Pride And Prejudice</title> \n" +
                "    <price>24.95</price> \n" +
                "  </book> \n" +
                "  <book genre=\"novel\" ISBN=\"1-861002-30-1\" publicationdate=\"1985-01-01\"> \n" +
                "    <title>The Handmaid's Tale</title> \n" +
                "    <price>29.95</price> \n" +
                "  </book> \n" +
                "</books>");
            }
            //</Snippet1>

            return doc;
        }

        //************************************************************************************
        //
        //  Loads XML from a file. If the file is not found, load XML from a string.
        //
        //************************************************************************************
        public void SaveXML(XmlDocument doc)
        {
            doc.Save(Constants.booksFileName);
        }
        #endregion

        #region Validate XML against a Schema

        //<Snippet2>
        //************************************************************************************
        //
        //  Helper method that generates an XML string.
        //
        //************************************************************************************
        private string generateXMLString()
        {
            string xml = "<?xml version=\"1.0\"?> \n" +
                "<books xmlns=\"http://www.contoso.com/books\"> \n" +
                "  <book genre=\"novel\" ISBN=\"1-861001-57-8\" publicationdate=\"1823-01-28\"> \n" +
                "    <title>Pride And Prejudice</title> \n" +
                "    <price>24.95</price> \n" +
                "  </book> \n" +
                "  <book genre=\"novel\" ISBN=\"1-861002-30-1\" publicationdate=\"1985-01-01\"> \n" +
                "    <title>The Handmaid's Tale</title> \n" +
                "    <price>29.95</price> \n" +
                "  </book> \n" +
                "  <book genre=\"novel\" ISBN=\"1-861001-45-3\" publicationdate=\"1811-01-01\"> \n" +
                "    <title>Sense and Sensibility</title> \n" +
                "    <price>19.95</price> \n" +
                "  </book> \n" +
                "</books>";
            return xml;
        }

        //************************************************************************************
        //
        //  Associate the schema with XML. Then, load the XML and validate it against
        //  the schema.
        //
        //************************************************************************************
        public XmlDocument LoadDocumentWithSchemaValidation(bool generateXML, bool generateSchema)
        {
            XmlReader reader = null;
            XmlReaderSettings settings = new XmlReaderSettings();
            // Helper method to retrieve schema.
            XmlSchema schema = getSchema(generateSchema);

            settings.Schemas.Add(schema);
            settings.ValidationEventHandler += ValidationCallback;
            settings.ValidationFlags =
                settings.ValidationFlags | XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.ValidationType = ValidationType.Schema;
            if (!generateXML)
            {
                try
                {
                    reader = XmlReader.Create("booksData.xml", settings);
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine(
                        $"XML file not found so generating: {ex.Message}");
                    generateXML = true;
                }
            }

            if (generateXML)
            {
                string xml = generateXMLString();
                StringReader stringReader = new StringReader(xml);

                reader = XmlReader.Create(stringReader, settings);
            }

            XmlDocument doc = new XmlDocument();

            doc.PreserveWhitespace = true;
            doc.Load(reader);
            reader.Close();

            return doc;
        }

        //************************************************************************************
        //
        //  Helper method that generates an XML Schema.
        //
        //************************************************************************************
        private string generateXMLSchema()
        {
            string xmlSchema =
                "<?xml version=\"1.0\" encoding=\"utf-8\"?> " +
                "<xs:schema attributeFormDefault=\"unqualified\" " +
                "elementFormDefault=\"qualified\" targetNamespace=\"http://www.contoso.com/books\" " +
                "xmlns:xs=\"http://www.w3.org/2001/XMLSchema\"> " +
                "<xs:element name=\"books\"> " +
                "<xs:complexType> " +
                "<xs:sequence> " +
                "<xs:element maxOccurs=\"unbounded\" name=\"book\"> " +
                "<xs:complexType> " +
                "<xs:sequence> " +
                "<xs:element name=\"title\" type=\"xs:string\" /> " +
                "<xs:element name=\"price\" type=\"xs:decimal\" /> " +
                "</xs:sequence> " +
                "<xs:attribute name=\"genre\" type=\"xs:string\" use=\"required\" /> " +
                "<xs:attribute name=\"publicationdate\" type=\"xs:date\" use=\"required\" /> " +
                "<xs:attribute name=\"ISBN\" type=\"xs:string\" use=\"required\" /> " +
                "</xs:complexType> " +
                "</xs:element> " +
                "</xs:sequence> " +
                "</xs:complexType> " +
                "</xs:element> " +
                "</xs:schema> ";
            return xmlSchema;
        }

        //************************************************************************************
        //
        //  Helper method that gets a schema
        //
        //************************************************************************************
        private XmlSchema getSchema(bool generateSchema)
        {
            XmlSchemaSet xs = new XmlSchemaSet();
            XmlSchema schema = null;

            if (!generateSchema)
            {
                try
                {
                    schema = xs.Add("http://www.contoso.com/books", "booksData.xsd");
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine(
                        $"XSD file not found so generating: {ex.Message}");
                    generateSchema = true;
                }
            }

            if (generateSchema)
            {
                string xmlSchemaString = generateXMLSchema();
                StringReader stringReader = new StringReader(xmlSchemaString);
                XmlReader reader = XmlReader.Create(stringReader);

                schema = xs.Add("http://www.contoso.com/books", reader);
            }

            return schema;
        }

        //************************************************************************************
        //
        //  Helper method to validate the XML against the schema.
        //
        //************************************************************************************
        private void validateXML(bool generateSchema, XmlDocument doc)
        {
            if (doc.Schemas.Count == 0)
            {
                // Helper method to retrieve schema.
                XmlSchema schema = getSchema(generateSchema);
                doc.Schemas.Add(schema);
            }

            // Use a callback to validate the XML node against the schema.
            doc.Validate(ValidationCallback);
        }

        //************************************************************************************
        //
        //  Event handler that is raised when XML doesn't validate against the schema.
        //
        //************************************************************************************
        void ValidationCallback(object sender,
            System.Xml.Schema.ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Warning)
            {
                Console.WriteLine
                    ("The following validation warning occurred: " + e.Message);
            }
            else if (e.Severity == XmlSeverityType.Error)
            {
                Console.WriteLine
                    ("The following critical validation errors occurred: " + e.Message);
            }
        }
        //</Snippet2>
        #endregion

        #region Find XML elements and attributes

        //************************************************************************************
        //
        //  Search the XML tree for a specific XMLNode element by using an attribute value.
        //  Description: Must identify the namespace of the nodes and define a prefix. Also include the
        //  prefix in the XPath string.
        //
        //************************************************************************************
        //<Snippet3>
        public XmlNode GetBook(string uniqueAttribute, XmlDocument doc)
        {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("bk", "http://www.contoso.com/books");
            string xPathString = "//bk:books/bk:book[@ISBN='" + uniqueAttribute + "']";
            XmlNode xmlNode = doc.DocumentElement.SelectSingleNode(xPathString, nsmgr);
           return xmlNode;
        }
        //</Snippet3>
        //************************************************************************************
        //
        //  Get information about a specific book. Pass in an XMLNode that
        //  represents the book and populate strings passed in by reference.
        //
        //  **********************************************************************************
       //<Snippet4>
        public void GetBookInformation(ref string title, ref string ISBN, ref string publicationDate,
            ref string price, ref string genre, XmlNode book)
        {
            XmlElement bookElement = (XmlElement)book;

            // Get the attributes of a book.
            XmlAttribute attr = bookElement.GetAttributeNode("ISBN");
            ISBN = attr.InnerXml;

            attr = bookElement.GetAttributeNode("genre");
            genre = attr.InnerXml;

            attr = bookElement.GetAttributeNode("publicationdate");
            publicationDate = attr.InnerXml;

            // Get the values of child elements of a book.
            title = bookElement["title"].InnerText;
            price = bookElement["price"].InnerText;
        }
        //</Snippet4>
        //************************************************************************************
        //
        //  Uses filter criteria collection in the UI to retrieve specific elements and attributes.
        //
        //************************************************************************************
        public XmlNodeList ApplyFilters(ArrayList conditions, ArrayList operatorSymbols,
            ArrayList values, XmlDocument doc, string matchString)
        {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("bk", "http://www.contoso.com/books");

            string xPathQueryString = "//bk:books/bk:book[";
            string xPathQueryEnding = "]";
            ArrayList xPathQueryStrings = new ArrayList();
            string booleanOperator;
            if (matchString == "Any")
            {
                booleanOperator = "or ";
            }
            else
            {
                booleanOperator = "and ";
            }
            int counter = 0;
            string[] operatorArray = (string[])operatorSymbols.ToArray(typeof(string));
            string[] valueArray = (string[])values.ToArray(typeof(string));

            foreach (string condition in conditions)
            {
                string xPathQueryPart = "";
                string operatorSymbol = operatorArray[counter];
                string value = valueArray[counter];
                if (counter > 0)
                {
                    xPathQueryString = xPathQueryString + booleanOperator;
                }
                counter++;

                switch (condition)
                {
                    case Constants.Title:
                        switch (operatorSymbol)
                        {
                            case "Contains":
                                xPathQueryPart = "contains(bk:title,'" + value + "')";
                                break;
                            case "Excludes":
                                xPathQueryPart = "not(contains(bk:title,'" + value + "'))";
                                break;
                            case "=":
                                xPathQueryPart = "bk:title='" + value + "'";
                                break;
                        }
                        break;
                    case Constants.ISBN:
                        switch (operatorSymbol)
                        {
                            case "Contains":
                                xPathQueryPart = "contains(@ISBN, '" + value + "')";
                                break;
                            case "Excludes":
                                xPathQueryPart = "not(contains(@ISBN, '" + value + "'))";
                                break;
                            case "=":
                                xPathQueryPart = "@ISBN='" + value + "'";
                                break;
                        }
                        break;
                    case Constants.PubDate:
                        xPathQueryPart = "contains(@publicationdate, '" + value + "')";
                        break;
                    case Constants.Price:
                        switch (operatorSymbol)
                        {
                            case "=":
                                xPathQueryPart = "bk:price='" + value + "'";
                                break;
                            case ">":
                                xPathQueryPart = "bk:price>'" + value + "'";
                                break;
                            case "<":
                                xPathQueryPart = "bk:price<'" + value + "'";
                                break;
                            case ">=":
                                xPathQueryPart = "bk:price>='" + value + "'";
                                break;
                            case "<=":
                                xPathQueryPart = "bk:price<='" + value + "'";
                                break;
                            case "<>":
                                xPathQueryPart = "bk:price!='" + value + "'";
                                break;
                        }
                        break;
                    case Constants.Genre:
                        xPathQueryPart = "@genre='" + value + "'";
                        break;
                }

                xPathQueryString = xPathQueryString + xPathQueryPart;
            }

            xPathQueryString = xPathQueryString + xPathQueryEnding;

            XmlNodeList nodeList = doc.DocumentElement.SelectNodes(xPathQueryString, nsmgr);

            return nodeList;
        }

        #endregion

        #region Add XML elements and attributes
        //************************************************************************************
        //
        //  Add an element to the XML document.
        //  This method creates a new book element and saves that element to the
        //  XMLDocument object. It addes attributes for the new element and introduces
        //  newline characters between elements fora nice readable format.
        //
        //
        //************************************************************************************

        //<Snippet5>
        public XmlElement AddNewBook(string genre, string ISBN, string misc,
            string title, string price, XmlDocument doc)
        {
            // Create a new book element.
            XmlElement bookElement = doc.CreateElement("book", "http://www.contoso.com/books");

            // Create attributes for book and append them to the book element.
            XmlAttribute attribute = doc.CreateAttribute("genre");
            attribute.Value = genre;
            bookElement.Attributes.Append(attribute);

            attribute = doc.CreateAttribute("ISBN");
            attribute.Value = ISBN;
            bookElement.Attributes.Append(attribute);

            attribute = doc.CreateAttribute("publicationdate");
            attribute.Value = misc;
            bookElement.Attributes.Append(attribute);

            // Create and append a child element for the title of the book.
            XmlElement titleElement = doc.CreateElement("title");
            titleElement.InnerText = title;
            bookElement.AppendChild(titleElement);

            // Introduce a newline character so that XML is nicely formatted.
            bookElement.InnerXml =
                bookElement.InnerXml.Replace(titleElement.OuterXml,
                "\n    " + titleElement.OuterXml + " \n    ");

            // Create and append a child element for the price of the book.
            XmlElement priceElement = doc.CreateElement("price");
            priceElement.InnerText= price;
            bookElement.AppendChild(priceElement);

            // Introduce a newline character so that XML is nicely formatted.
            bookElement.InnerXml =
                bookElement.InnerXml.Replace(priceElement.OuterXml, priceElement.OuterXml + "   \n  ");

            return bookElement;
        }
        //</Snippet5>

        //************************************************************************************
        //
        //  Add an element to the XML document at a specific location
        //  Takes a string that describes where the user wants the new node
        //  to be positioned. The string comes from a series of radio buttons in a UI.
        //  this method also accepts the XMLDocument in context. You have to use the
        //  this instance because it is the object that was used to generate the
        //  selectedBook XMLNode.
        //
        //************************************************************************************
        //</Snipppet9>
        public void InsertBookElement(XmlElement bookElement, string position, XmlNode selectedBook, bool validateNode, bool generateSchema)
        {
            XmlDocument doc = bookElement.OwnerDocument;

            string stringThatContainsNewline = bookElement.OuterXml;

            switch (position)
            {
                case Constants.positionTop:
                    // Add newline characters and spaces to make XML more readable.
                    XmlSignificantWhitespace sigWhiteSpace = doc.CreateSignificantWhitespace("\n  ");
                    doc.DocumentElement.InsertBefore(sigWhiteSpace, doc.DocumentElement.FirstChild);
                    doc.DocumentElement.InsertAfter(bookElement, doc.DocumentElement.FirstChild);
                    break;

                case Constants.positionBottom:
                    // Add newline characters to make XML more readable.
                    XmlWhitespace whitespace = doc.CreateWhitespace("  ");
                    XmlNode appendedNode = doc.DocumentElement.AppendChild(bookElement);
                    doc.DocumentElement.InsertBefore(whitespace, appendedNode);
                    sigWhiteSpace = doc.CreateSignificantWhitespace("\n");
                    doc.DocumentElement.InsertAfter(sigWhiteSpace, appendedNode);
                    break;

                case Constants.positionAbove:
                    // Add newline characters to make XML more readable.
                    XmlNode currNode = doc.DocumentElement.InsertBefore(bookElement, selectedBook);
                    sigWhiteSpace = doc.CreateSignificantWhitespace("\n  ");
                    doc.DocumentElement.InsertAfter(sigWhiteSpace, currNode);
                    break;

                case Constants.positionBelow:
                    // Add newline characters to make XML more readable.
                    sigWhiteSpace = doc.CreateSignificantWhitespace("\n  ");
                    XmlNode whiteSpaceNode = doc.DocumentElement.InsertAfter(sigWhiteSpace, selectedBook);
                    doc.DocumentElement.InsertAfter(bookElement, whiteSpaceNode);
                    break;

                default:
                    doc.DocumentElement.AppendChild(bookElement);
                    break;
            }

            if (validateNode)
            {
                validateXML(generateSchema, doc);
            }
        }
        //</Snippet9>

        #endregion

        #region Edit XML elements and attributes

        //************************************************************************************
        //
        //  Edit an XML element
        //
        //************************************************************************************
        //<Snippet7>
        public void editBook(string title, string ISBN, string publicationDate,
            string genre, string price, XmlNode book, bool validateNode, bool generateSchema)
        {

            XmlElement bookElement = (XmlElement)book;

            // Get the attributes of a book.
            bookElement.SetAttribute("ISBN", ISBN);
            bookElement.SetAttribute("genre", genre);
            bookElement.SetAttribute("publicationdate", publicationDate);

            // Get the values of child elements of a book.
            bookElement["title"].InnerText = title;
            bookElement["price"].InnerText = price;

            if (validateNode)
            {
                validateXML(generateSchema, bookElement.OwnerDocument);
            }
        }
        //</Snippet7>

        #endregion

        #region Remove elements

        //************************************************************************************
        //
        //  Summary: Delete a book node from the XMLDocument.
        //
        //
        //************************************************************************************
        //<Snippet6>
        public void deleteBook(XmlNode book)
        {
            XmlNode prevNode = book.PreviousSibling;

            book.OwnerDocument.DocumentElement.RemoveChild(book);

            if (prevNode.NodeType == XmlNodeType.Whitespace ||
                prevNode.NodeType == XmlNodeType.SignificantWhitespace)
            {
                prevNode.OwnerDocument.DocumentElement.RemoveChild(prevNode);
            }
        }
        //</Snippet6>
        #endregion

        #region Position elements
        //<Snippet8>
        //************************************************************************************
        //
        //  Summary: Move elements up in the XML.
        //
        //
        //************************************************************************************

        public void MoveElementUp(XmlNode book)
        {
            XmlNode previousNode = book.PreviousSibling;
            while (previousNode != null && (previousNode.NodeType != XmlNodeType.Element))
            {
                previousNode = previousNode.PreviousSibling;
            }
            if (previousNode != null)
            {
                XmlNode newLineNode = book.NextSibling;
                book.OwnerDocument.DocumentElement.RemoveChild(book);
                if (newLineNode.NodeType == XmlNodeType.Whitespace |
                    newLineNode.NodeType == XmlNodeType.SignificantWhitespace)
                {
                    newLineNode.OwnerDocument.DocumentElement.RemoveChild(newLineNode);
                }
                InsertBookElement((XmlElement)book, Constants.positionAbove,
                    previousNode, false, false);
            }
        }

        //************************************************************************************
        //
        //  Summary: Move elements down in the XML.
        //
        //
        //************************************************************************************
        public void MoveElementDown(XmlNode book)
        {
            // Walk backwards until we find an element - ignore text nodes
            XmlNode NextNode = book.NextSibling;
            while (NextNode != null && (NextNode.NodeType != XmlNodeType.Element))
            {
                NextNode = NextNode.NextSibling;
            }
            if (NextNode != null)
            {
                XmlNode newLineNode = book.PreviousSibling;
                book.OwnerDocument.DocumentElement.RemoveChild(book);
                if (newLineNode.NodeType == XmlNodeType.Whitespace |
                    newLineNode.NodeType == XmlNodeType.SignificantWhitespace)
                {
                    newLineNode.OwnerDocument.DocumentElement.RemoveChild(newLineNode);
                }

                InsertBookElement((XmlElement)book, Constants.positionBelow,
                    NextNode, false, false);
            }
        }
//</Snippet8>
        #endregion

    }
}
