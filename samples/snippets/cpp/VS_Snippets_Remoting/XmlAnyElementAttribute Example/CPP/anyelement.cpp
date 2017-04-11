

//<Snippet1>
#using <system.dll>
#using <system.xml.dll>

using namespace System;
using namespace System::Text;
using namespace System::IO;
using namespace System::Xml::Serialization;
using namespace System::Xml;
using namespace System::Xml::Schema;

[XmlRoot(Namespace="http://www.cohowinery.com")]
public ref class Group
{
public:
   String^ GroupName;

   // This is for serializing Employee elements.

   [XmlAnyElement(Name="Employee")]
   array<XmlElement^>^UnknownEmployees;

   // This is for serializing City elements.   

   [XmlAnyElement
   (Name="City",
   Namespace="http://www.cpandl.com")]
   array<XmlElement^>^UnknownCity;

   // This one is for all other unknown elements.

   [XmlAnyElement]
   array<XmlElement^>^UnknownElements;
};

void SerializeObject( String^ filename )
{
   XmlSerializer^ ser = gcnew XmlSerializer( Group::typeid );

   // Create an XmlNamespaces to use.
   XmlSerializerNamespaces^ namespaces = gcnew XmlSerializerNamespaces;
   namespaces->Add( "c", "http://www.cohowinery.com" );
   namespaces->Add( "i", "http://www.cpandl.com" );
   Group^ myGroup = gcnew Group;

   // Create arrays of arbitrary XmlElement objects.
   // First create an XmlDocument, used to create the 
   // XmlElement objects.
   XmlDocument^ xDoc = gcnew XmlDocument;

   // Create an array of Employee XmlElement objects.
   XmlElement^ El1 = xDoc->CreateElement( "Employee", "http://www.cohowinery.com" );
   El1->InnerText = "John";
   XmlElement^ El2 = xDoc->CreateElement( "Employee", "http://www.cohowinery.com" );
   El2->InnerText = "Joan";
   XmlElement^ El3 = xDoc->CreateElement( "Employee", "http://www.cohowinery.com" );
   El3->InnerText = "Jim";
   array<XmlElement^>^employees = {El1,El2,El3};
   myGroup->UnknownEmployees = employees;

   // Create an array of City XmlElement objects.
   XmlElement^ inf1 = xDoc->CreateElement( "City", "http://www.cpandl.com" );
   inf1->InnerText = "Tokyo";
   XmlElement^ inf2 = xDoc->CreateElement( "City", "http://www.cpandl.com" );
   inf2->InnerText = "New York";
   XmlElement^ inf3 = xDoc->CreateElement( "City", "http://www.cpandl.com" );
   inf3->InnerText = "Rome";
   array<XmlElement^>^cities = {inf1,inf2,inf3};
   myGroup->UnknownCity = cities;
   XmlElement^ xEl1 = xDoc->CreateElement( "bld" );
   xEl1->InnerText = "42";
   XmlElement^ xEl2 = xDoc->CreateElement( "Region" );
   xEl2->InnerText = "West";
   XmlElement^ xEl3 = xDoc->CreateElement( "type" );
   xEl3->InnerText = "Technical";
   array<XmlElement^>^elements = {xEl1,xEl2,xEl3};
   myGroup->UnknownElements = elements;

   // Serialize the class, and close the TextWriter.
   TextWriter^ writer = gcnew StreamWriter( filename );
   ser->Serialize( writer, myGroup, namespaces );
   writer->Close();
}

void DeserializeObject( String^ filename )
{
   XmlSerializer^ ser = gcnew XmlSerializer( Group::typeid );
   FileStream^ fs = gcnew FileStream( filename,FileMode::Open );
   Group^ myGroup;
   myGroup = safe_cast<Group^>(ser->Deserialize( fs ));
   fs->Close();
   for ( int i = 0; i < myGroup->UnknownEmployees->Length; ++i )
   {
      XmlElement^ xEmp = myGroup->UnknownEmployees[ i ];
      Console::WriteLine( "{0}: {1}", xEmp->LocalName, xEmp->InnerText );
   }
   for ( int i = 0; i < myGroup->UnknownCity->Length; ++i )
   {
      XmlElement^ xCity = myGroup->UnknownCity[ i ];
      Console::WriteLine( "{0}: {1}", xCity->LocalName, xCity->InnerText );
   }
   for ( int i = 0; i < myGroup->UnknownElements->Length; ++i )
   {
      XmlElement^ xEmp = myGroup->UnknownElements[ i ];
      Console::WriteLine( "{0}: {1}", xEmp->LocalName, xEmp->InnerText );
   }
}

int main()
{
   SerializeObject(  "AnyElementArray.xml" );
   DeserializeObject(  "AnyElementArray.xml" );
   Console::WriteLine(  "Done" );
}
//</Snippet1>  
