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

        // <xs:complexType name="phoneNumber">
        XmlSchemaComplexType^ phoneNumber = gcnew XmlSchemaComplexType();
        phoneNumber->Name = "phoneNumber";

        // <xs:sequence>
        XmlSchemaSequence^ phoneNumberSequence = gcnew XmlSchemaSequence();

        // <xs:element name="areaCode"/>
        XmlSchemaElement^ areaCode1 = gcnew XmlSchemaElement();
        areaCode1->MinOccurs = 0;
        areaCode1->MaxOccursString = "1";
        areaCode1->Name = "areaCode";
        phoneNumberSequence->Items->Add(areaCode1);

        // <xs:element name="prefix"/>
        XmlSchemaElement^ prefix1 = gcnew XmlSchemaElement();
        prefix1->MinOccurs = 1;
        prefix1->MaxOccursString = "1";
        prefix1->Name = "prefix";
        phoneNumberSequence->Items->Add(prefix1);

        // <xs:element name="number"/>
        XmlSchemaElement^ number1 = gcnew XmlSchemaElement();
        number1->MinOccurs = 1;
        number1->MaxOccursString = "1";
        number1->Name = "number";
        phoneNumberSequence->Items->Add(number1);

        phoneNumber->Particle = phoneNumberSequence;

        schema->Items->Add(phoneNumber);

        // <xs:complexType name="localPhoneNumber">
        XmlSchemaComplexType^ localPhoneNumber = gcnew XmlSchemaComplexType();
        localPhoneNumber->Name = "localPhoneNumber";

        // <xs:complexContent>
        XmlSchemaComplexContent^ complexContent = gcnew XmlSchemaComplexContent();

        // <xs:restriction base="phoneNumber">
        XmlSchemaComplexContentRestriction^ restriction = gcnew XmlSchemaComplexContentRestriction();
        restriction->BaseTypeName = gcnew XmlQualifiedName("phoneNumber", "");

        // <xs:sequence>
        XmlSchemaSequence^ sequence2 = gcnew XmlSchemaSequence();

        // <xs:element name="areaCode" minOccurs="0"/>
        XmlSchemaElement^ areaCode2 = gcnew XmlSchemaElement();
        areaCode2->MinOccurs = 0;
        areaCode2->MaxOccursString = "1";
        areaCode2->Name = "areaCode";
        sequence2->Items->Add(areaCode2);

        // <xs:element name="prefix"/>
        XmlSchemaElement^ prefix2 = gcnew XmlSchemaElement();
        prefix2->MinOccurs = 1;
        prefix2->MaxOccursString = "1";
        prefix2->Name = "prefix";
        sequence2->Items->Add(prefix2);

        // <xs:element name="number"/>
        XmlSchemaElement^ number2 = gcnew XmlSchemaElement();
        number2->MinOccurs = 1;
        number2->MaxOccursString = "1";
        number2->Name = "number";
        sequence2->Items->Add(number2);

        restriction->Particle = sequence2;
        complexContent->Content = restriction;
        localPhoneNumber->ContentModel = complexContent;

        schema->Items->Add(localPhoneNumber);

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