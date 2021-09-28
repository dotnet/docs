//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Xml::Schema;

ref class XmlDocumentValidationExample
{
public:

    static void Main()
    {
        try
        {
            // Create a schema validating XmlReader.
            XmlReaderSettings^ settings = gcnew XmlReaderSettings();
            settings->Schemas->Add("http://www.contoso.com/books", "contosoBooks.xsd");
			ValidationEventHandler^ eventHandler = gcnew ValidationEventHandler(ValidationEventHandlerOne);
            settings->ValidationEventHandler += eventHandler;
			settings->ValidationFlags = settings->ValidationFlags | XmlSchemaValidationFlags::ReportValidationWarnings;
			settings->ValidationType = ValidationType::Schema;

			XmlReader^ reader = XmlReader::Create("contosoBooks.xml", settings);

            // The XmlDocument validates the XML document contained
            // in the XmlReader as it is loaded into the DOM.
            XmlDocument^ document = gcnew XmlDocument();
            document->Load(reader);

            // Make an invalid change to the first and last 
            // price elements in the XML document, and write
            // the XmlSchemaInfo values assigned to the price
            // element during load validation to the console.
            XmlNamespaceManager^ manager = gcnew XmlNamespaceManager(document->NameTable);
            manager->AddNamespace("bk", "http://www.contoso.com/books");

            XmlNode^ priceNode = document->SelectSingleNode("/bk:bookstore/bk:book/bk:price", manager);

            Console::WriteLine("SchemaInfo.IsDefault: {0}", priceNode->SchemaInfo->IsDefault);
            Console::WriteLine("SchemaInfo.IsNil: {0}", priceNode->SchemaInfo->IsNil);
            Console::WriteLine("SchemaInfo.SchemaElement: {0}", priceNode->SchemaInfo->SchemaElement);
            Console::WriteLine("SchemaInfo.SchemaType: {0}", priceNode->SchemaInfo->SchemaType);
            Console::WriteLine("SchemaInfo.Validity: {0}", priceNode->SchemaInfo->Validity);

            priceNode->InnerXml = "A";

            XmlNodeList^ priceNodes = document->SelectNodes("/bk:bookstore/bk:book/bk:price", manager);
            XmlNode^ lastprice = priceNodes[priceNodes->Count - 1];
            
            lastprice->InnerXml = "B";

            // Validate the XML document with the invalid changes.
            // The invalid changes cause schema validation errors.
            document->Validate(eventHandler);

            // Correct the invalid change to the first price element.
            priceNode->InnerXml = "8.99";

            // Validate only the first book element. The last book
            // element is invalid, but not included in validation.
            XmlNode^ bookNode = document->SelectSingleNode("/bk:bookstore/bk:book", manager);
            document->Validate(eventHandler, bookNode);
        }
        catch (XmlException^ ex)
        {
            Console::WriteLine("XmlDocumentValidationExample.XmlException: {0}", ex->Message);
        }
        catch(XmlSchemaValidationException^ ex)
        {
            Console::WriteLine("XmlDocumentValidationExample.XmlSchemaValidationException: {0}", ex->Message);
        }
        catch (Exception^ ex)
        {
            Console::WriteLine("XmlDocumentValidationExample.Exception: {0}", ex->Message);
        }
    }

    static void ValidationEventHandlerOne(Object^ sender, ValidationEventArgs^ args)
    {
		if (args->Severity == XmlSeverityType::Warning)
            Console::Write("\nWARNING: ");
		else if (args->Severity == XmlSeverityType::Error)
            Console::Write("\nERROR: ");

        Console::WriteLine(args->Message);
    }
};

int main()
{
	XmlDocumentValidationExample::Main();
    return 0;
}
//</snippet1>