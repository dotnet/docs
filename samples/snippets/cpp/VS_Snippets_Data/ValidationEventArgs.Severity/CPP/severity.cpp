//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Schema;

ref class Sample
{
private:
	static void Validate(String^ filename, XmlSchemaSet^ schemaSet)
    {
        Console::WriteLine();
        Console::WriteLine("\r\nValidating XML file {0}...", filename->ToString());

        XmlSchema^ compiledSchema;

        for each (XmlSchema^ schema in schemaSet->Schemas())
        {
            compiledSchema = schema;
        }

        XmlReaderSettings^ settings = gcnew XmlReaderSettings();
        settings->Schemas->Add(compiledSchema);
        settings->ValidationEventHandler += gcnew ValidationEventHandler(ValidationCallBack);
		settings->ValidationType = ValidationType::Schema;

        //Create the schema validating reader.
		XmlReader^ vreader = XmlReader::Create(filename, settings);

        while (vreader->Read()) { }

        //Close the reader.
        vreader->Close();
    }

	//Display any warnings or errors.
    static void ValidationCallBack(Object^ sender, ValidationEventArgs^ args)
    {
		if (args->Severity == XmlSeverityType::Warning)
            Console::WriteLine("\tWarning: Matching schema not found.  No validation occurred." + args->Message);
        else
			Console::WriteLine("\tValidation error: " + args->Message);
    }

public:
    static void Main()
    {
        //Load the XmlSchemaSet.
        XmlSchemaSet^ schemaSet = gcnew XmlSchemaSet();
        schemaSet->Add("urn:bookstore-schema", "books.xsd");

        //Validate the file using the schema stored in the schema set.
        //Any elements belonging to the namespace "urn:cd-schema" generate
        //a warning because there is no schema matching that namespace.
        Validate("store.xml", schemaSet);
        Console::ReadLine();
    }
};

int main()
{
	Sample::Main();
	return 0;
}
//</snippet1>