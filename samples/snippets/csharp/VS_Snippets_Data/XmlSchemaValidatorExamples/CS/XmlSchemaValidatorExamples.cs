//<snippet1>
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Collections;

namespace Microsoft.Samples.Xml.Schema
{
    class XmlSchemaValidatorExamples
    {
        static void Main()
        {
            // The XML document to deserialize into the XmlSerializer object.
            XmlReader reader = XmlReader.Create("contosoBooks.xml");

            // The XmlSerializer object.
            XmlSerializer serializer = new XmlSerializer(typeof(ContosoBooks));
            ContosoBooks books = (ContosoBooks)serializer.Deserialize(reader);

            // The XmlSchemaSet object containing the schema used to validate the XML document.
            XmlSchemaSet schemaSet = new XmlSchemaSet();
            schemaSet.Add("http://www.contoso.com/books", "contosoBooks.xsd");

            // The XmlNamespaceManager object used to handle namespaces.
            XmlNamespaceManager manager = new XmlNamespaceManager(reader.NameTable);

            // Assign a ValidationEventHandler to handle schema validation warnings and errors.
            XmlSchemaValidator validator = new XmlSchemaValidator(reader.NameTable, schemaSet, manager, XmlSchemaValidationFlags.None);
            validator.ValidationEventHandler += new ValidationEventHandler(SchemaValidationEventHandler);

            // Initialize the XmlSchemaValidator object.
            validator.Initialize();

            // Validate the bookstore element, verify that all required attributes are present
            // and prepare to validate child content.
            validator.ValidateElement("bookstore", "http://www.contoso.com/books", null);
            validator.GetUnspecifiedDefaultAttributes(new ArrayList());
            validator.ValidateEndOfAttributes(null);

            // Get the next expected element in the bookstore context.
            XmlSchemaParticle[] particles = validator.GetExpectedParticles();
            XmlSchemaElement nextElement = particles[0] as XmlSchemaElement;
            Console.WriteLine($"Expected Element: '{nextElement.Name}'");

            foreach (BookType book in books.Book)
            {
                // Validate the book element.
                validator.ValidateElement("book", "http://www.contoso.com/books", null);

                // Get the expected attributes for the book element.
                Console.Write("\nExpected attributes: ");
                XmlSchemaAttribute[] attributes = validator.GetExpectedAttributes();
                foreach (XmlSchemaAttribute attribute in attributes)
                {
                    Console.Write("'{0}' ", attribute.Name);
                }
                Console.WriteLine();

                // Validate the genre attribute and display its post schema validation information.
                if (book.Genre != null)
                {
                    validator.ValidateAttribute("genre", "", book.Genre, schemaInfo);
                }
                DisplaySchemaInfo();

                // Validate the publicationdate attribute and display its post schema validation information.
                if (book.PublicationDate != null)
                {
                    validator.ValidateAttribute("publicationdate", "", dateTimeGetter(book.PublicationDate), schemaInfo);
                }
                DisplaySchemaInfo();

                // Validate the ISBN attribute and display its post schema validation information.
                if (book.Isbn != null)
                {
                    validator.ValidateAttribute("ISBN", "", book.Isbn, schemaInfo);
                }
                DisplaySchemaInfo();

                // After validating all the attributes for the current element with ValidateAttribute method,
                // you must call GetUnspecifiedDefaultAttributes to validate the default attributes.
                validator.GetUnspecifiedDefaultAttributes(new ArrayList());

                // Verify that all required attributes of the book element are present
                // and prepare to validate child content.
                validator.ValidateEndOfAttributes(null);

                // Validate the title element and its content.
                validator.ValidateElement("title", "http://www.contoso.com/books", null);
                validator.ValidateEndElement(null, book.Title);

                // Validate the author element, verify that all required attributes are present
                // and prepare to validate child content.
                validator.ValidateElement("author", "http://www.contoso.com/books", null);
                validator.GetUnspecifiedDefaultAttributes(new ArrayList());
                validator.ValidateEndOfAttributes(null);

                if (book.Author.Name != null)
                {
                    // Validate the name element and its content.
                    validator.ValidateElement("name", "http://www.contoso.com/books", null);
                    validator.ValidateEndElement(null, book.Author.Name);
                }

                if (book.Author.FirstName != null)
                {
                    // Validate the first-name element and its content.
                    validator.ValidateElement("first-name", "http://www.contoso.com/books", null);
                    validator.ValidateEndElement(null, book.Author.FirstName);
                }

                if (book.Author.LastName != null)
                {
                    // Validate the last-name element and its content.
                    validator.ValidateElement("last-name", "http://www.contoso.com/books", null);
                    validator.ValidateEndElement(null, book.Author.LastName);
                }

                // Validate the content of the author element.
                validator.ValidateEndElement(null);

                // Validate the price element and its content.
                validator.ValidateElement("price", "http://www.contoso.com/books", null);
                validator.ValidateEndElement(null, book.Price);

                // Validate the content of the book element.
                validator.ValidateEndElement(null);
            }

            // Validate the content of the bookstore element.
            validator.ValidateEndElement(null);

            // Close the XmlReader object.
            reader.Close();
        }

        static XmlSchemaInfo schemaInfo = new XmlSchemaInfo();
        static object dateTimeGetterContent;

        static object dateTimeGetterHandle()
        {
            return dateTimeGetterContent;
        }

        static XmlValueGetter dateTimeGetter(DateTime dateTime)
        {
            dateTimeGetterContent = dateTime;
            return new XmlValueGetter(dateTimeGetterHandle);
        }

        static void DisplaySchemaInfo()
        {
            if (schemaInfo.SchemaElement != null)
            {
                Console.WriteLine($"Element '{schemaInfo.SchemaElement.Name}' with type '{schemaInfo.SchemaType}' is '{schemaInfo.Validity}'");
            }
            else if (schemaInfo.SchemaAttribute != null)
            {
                Console.WriteLine($"Attribute '{schemaInfo.SchemaAttribute.Name}' with type '{schemaInfo.SchemaType}' is '{schemaInfo.Validity}'");
            }
        }

        static void SchemaValidationEventHandler(object sender, ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    Console.WriteLine($"\nError: {e.Message}");
                    break;
                case XmlSeverityType.Warning:
                    Console.WriteLine($"\nWarning: {e.Message}");
                    break;
            }
        }
    }

    [XmlRootAttribute("bookstore", Namespace = "http://www.contoso.com/books", IsNullable = false)]
    public class ContosoBooks
    {
        [XmlElementAttribute("book")]
        public BookType[] Book;
    }

    public class BookType
    {
        [XmlAttributeAttribute("genre")]
        public string Genre;

        [XmlAttributeAttribute("publicationdate", DataType = "date")]
        public DateTime PublicationDate;

        [XmlAttributeAttribute("ISBN")]
        public string Isbn;

        [XmlElementAttribute("title")]
        public string Title;

        [XmlElementAttribute("author")]
        public BookAuthor Author;

        [XmlElementAttribute("price")]
        public Decimal Price;
    }

    public class BookAuthor
    {
        [XmlElementAttribute("name")]
        public string Name;

        [XmlElementAttribute("first-name")]
        public string FirstName;

        [XmlElementAttribute("last-name")]
        public string LastName;
    }
}
//</snippet1>
