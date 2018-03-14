

//<Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;
public ref class Group
{
public:

   // This attribute will be overridden.

   [SoapAttributeAttribute(Namespace="http://www.cpandl.com")]
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

      // Set the Object* properties.
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

      // Create a new SoapAttributeAttribute to  the 
      // one applied to the Group class. The resulting XML 
      // stream will use the new namespace and attribute name.
      SoapAttributeAttribute^ mySoapAttribute = gcnew SoapAttributeAttribute;
      mySoapAttribute->AttributeName = "TeamName";

      // Change the Namespace.
      mySoapAttribute->Namespace = "http://www.cohowinery.com";
      mySoapAttributes->SoapAttribute = mySoapAttribute;
      mySoapAttributeOverrides->Add( Group::typeid, "GroupName", mySoapAttributes );
      XmlTypeMapping^ myMapping = (gcnew SoapReflectionImporter( mySoapAttributeOverrides ))->ImportTypeMapping( Group::typeid );
      XmlSerializer^ ser = gcnew XmlSerializer( myMapping );
      return ser;
   }
};

int main()
{
   Run^ test = gcnew Run;
   test->SerializeOverride( "SoapOveride.xml" );
}

//<?xml version=S"1.0" encoding=S"utf-8" ?> 
// <Group xmlns:xsi=S"http://www.w3.org/2001/XMLSchema-instance" 
//xmlns:xsd=S"http://www.w3.org/2001/XMLSchema" n1:TeamName=S".NET" 
//xmlns:n1=S"http://www.cohowinery" /> 
//</Snippet1>
