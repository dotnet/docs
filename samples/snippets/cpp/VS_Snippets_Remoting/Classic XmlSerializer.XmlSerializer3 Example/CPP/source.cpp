

// <Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;
ref class Address;
ref class Phone;

// This defines the object that will be serialized.
public ref class Teacher
{
public:
   String^ Name;
   Teacher(){}

   /* Note that the Info field returns an array of objects.
         Any object can be added to the array by adding the
         object type to the array passed to the extraTypes argument. */

   [XmlArray(ElementName="ExtraInfo",IsNullable=true)]
   array<Object^>^Info;
   Phone^ PhoneInfo;
};


// This defines one of the extra types to be included.
public ref class Address
{
public:
   String^ City;
   Address(){}

   Address( String^ city )
   {
      City = city;
   }
};

// Another extra type to include.
public ref class Phone
{
public:
   String^ PhoneNumber;
   Phone(){}

   Phone( String^ phoneNumber )
   {
      PhoneNumber = phoneNumber;
   }
};

// Another type, derived from Phone
public ref class InternationalPhone: public Phone
{
public:
   String^ CountryCode;
   InternationalPhone(){}

   InternationalPhone( String^ countryCode )
   {
      CountryCode = countryCode;
   }
};

public ref class Run
{
public:
   static void main()
   {
      Run^ test = gcnew Run;
      test->SerializeObject( "Teacher.xml" );
      test->DeserializeObject( "Teacher.xml" );
   }

private:
   void SerializeObject( String^ filename )
   {
      // Writing the file requires a TextWriter.
      TextWriter^ myStreamWriter = gcnew StreamWriter( filename );

      // Create a Type array.
      array<Type^>^extraTypes = gcnew array<Type^>(3);
      extraTypes[ 0 ] = Address::typeid;
      extraTypes[ 1 ] = Phone::typeid;
      extraTypes[ 2 ] = InternationalPhone::typeid;

      // Create the XmlSerializer instance.
      XmlSerializer^ mySerializer = gcnew XmlSerializer( Teacher::typeid,extraTypes );
      Teacher^ teacher = gcnew Teacher;
      teacher->Name = "Mike";

      // Add extra types to the Teacher object
      array<Object^>^info = gcnew array<Object^>(2);
      info[ 0 ] = gcnew Address( "Springville" );
      info[ 1 ] = gcnew Phone( "555-0100" );
      teacher->Info = info;
      teacher->PhoneInfo = gcnew InternationalPhone( "000" );
      mySerializer->Serialize( myStreamWriter, teacher );
      myStreamWriter->Close();
   }

   void DeserializeObject( String^ filename )
   {
      // Create a Type array.
      array<Type^>^extraTypes = gcnew array<Type^>(3);
      extraTypes[ 0 ] = Address::typeid;
      extraTypes[ 1 ] = Phone::typeid;
      extraTypes[ 2 ] = InternationalPhone::typeid;

      // Create the XmlSerializer instance.
      XmlSerializer^ mySerializer = gcnew XmlSerializer( Teacher::typeid,extraTypes );

      // Reading a file requires a FileStream.
      FileStream^ fs = gcnew FileStream( filename,FileMode::Open );
      Teacher^ teacher = dynamic_cast<Teacher^>(mySerializer->Deserialize( fs ));

      // Read the extra information.
      Address^ a = dynamic_cast<Address^>(teacher->Info[ 0 ]);
      Phone^ p = dynamic_cast<Phone^>(teacher->Info[ 1 ]);
      InternationalPhone^ Ip = dynamic_cast<InternationalPhone^>(teacher->PhoneInfo);
      Console::WriteLine( teacher->Name );
      Console::WriteLine( a->City );
      Console::WriteLine( p->PhoneNumber );
      Console::WriteLine( Ip->CountryCode );
   }
};

int main()
{
   Run::main();
}
// </Snippet1>
