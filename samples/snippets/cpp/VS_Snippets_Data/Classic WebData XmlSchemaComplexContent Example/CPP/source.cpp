//<snippet1>
#using <mscorlib.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Xml::Schema;

class XmlSchemaExamples
{
public:

    static void Main()
    {
        XmlSchema^ schema = gcnew XmlSchema();

        // <xs:complexType name="address">
        XmlSchemaComplexType^ address = gcnew XmlSchemaComplexType();
        schema->Items->Add(address);
        address->Name = "address";

        // <xs:sequence>
        XmlSchemaSequence^ sequence = gcnew XmlSchemaSequence();
        address->Particle = sequence;

        // <xs:element name="name"   type="xs:string"/>
        XmlSchemaElement^ elementName = gcnew XmlSchemaElement();
        sequence->Items->Add(elementName);
        elementName->Name = "name";
        elementName->SchemaTypeName = gcnew XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");

        // <xs:element name="street"   type="xs:string"/>
        XmlSchemaElement^ elementStreet = gcnew XmlSchemaElement();
        sequence->Items->Add(elementStreet);
        elementStreet->Name = "street";
        elementStreet->SchemaTypeName = gcnew XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");

        // <xs:element name="city"   type="xs:string"/>
        XmlSchemaElement^ elementCity = gcnew XmlSchemaElement();
        sequence->Items->Add(elementCity);
        elementCity->Name = "city";
        elementCity->SchemaTypeName = gcnew XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");

        // <xs:complexType name="USAddress">
        XmlSchemaComplexType^ USAddress = gcnew XmlSchemaComplexType();
        schema->Items->Add(USAddress);
        USAddress->Name = "USAddress";

        // <xs:complexContent>
        XmlSchemaComplexContent^ complexContent = gcnew XmlSchemaComplexContent();
        USAddress->ContentModel = complexContent;

        // <xs:extension base="address">
        XmlSchemaComplexContentExtension^ extensionAddress = gcnew XmlSchemaComplexContentExtension();
        complexContent->Content = extensionAddress;
        extensionAddress->BaseTypeName = gcnew XmlQualifiedName("address");

        // <xs:sequence>
        XmlSchemaSequence^ sequence2 = gcnew XmlSchemaSequence();
        extensionAddress->Particle = sequence2;

        // <xs:element name="state" type="xs:string"/>
        XmlSchemaElement^ elementUSState = gcnew XmlSchemaElement();
        sequence2->Items->Add(elementUSState);
        elementUSState->Name = "state";
        elementUSState->SchemaTypeName = gcnew XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");


        // <xs:element name="zipcode" type="xs:positiveInteger"/>
        XmlSchemaElement^ elementZipcode = gcnew XmlSchemaElement();
        sequence2->Items->Add(elementZipcode);
        elementZipcode->Name = "zipcode";
        elementZipcode->SchemaTypeName = gcnew XmlQualifiedName("positiveInteger", "http://www.w3.org/2001/XMLSchema");

        XmlSchemaSet^ schemaSet = gcnew XmlSchemaSet();
        schemaSet->ValidationEventHandler += gcnew ValidationEventHandler(ValidationCallbackOne);
        schemaSet->Add(schema);
        schemaSet->Compile();

        XmlSchema^ compiledSchema;

        for each (XmlSchema^ schema1 in schemaSet->Schemas())
        {
            compiledSchema = schema1;
        }

        XmlNamespaceManager^ nsmgr = gcnew XmlNamespaceManager(gcnew NameTable());
        nsmgr->AddNamespace("xs", "http://www.w3.org/2001/XMLSchema");
		compiledSchema->Write(Console::Out, nsmgr);
    }

    static void ValidationCallbackOne(Object^ sender, ValidationEventArgs^ args)
    {
		Console::WriteLine(args->Message);
    }
};

int main()
{
	XmlSchemaExamples::Main();
    return 0;
};
//</snippet1>