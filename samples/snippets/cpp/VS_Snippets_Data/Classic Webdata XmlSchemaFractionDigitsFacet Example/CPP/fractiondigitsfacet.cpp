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

        // <xs:simpleType name="RatingType">
        XmlSchemaSimpleType^ RatingType = gcnew XmlSchemaSimpleType();
        RatingType->Name = "RatingType";

        // <xs:restriction base="xs:number">
        XmlSchemaSimpleTypeRestriction^ restriction = gcnew XmlSchemaSimpleTypeRestriction();
        restriction->BaseTypeName = gcnew XmlQualifiedName("decimal", "http://www.w3.org/2001/XMLSchema");

        // <xs:totalDigits value="2"/>
        XmlSchemaTotalDigitsFacet^ totalDigits = gcnew XmlSchemaTotalDigitsFacet();
        totalDigits->Value = "2";
        restriction->Facets->Add(totalDigits);

        // <xs:fractionDigits value="1"/>
        XmlSchemaFractionDigitsFacet^ fractionDigits = gcnew XmlSchemaFractionDigitsFacet();
        fractionDigits->Value = "1";
        restriction->Facets->Add(fractionDigits);

        RatingType->Content = restriction;

        schema->Items->Add(RatingType);

        // <xs:element name="movie">
        XmlSchemaElement^ element = gcnew XmlSchemaElement();
        element->Name = "movie";

        // <xs:complexType>
        XmlSchemaComplexType^ complexType = gcnew XmlSchemaComplexType();

        // <xs:attribute name="rating" type="RatingType"/>
        XmlSchemaAttribute^ ratingAttribute = gcnew XmlSchemaAttribute();
        ratingAttribute->Name = "rating";
        ratingAttribute->SchemaTypeName = gcnew XmlQualifiedName("RatingType", "");
        complexType->Attributes->Add(ratingAttribute);

        element->SchemaType = complexType;

        schema->Items->Add(element);

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