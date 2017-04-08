

//<Snippet1>
#using <System.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;
using namespace System::Xml::Schema;
using namespace System::ComponentModel;
public ref class Group
{
public:

   // The default is set to .NET.

   [DefaultValue(".NET")]
   String^ GroupName;
};

public ref class Run
{
public:
   void SerializeOriginal( String^ filename )
   {
      // Create an instance of the XmlSerializer class.
      XmlSerializer^ mySerializer = gcnew XmlSerializer( Group::typeid );

      // Writing the file requires a TextWriter.
      TextWriter^ writer = gcnew StreamWriter( filename );

      // Create an instance of the class that will be serialized.
      Group^ myGroup = gcnew Group;

      // Setting the GroupName to '.NET' is like not setting it at all
      // because it is the default value. So no value will be 
      // serialized, and on deserialization it will appear as a blank.
      myGroup->GroupName = ".NET";

      // Serialize the class, and close the TextWriter.
      mySerializer->Serialize( writer, myGroup );
      writer->Close();
   }

   void SerializeOverride( String^ filename )
   {
      // Create an instance of the XmlSerializer class
      // that overrides the serialization.
      XmlSerializer^ overRideSerializer = CreateOverrideSerializer();

      // Writing the file requires a TextWriter.
      TextWriter^ writer = gcnew StreamWriter( filename );

      // Create an instance of the class that will be serialized.
      Group^ myGroup = gcnew Group;

      // The  specifies that the default value is now 
      // 'Team1'. So setting the GroupName to '.NET' means
      // the value will be serialized.
      myGroup->GroupName = ".NET";

      // Serialize the class, and close the TextWriter.
      overRideSerializer->Serialize( writer, myGroup );
      writer->Close();
   }

   void DeserializeOriginal( String^ filename )
   {
      // Create an instance of the XmlSerializer class.
      XmlSerializer^ mySerializer = gcnew XmlSerializer( Group::typeid );

      // Reading the file requires a TextReader.
      TextReader^ reader = gcnew StreamReader( filename );

      // Deserialize and cast the Object*.
      Group^ myGroup;
      myGroup = safe_cast<Group^>(mySerializer->Deserialize( reader ));
      Console::WriteLine( myGroup->GroupName );
      Console::WriteLine();
   }

   void DeserializeOverride( String^ filename )
   {
      // Create an instance of the XmlSerializer class.
      XmlSerializer^ overRideSerializer = CreateOverrideSerializer();

      // Reading the file requires a TextReader.
      TextReader^ reader = gcnew StreamReader( filename );

      // Deserialize and cast the Object*.
      Group^ myGroup;
      myGroup = safe_cast<Group^>(overRideSerializer->Deserialize( reader ));
      Console::WriteLine( myGroup->GroupName );
   }

private:
   XmlSerializer^ CreateOverrideSerializer()
   {
      SoapAttributeOverrides^ mySoapAttributeOverrides = gcnew SoapAttributeOverrides;
      SoapAttributes^ soapAtts = gcnew SoapAttributes;

      // Create a new DefaultValueAttribute Object* for the GroupName
      // property.
      DefaultValueAttribute^ newDefault = gcnew DefaultValueAttribute( "Team1" );
      soapAtts->SoapDefaultValue = newDefault;
      mySoapAttributeOverrides->Add( Group::typeid, "GroupName", soapAtts );

      // Create an XmlTypeMapping that is used to create an instance 
      // of the XmlSerializer. Then return the XmlSerializer Object*.
      XmlTypeMapping^ myMapping = (gcnew SoapReflectionImporter( mySoapAttributeOverrides ))->ImportTypeMapping( Group::typeid );
      XmlSerializer^ ser = gcnew XmlSerializer( myMapping );
      return ser;
   }
};

int main()
{
   Run^ test = gcnew Run;
   test->SerializeOriginal( "SoapOriginal.xml" );
   test->SerializeOverride( "mySoapAttributeOverridesideAttributes.xml" );
   test->DeserializeOriginal( "SoapOriginal.xml" );
   test->DeserializeOverride( "mySoapAttributeOverridesideAttributes.xml" );
}
//</Snippet1>
