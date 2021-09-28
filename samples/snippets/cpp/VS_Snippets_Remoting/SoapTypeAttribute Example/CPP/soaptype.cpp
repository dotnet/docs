

//<Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;

[SoapType("EmployeeType")]
public ref class Employee
{
public:
   String^ Name;
};


// The SoapType is overridden when the
// SerializeOverride  method is called.

[SoapType("SoapGroupType","http://www.cohowinery.com")]
public ref class Group
{
public:
   String^ GroupName;
   array<Employee^>^Employees;
};

public ref class Run
{
public:
   void SerializeOriginal( String^ filename )
   {
      // Create an instance of the XmlSerializer class that
      // can be used for serializing as a SOAP message.
      XmlTypeMapping^ mapp = (gcnew SoapReflectionImporter)->ImportTypeMapping( Group::typeid );
      XmlSerializer^ mySerializer = gcnew XmlSerializer( mapp );

      // Writing the file requires a TextWriter.
      TextWriter^ writer = gcnew StreamWriter( filename );

      // Create an XML text writer.
      XmlTextWriter^ xmlWriter = gcnew XmlTextWriter( writer );
      xmlWriter->Formatting = Formatting::Indented;
      xmlWriter->Indentation = 2;

      // Create an instance of the class that will be serialized.
      Group^ myGroup = gcnew Group;

      // Set the Object* properties.
      myGroup->GroupName = ".NET";
      Employee^ e1 = gcnew Employee;
      e1->Name = "Pat";
      myGroup->Employees = gcnew array<Employee^>(1);
      myGroup->Employees[ 0 ] = e1;

      // Write the root element.
      xmlWriter->WriteStartElement( "root" );

      // Serialize the class.
      mySerializer->Serialize( xmlWriter, myGroup );

      // Close the root tag.
      xmlWriter->WriteEndElement();

      // Close the XmlWriter.
      xmlWriter->Close();

      // Close the TextWriter.
      writer->Close();
   }

   void SerializeOverride( String^ filename )
   {
      // Create an instance of the XmlSerializer class that
      // uses a SoapAttributeOverrides Object*.
      XmlSerializer^ mySerializer = CreateOverrideSerializer();

      // Writing the file requires a TextWriter.
      TextWriter^ writer = gcnew StreamWriter( filename );

      // Create an XML text writer.
      XmlTextWriter^ xmlWriter = gcnew XmlTextWriter( writer );
      xmlWriter->Formatting = Formatting::Indented;
      xmlWriter->Indentation = 2;

      // Create an instance of the class that will be serialized.
      Group^ myGroup = gcnew Group;

      // Set the Object* properties.
      myGroup->GroupName = ".NET";
      Employee^ e1 = gcnew Employee;
      e1->Name = "Pat";
      myGroup->Employees = gcnew array<Employee^>(1);
      myGroup->Employees[ 0 ] = e1;

      // Write the root element.
      xmlWriter->WriteStartElement( "root" );

      // Serialize the class.
      mySerializer->Serialize( xmlWriter, myGroup );

      // Close the root tag.
      xmlWriter->WriteEndElement();

      // Close the XmlWriter.
      xmlWriter->Close();

      // Close the TextWriter.
      writer->Close();
   }

   void DeserializeObject( String^ filename )
   {
      // Create an instance of the XmlSerializer class.
      XmlSerializer^ mySerializer = CreateOverrideSerializer();

      // Reading the file requires a TextReader.
      TextReader^ reader = gcnew StreamReader( filename );

      // Create an XML text reader.
      XmlTextReader^ xmlReader = gcnew XmlTextReader( reader );
      xmlReader->ReadStartElement();

      // Deserialize and cast the object.
      Group^ myGroup;
      myGroup = dynamic_cast<Group^>(mySerializer->Deserialize( xmlReader ));
      xmlReader->ReadEndElement();
      Console::WriteLine( "The GroupName is {0}", myGroup->GroupName );
      Console::WriteLine( "Look at the SoapType.xml and SoapType2.xml "
      "files for the generated XML." );

      // Close the readers.
      xmlReader->Close();
      reader->Close();
   }

private:
   XmlSerializer^ CreateOverrideSerializer()
   {
      // Create and return an XmlSerializer instance used to
      //  and create SOAP messages.
      SoapAttributeOverrides^ mySoapAttributeOverrides = gcnew SoapAttributeOverrides;
      SoapAttributes^ soapAtts = gcnew SoapAttributes;

      // Override the SoapTypeAttribute.
      SoapTypeAttribute^ soapType = gcnew SoapTypeAttribute;
      soapType->TypeName = "Team";
      soapType->IncludeInSchema = false;
      soapType->Namespace = "http://www.microsoft.com";
      soapAtts->SoapType = soapType;
      mySoapAttributeOverrides->Add( Group::typeid, soapAtts );

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
   test->SerializeOriginal( "SoapType.xml" );
   test->SerializeOverride( "SoapType2.xml" );
   test->DeserializeObject( "SoapType2.xml" );
}
//</Snippet1>
