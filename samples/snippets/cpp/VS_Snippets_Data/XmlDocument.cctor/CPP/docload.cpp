//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Xml::Schema;

ref class XmlDocumentSample
{
private:
	static XmlReader^ reader;
	static String^ filename = "bookdtd.xml";

	// Display the validation error.
	static void ValidationCallback(Object^ sender, ValidationEventArgs^ args)
	{
		Console::WriteLine("Validation error loading: {0}", filename);
		Console::WriteLine(args->Message);
	}

public:
	static void Main()
	{
		ValidationEventHandler^ eventHandler = gcnew ValidationEventHandler(XmlDocumentSample::ValidationCallback);

		try
		{
			// Create the validating reader and specify DTD validation.
			XmlReaderSettings^ settings = gcnew XmlReaderSettings();
                        settings->DtdProcessing = DtdProcessing::Parse;
			settings->ValidationType = ValidationType::DTD;
			settings->ValidationEventHandler += eventHandler;

			reader = XmlReader::Create(filename, settings);

			// Pass the validating reader to the XML document.
			// Validation fails due to an undefined attribute, but the 
			// data is still loaded into the document.
			XmlDocument^ doc = gcnew XmlDocument();
			doc->Load(reader);
			Console::WriteLine(doc->OuterXml);
		}
		finally
		{
			if (reader != nullptr)
				reader->Close();
		}
	}
};

int main()
{
	XmlDocumentSample::Main();
	return 0;
}
//</snippet1>