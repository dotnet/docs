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

        // <xs:element name="selected"/>
        XmlSchemaElement^ xeSelected = gcnew XmlSchemaElement();
        xeSelected->Name = "selected";
        schema->Items->Add(xeSelected);

        // <xs:element name="unselected"/>
        XmlSchemaElement^ xeUnselected = gcnew XmlSchemaElement();
        xeUnselected->Name = "unselected";
        schema->Items->Add(xeUnselected);

        // <xs:element name="dimpled"/>
        XmlSchemaElement^ xeDimpled = gcnew XmlSchemaElement();
        xeDimpled->Name = "dimpled";
        schema->Items->Add(xeDimpled);

        // <xs:element name="perforated"/>
        XmlSchemaElement^ xePerforated = gcnew XmlSchemaElement();
        xePerforated->Name = "perforated";
        schema->Items->Add(xePerforated);

        // <xs:complexType name="chadState">
        XmlSchemaComplexType^ chadState = gcnew XmlSchemaComplexType();
        schema->Items->Add(chadState);
        chadState->Name = "chadState";

        // <xs:choice minOccurs="1" maxOccurs="1">
        XmlSchemaChoice^ choice = gcnew XmlSchemaChoice();
        chadState->Particle = choice;
        choice->MinOccurs = 1;
        choice->MaxOccurs = 1;

        // <xs:element ref="selected"/>
        XmlSchemaElement^ elementSelected = gcnew XmlSchemaElement();
        choice->Items->Add(elementSelected);
        elementSelected->RefName = gcnew XmlQualifiedName("selected");

        // <xs:element ref="unselected"/>
        XmlSchemaElement^ elementUnselected = gcnew XmlSchemaElement();
        choice->Items->Add(elementUnselected);
        elementUnselected->RefName = gcnew XmlQualifiedName("unselected");

        // <xs:element ref="dimpled"/>
        XmlSchemaElement^ elementDimpled = gcnew XmlSchemaElement();
        choice->Items->Add(elementDimpled);
        elementDimpled->RefName = gcnew XmlQualifiedName("dimpled");

        // <xs:element ref="perforated"/>
        XmlSchemaElement^ elementPerforated = gcnew XmlSchemaElement();
        choice->Items->Add(elementPerforated);
        elementPerforated->RefName = gcnew XmlQualifiedName("perforated");

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