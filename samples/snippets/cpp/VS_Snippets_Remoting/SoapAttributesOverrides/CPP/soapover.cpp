

//<Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Text;
using namespace System::Xml;
using namespace System::Xml::Serialization;
using namespace System::Xml::Schema;
ref class Car;

// SoapInclude allows Vehicle to accept Car type.

[SoapInclude(Car::typeid)]
public ref class Vehicle abstract
{
public:
   String^ licenseNumber;
   DateTime makeDate;
};

public ref class Car: public Vehicle{};

public enum class GroupType
{
   // These enums can be overridden.
   [SoapEnum("Small")]
   A,
   [SoapEnum("Large")]
   B
};

public ref class Group
{
public:

   [SoapAttributeAttribute(Namespace="http://www.cpandl.com")]
   String^ GroupName;

   [SoapAttributeAttribute(DataType="base64Binary")]
   array<Byte>^GroupNumber;

   [SoapAttributeAttribute(DataType="date",AttributeName="CreationDate")]
   DateTime Today;

   [SoapElement(DataType="nonNegativeInteger",ElementName="PosInt")]
   String^ PostitiveInt;

   // This is ignored when serialized unless it's overridden.

   [SoapIgnore]
   bool IgnoreThis;
   GroupType Grouptype;
   Vehicle^ MyVehicle;

   // The SoapInclude allows the method to return a Car.

   [SoapInclude(Car::typeid)]
   Vehicle^ myCar( String^ licNumber )
   {
      Vehicle^ v;
      if ( licNumber->Equals( "" ) )
      {
         v = gcnew Car;
         v->licenseNumber = "!!!!!!";
      }
      else
      {
         v = gcnew Car;
         v->licenseNumber = licNumber;
      }

      return v;
   }
};

