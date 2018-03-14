//<Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;

// The name of this type will be overridden using
// the SoapTypeAttribute.
public ref class Group
{
public:
   String^ GroupName;
};

public ref class Run
{
public:
   void SerializeOverride( String^ filename )
   {
      // Create an instance of the XmlSerializer class
      // that overrides the serialization.
      XmlSerializer^ overRideSerializer = CreateOverrideSerializer();

      // Writing the file requires a TextWriter.
      TextWriter^ writer = gcnew StreamWriter( filename );

      // Create an instance of the class that will be serialized.
      Group^ myGroup = gcnew Group;

      // Set the object properties.
      myGroup->GroupName = ".NET";

      // Serialize the class, and close the TextWriter.
      overRideSerializer->Serialize( writer, myGroup );
      writer->Close();
   }

private:
   XmlSerializer^ CreateOverrideSerializer()
   {
      SoapAttributeOverrides^ mySoapAttributeOverrides = gcnew SoapAttributeOverrides;
      SoapAttributes^ mySoapAttributes = gcnew SoapAttributes;
      SoapTypeAttribute^ mySoapType = gcnew SoapTypeAttribute;
      mySoapType->TypeName = "Team";
      mySoapAttributes->SoapType = mySoapType;

      // Add the SoapAttributes to the 
      // mySoapAttributeOverridesrides object.
      mySoapAttributeOverrides->Add( Group::typeid, mySoapAttributes );

      // Get the SoapAttributes with the Item property.
      SoapAttributes^ thisSoapAtts = mySoapAttributeOverrides[ Group::typeid ];
      Console::WriteLine( "New serialized type name: {0}", thisSoapAtts->SoapType->TypeName );

      // Create an XmlTypeMapping that is used to create an instance 
      // of the XmlSerializer. Then return the XmlSerializer object.
      XmlTypeMapping^ myMapping = (gcnew SoapReflectionImporter( mySoapAttributeOverrides ))->
            ImportTypeMapping( Group::typeid );
      XmlSerializer^ ser = gcnew XmlSerializer( myMapping );
      return ser;
   }
};

int main()
{
   Run^ test = gcnew Run;
   test->SerializeOverride( "GetSoapAttributes2.xml" );
}
//</Snippet1>
