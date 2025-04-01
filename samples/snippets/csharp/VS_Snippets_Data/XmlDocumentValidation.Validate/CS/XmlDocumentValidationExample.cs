//<snippet1>
using System;
using System.Xml;
using System.Xml.Schema;

class XmlDocumentValidationExample
{
    static void Main(string[] args)
    {
        try
        {
            // Create a new XmlDocument instance and load
            // the XML document into the DOM.
            XmlDocument document = new XmlDocument();
            document.Load("contosoBooks.xml");

            // Add the XML schema for the XML document to the
            // Schemas property of the XmlDocument.
            document.Schemas.Add("http://www.contoso.com/books", "contosoBooks.xsd");

            // Validate the XML document loaded into the DOM.
            document.Validate(ValidationEventHandler);

            // Make an invalid change to the first and last
            // price elements in the XML document, and write
            // the XmlSchemaInfo values assigned to the price
            // element during validation to the console.
            XmlNamespaceManager manager = new XmlNamespaceManager(document.NameTable);
            manager.AddNamespace("bk", "http://www.contoso.com/books");

            XmlNode priceNode = document.SelectSingleNode(@"/bk:bookstore/bk:book/bk:price", manager);

            Console.WriteLine($"SchemaInfo.IsDefault: {priceNode.SchemaInfo.IsDefault}");
            Console.WriteLine($"SchemaInfo.IsNil: {priceNode.SchemaInfo.IsNil}");
            Console.WriteLine($"SchemaInfo.SchemaElement: {priceNode.SchemaInfo.SchemaElement}");
            Console.WriteLine($"SchemaInfo.SchemaType: {priceNode.SchemaInfo.SchemaType}");
            Console.WriteLine($"SchemaInfo.Validity: {priceNode.SchemaInfo.Validity}");

            priceNode.InnerXml = "A";

            XmlNodeList priceNodes = document.SelectNodes(@"/bk:bookstore/bk:book/bk:price", manager);
            XmlNode lastprice = priceNodes[priceNodes.Count - 1];

            lastprice.InnerXml = "B";

            // Validate the XML document with the invalid changes.
            // The invalid changes cause schema validation errors.
            document.Validate(ValidationEventHandler);

            // Correct the invalid change to the first price element.
            priceNode.InnerXml = "8.99";

            // Validate only the first book element. The last book
            // element is invalid, but not included in validation.
            XmlNode bookNode = document.SelectSingleNode(@"/bk:bookstore/bk:book", manager);
            document.Validate(ValidationEventHandler, bookNode);
        }
        catch (XmlException ex)
        {
            Console.WriteLine($"XmlDocumentValidationExample.XmlException: {ex.Message}");
        }
        catch(XmlSchemaValidationException ex)
        {
            Console.WriteLine($"XmlDocumentValidationExample.XmlSchemaValidationException: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"XmlDocumentValidationExample.Exception: {ex.Message}");
        }
    }

    static void ValidationEventHandler(object sender, System.Xml.Schema.ValidationEventArgs args)
    {
        if (args.Severity == XmlSeverityType.Warning)
            Console.Write("\nWARNING: ");
        else if (args.Severity == XmlSeverityType.Error)
            Console.Write("\nERROR: ");

        Console.WriteLine(args.Message);
    }
}
//</snippet1>