public ref class Run
{
public:
   static void main()
   {
      Run^ test = gcnew Run;
      test->SerializeOriginal( "SoapOriginal.xml" );
      test->SerializeOverride( "SoapOverrides.xml" );
      test->DeserializeOriginal( "SoapOriginal.xml" );
      test->DeserializeOverride( "SoapOverrides.xml" );
   }

   void SerializeOriginal( String^ filename )
   {
      // Create an instance of the XmlSerializer class.
      XmlTypeMapping^ myMapping = (gcnew SoapReflectionImporter)->ImportTypeMapping( Group::typeid );
      XmlSerializer^ mySerializer = gcnew XmlSerializer( myMapping );
      Group^ myGroup = MakeGroup();

      // Writing the file requires a TextWriter.
      XmlTextWriter^ writer = gcnew XmlTextWriter( filename,Encoding::UTF8 );
      writer->Formatting = Formatting::Indented;
      writer->WriteStartElement( "wrapper" );

      // Serialize the class, and close the TextWriter.
      mySerializer->Serialize( writer, myGroup );
      writer->WriteEndElement();
      writer->Close();
   }

   void SerializeOverride( String^ filename )
   {
      // Create an instance of the XmlSerializer class
      // that overrides the serialization.
      XmlSerializer^ overRideSerializer = CreateOverrideSerializer();
      Group^ myGroup = MakeGroup();

      // Writing the file requires a TextWriter.
      XmlTextWriter^ writer = gcnew XmlTextWriter( filename,Encoding::UTF8 );
      writer->Formatting = Formatting::Indented;
      writer->WriteStartElement( "wrapper" );

      // Serialize the class, and close the TextWriter.
      overRideSerializer->Serialize( writer, myGroup );
      writer->WriteEndElement();
      writer->Close();
   }

private:
   Group^ MakeGroup()
   {
      // Create an instance of the class that will be serialized.
      Group^ myGroup = gcnew Group;

      // Set the object properties.
      myGroup->GroupName = ".NET";
      array<Byte>^hexByte = {Convert::ToByte( 100 ),Convert::ToByte( 50 )};
      myGroup->GroupNumber = hexByte;
      DateTime myDate = DateTime(2002,5,2);
      myGroup->Today = myDate;
      myGroup->PostitiveInt = "10000";
      myGroup->IgnoreThis = true;
      myGroup->Grouptype = GroupType::B;
      Car^ thisCar = dynamic_cast<Car^>(myGroup->myCar( "1234566" ));
      myGroup->MyVehicle = thisCar;
      return myGroup;
   }

public:
   void DeserializeOriginal( String^ filename )
   {
      // Create an instance of the XmlSerializer class.
      XmlTypeMapping^ myMapping = (gcnew SoapReflectionImporter)->ImportTypeMapping( Group::typeid );
      XmlSerializer^ mySerializer = gcnew XmlSerializer( myMapping );

      // Reading the file requires an  XmlTextReader.
      XmlTextReader^ reader = gcnew XmlTextReader( filename );
      reader->ReadStartElement( "wrapper" );

      // Deserialize and cast the object.
      Group^ myGroup;
      myGroup = dynamic_cast<Group^>(mySerializer->Deserialize( reader ));
      reader->ReadEndElement();
      reader->Close();
   }

   void DeserializeOverride( String^ filename )
   {
      // Create an instance of the XmlSerializer class.
      XmlSerializer^ overRideSerializer = CreateOverrideSerializer();

      // Reading the file requires an XmlTextReader.
      XmlTextReader^ reader = gcnew XmlTextReader( filename );
      reader->ReadStartElement( "wrapper" );

      // Deserialize and cast the object.
      Group^ myGroup;
      myGroup = dynamic_cast<Group^>(overRideSerializer->Deserialize( reader ));
      reader->ReadEndElement();
      reader->Close();
      ReadGroup( myGroup );
   }

private:
   void ReadGroup( Group^ myGroup )
   {
      Console::WriteLine( myGroup->GroupName );
      Console::WriteLine( myGroup->GroupNumber[ 0 ] );
      Console::WriteLine( myGroup->GroupNumber[ 1 ] );
      Console::WriteLine( myGroup->Today );
      Console::WriteLine( myGroup->PostitiveInt );
      Console::WriteLine( myGroup->IgnoreThis );
      Console::WriteLine();
   }

   XmlSerializer^ CreateOverrideSerializer()
   {
      SoapAttributeOverrides^ mySoapAttributeOverrides = gcnew SoapAttributeOverrides;
      SoapAttributes^ soapAtts = gcnew SoapAttributes;
      SoapElementAttribute^ mySoapElement = gcnew SoapElementAttribute;
      mySoapElement->ElementName = "xxxx";
      soapAtts->SoapElement = mySoapElement;
      mySoapAttributeOverrides->Add( Group::typeid, "PostitiveInt", soapAtts );

      // Override the IgnoreThis property.
      SoapIgnoreAttribute^ myIgnore = gcnew SoapIgnoreAttribute;
      soapAtts = gcnew SoapAttributes;
      soapAtts->SoapIgnore = false;
      mySoapAttributeOverrides->Add( Group::typeid, "IgnoreThis", soapAtts );

      // Override the GroupType enumeration. 
      soapAtts = gcnew SoapAttributes;
      SoapEnumAttribute^ xSoapEnum = gcnew SoapEnumAttribute;
      xSoapEnum->Name = "Over1000";
      soapAtts->GroupType::SoapEnum = xSoapEnum;

      // Add the SoapAttributes to the 
      // mySoapAttributeOverridesrides object.
      mySoapAttributeOverrides->Add( GroupType::typeid, "A", soapAtts );

      // Create second enumeration and add it.
      soapAtts = gcnew SoapAttributes;
      xSoapEnum = gcnew SoapEnumAttribute;
      xSoapEnum->Name = "ZeroTo1000";
      soapAtts->GroupType::SoapEnum = xSoapEnum;
      mySoapAttributeOverrides->Add( GroupType::typeid, "B", soapAtts );

      // Override the Group type.
      soapAtts = gcnew SoapAttributes;
      SoapTypeAttribute^ soapType = gcnew SoapTypeAttribute;
      soapType->TypeName = "Team";
      soapAtts->SoapType = soapType;
      mySoapAttributeOverrides->Add( Group::typeid, soapAtts );

      // Create an XmlTypeMapping that is used to create an instance 
      // of the XmlSerializer. Then return the XmlSerializer object.
      XmlTypeMapping^ myMapping = (gcnew SoapReflectionImporter( mySoapAttributeOverrides ))->ImportTypeMapping( Group::typeid );
      XmlSerializer^ ser = gcnew XmlSerializer( myMapping );
      return ser;
   }
};

int main()
{
   Run::main();
}
//</Snippet1>
