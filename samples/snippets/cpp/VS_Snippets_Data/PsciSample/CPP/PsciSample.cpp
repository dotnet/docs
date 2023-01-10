//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Xml::Schema;

ref class PsciSample
{
private:
	static void ValidationCallbackOne(Object^ sender, ValidationEventArgs^ args)
    {
		Console::WriteLine(args->Message);
    }

public:
    static void Main()
    {
        XmlSchema^ schema = gcnew XmlSchema();

        // Create an element of type integer and add it to the schema.
        XmlSchemaElement^ priceElem = gcnew XmlSchemaElement();
        priceElem->Name = "Price";
        priceElem->SchemaTypeName = gcnew XmlQualifiedName("integer", "http://www.w3.org/2001/XMLSchema");
        schema->Items->Add(priceElem);

        // Print the pre-compilation value of the ElementSchemaType property 
        // of the XmlSchemaElement which is a PSCI property.
		Console::WriteLine("Before compilation the ElementSchemaType of Price is " + priceElem->ElementSchemaType);

        //Compile the schema which validates the schema and
        // if valid will place the PSCI values in certain properties.
        XmlSchemaSet^ schemaSet = gcnew XmlSchemaSet();
		ValidationEventHandler^ eventHandler = gcnew ValidationEventHandler(ValidationCallbackOne);
        schemaSet->ValidationEventHandler += eventHandler;
        schemaSet->Add(schema);
        schemaSet->Compile();

        for each (XmlSchema^ compiledSchema in schemaSet->Schemas())
        {
            schema = compiledSchema;
        }

        // After compilation of the schema, the ElementSchemaType property of the 
        // XmlSchemaElement will contain a reference to a valid object because the 
        // SchemaTypeName refered to a valid type.
		Console::WriteLine("After compilation the ElementSchemaType of Price is "
           + priceElem->ElementSchemaType);

    }
};

int main()
{
	PsciSample::Main();
	return 0;
}
//</snippet1>
