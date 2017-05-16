//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Xml::Schema;

ref class XMLSchemaExamples
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

		// <xs:simpleType name="LotteryNumber">
		XmlSchemaSimpleType^ LotteryNumberType = gcnew XmlSchemaSimpleType();
		LotteryNumberType->Name = "LotteryNumber";

		// <xs:restriction base="xs:int">
		XmlSchemaSimpleTypeRestriction^ LotteryNumberRestriction = gcnew XmlSchemaSimpleTypeRestriction();
		LotteryNumberRestriction->BaseTypeName = gcnew XmlQualifiedName("int", "http://www.w3.org/2001/XMLSchema");

		// <xs:minInclusive value="1"/>
		XmlSchemaMinInclusiveFacet^ minInclusive = gcnew XmlSchemaMinInclusiveFacet();
		minInclusive->Value = "1";
		LotteryNumberRestriction->Facets->Add(minInclusive);

		// <xs:maxInclusive value="99"/>
		XmlSchemaMaxInclusiveFacet^ maxInclusive = gcnew XmlSchemaMaxInclusiveFacet();
		maxInclusive->Value = "99";
		LotteryNumberRestriction->Facets->Add(maxInclusive);

		LotteryNumberType->Content = LotteryNumberRestriction;
		schema->Items->Add(LotteryNumberType);

		// <xs:simpleType name="LotteryNumberList">
		XmlSchemaSimpleType^ LotteryNumberListType = gcnew XmlSchemaSimpleType();
		LotteryNumberListType->Name = "LotteryNumberList";

		// <xs:list itemType="LotteryNumber"/>
		XmlSchemaSimpleTypeList^ list = gcnew XmlSchemaSimpleTypeList();
		list->ItemTypeName = gcnew XmlQualifiedName("LotteryNumber", "");
		LotteryNumberListType->Content = list;

		schema->Items->Add(LotteryNumberListType);

		// <xs:simpleType name="LotteryNumbers">
		XmlSchemaSimpleType^ LotteryNumbersType = gcnew XmlSchemaSimpleType();
		LotteryNumbersType->Name = "LotteryNumbers";

		// <xs:restriction base="LotteryNumberList">
		XmlSchemaSimpleTypeRestriction^ LotteryNumbersRestriction = gcnew XmlSchemaSimpleTypeRestriction();
		LotteryNumbersRestriction->BaseTypeName = gcnew XmlQualifiedName("LotteryNumberList", "");

		// <xs:length value="5"/>
		XmlSchemaLengthFacet^ length = gcnew XmlSchemaLengthFacet();
		length->Value = "5";
		LotteryNumbersRestriction->Facets->Add(length);

		LotteryNumbersType->Content = LotteryNumbersRestriction;

		schema->Items->Add(LotteryNumbersType);

		// <xs:element name="TodaysLottery" type="LotteryNumbers">
		XmlSchemaElement^ TodaysLottery = gcnew XmlSchemaElement();
		TodaysLottery->Name = "TodaysLottery";
		TodaysLottery->SchemaTypeName = gcnew XmlQualifiedName("LotteryNumbers", "");

		schema->Items->Add(TodaysLottery);

		XmlSchemaSet^ schemaSet = gcnew XmlSchemaSet();
		schemaSet->ValidationEventHandler += gcnew ValidationEventHandler(ValidationCallbackOne);
		schemaSet->Add(schema);
		schemaSet->Compile();

		XmlSchema^ compiledSchema = nullptr;

		for each (XmlSchema^ schema1 in schemaSet->Schemas())
		{
			compiledSchema = schema1;
		}

		XmlNamespaceManager^ nsmgr = gcnew XmlNamespaceManager(gcnew NameTable());
		nsmgr->AddNamespace("xs", "http://www.w3.org/2001/XMLSchema");
		compiledSchema->Write(Console::Out, nsmgr);
	}
};

int main()
{
	XMLSchemaExamples::Main();
	return 0;
}
//</snippet1>