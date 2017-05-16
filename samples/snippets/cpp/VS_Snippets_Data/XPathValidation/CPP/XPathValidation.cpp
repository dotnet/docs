//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Xml::Schema;
using namespace System::Xml::XPath;

class XPathValidation
{
public:

    static void Main()
    {
        try
        {
            XmlReaderSettings^ settings = gcnew XmlReaderSettings();
            settings->Schemas->Add("http://www.contoso.com/books", "contosoBooks.xsd");
            settings->ValidationType = ValidationType::Schema;

            XmlReader^ reader = XmlReader::Create("contosoBooks.xml", settings);
            XmlDocument^ document = gcnew XmlDocument();
            document->Load(reader);

            ValidationEventHandler^ eventHandler = gcnew ValidationEventHandler(ValidationEventHandlerOne);

            // the following call to Validate succeeds.
            document->Validate(eventHandler);

            // add a node so that the document is no longer valid
            XPathNavigator^ navigator = document->CreateNavigator();
            navigator->MoveToFollowing("price", "http://www.contoso.com/books");
            XmlWriter^ writer = navigator->InsertAfter();
            writer->WriteStartElement("anotherNode", "http://www.contoso.com/books");
            writer->WriteEndElement();
            writer->Close();

            // the document will now fail to successfully validate
            document->Validate(eventHandler);
        }
        catch(Exception^ ex)
        {
            Console::WriteLine(ex->Message);
        }
    }

    static void ValidationEventHandlerOne(Object^ sender, ValidationEventArgs^ e)
    {
        switch (e->Severity)
        {
        case XmlSeverityType::Error:
            Console::WriteLine("Error: {0}", e->Message);
            break;
        case XmlSeverityType::Warning:
            Console::WriteLine("Warning {0}", e->Message);
            break;
        }

    }
};

int main()
{
    XPathValidation::Main();
    Console::ReadLine();
    return 0;
};
//</snippet1>