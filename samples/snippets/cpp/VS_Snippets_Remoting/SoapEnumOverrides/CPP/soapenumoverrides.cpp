

//<Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;
public enum class GroupType
{
   // Use the SoapEnumAttribute to instruct the XmlSerializer
   // to generate Small and Large instead of A and B.
   [SoapEnum("Small")]
   A,
   [SoapEnum("Large")]
   B
};

public ref class Group
{
public:
   String^ GroupName;
   GroupType Grouptype;
};

public ref class Run
{
public:
   void SerializeObject( String^ filename )
   {
      // Create an instance of the XmlSerializer Class.
      XmlTypeMapping^ mapp = (gcnew SoapReflectionImporter)->ImportTypeMapping( Group::typeid );
      XmlSerializer^ mySerializer = gcnew XmlSerializer( mapp );

      // Writing the file requires a TextWriter.
      TextWriter^ writer = gcnew StreamWriter( filename );

      // Create an instance of the Class that will be serialized.
      Group^ myGroup = gcnew Group;

      // Set the Object* properties.
      myGroup->GroupName = ".NET";
      myGroup->Grouptype = GroupType::A;

      // Serialize the Class, and close the TextWriter.
      mySerializer->Serialize( writer, myGroup );
      writer->Close();
   }

   void SerializeOverride( String^ fileName )
   {
      SoapAttributeOverrides^ soapOver = gcnew SoapAttributeOverrides;
      SoapAttributes^ SoapAtts = gcnew SoapAttributes;

      // Add a SoapEnumAttribute for the GroupType::A enumerator.       
      // Instead of 'A'  it will be S"West".
      SoapEnumAttribute^ soapEnum = gcnew SoapEnumAttribute( "West" );

      // Override the S"A" enumerator.
      SoapAtts->GroupType::SoapEnum = soapEnum;
      soapOver->Add( GroupType::typeid, "A", SoapAtts );

      // Add another SoapEnumAttribute for the GroupType::B enumerator.
      // Instead of //B// it will be S"East".
      SoapAtts = gcnew SoapAttributes;
      soapEnum = gcnew SoapEnumAttribute;
      soapEnum->Name = "East";
      SoapAtts->GroupType::SoapEnum = soapEnum;
      soapOver->Add( GroupType::typeid, "B", SoapAtts );

      // Create an XmlSerializer used for overriding.
      XmlTypeMapping^ map = (gcnew SoapReflectionImporter( soapOver ))->ImportTypeMapping( Group::typeid );
      XmlSerializer^ ser = gcnew XmlSerializer( map );
      Group^ myGroup = gcnew Group;
      myGroup->GroupName = ".NET";
      myGroup->Grouptype = GroupType::B;

      // Writing the file requires a TextWriter.
      TextWriter^ writer = gcnew StreamWriter( fileName );
      ser->Serialize( writer, myGroup );
      writer->Close();
   }
};

int main()
{
   Run^ test = gcnew Run;
   test->SerializeObject( "SoapEnum.xml" );
   test->SerializeOverride( "SoapOverride.xml" );
   Console::WriteLine( "Fininished writing two files" );
}
//</Snippet1>
