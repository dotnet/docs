

// System::Xml::Serialization::XmlTypeAttribute.XmlTypeAttribute()
// System::Xml::Serialization::XmlTypeAttribute.XmlTypeAttribute(String*)
// The following example demonstrates the contructors 'XmlTypeAttribute()'
// and 'XmlTypeAttribute(String*)' of class 'XmlTypeAttribute'.
// This program demonstrates 'Person' and 'Address' classes to 
// which the 'XmlTypeAttribute' has been applied.This sample then 
// serializes an Object* of class 'Person' into an XML document.
// <Snippet1>
// <Snippet2>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml::Serialization;
public ref class Address
{
public:
   String^ state;
   String^ zip;
};

public ref class Person
{
public:
   String^ personName;
   Address^ address;
};

public ref class PersonTypeAttribute
{
public:
   XmlSerializer^ CreateOverrider()
   {
      XmlAttributeOverrides^ personOverride = gcnew XmlAttributeOverrides;
      XmlAttributes^ personAttributes = gcnew XmlAttributes;
      XmlTypeAttribute^ personType = gcnew XmlTypeAttribute;
      personType->TypeName = "Employee";
      personType->Namespace = "http://www.microsoft.com";
      personAttributes->XmlType = personType;
      XmlAttributes^ addressAttributes = gcnew XmlAttributes;

      // Create 'XmlTypeAttribute' with 'TypeName' as an argument.
      XmlTypeAttribute^ addressType = gcnew XmlTypeAttribute( "Address" );
      addressType->Namespace = "http://www.microsoft.com";
      addressAttributes->XmlType = addressType;
      personOverride->Add( Person::typeid, personAttributes );
      personOverride->Add( Address::typeid, addressAttributes );
      XmlSerializer^ myXmlSerializer = gcnew XmlSerializer( Person::typeid,personOverride );
      return myXmlSerializer;
   }

   void SerializeObject( String^ filename )
   {
      XmlSerializer^ myXmlSerializer = CreateOverrider();
      Address^ myAddress = gcnew Address;
      myAddress->state = "AAA";
      myAddress->zip = "11111";
      Person^ myPerson = gcnew Person;
      myPerson->personName = "Smith";
      myPerson->address = myAddress;

      // Serialize to a file.
      TextWriter^ writer = gcnew StreamWriter( filename );
      myXmlSerializer->Serialize( writer, myPerson );
   }
};

int main()
{
   PersonTypeAttribute^ myPersonTypeAttribute = gcnew PersonTypeAttribute;
   myPersonTypeAttribute->SerializeObject( "XmlType.xml" );
}
// </Snippet2> 
// </Snippet1>
