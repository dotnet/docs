

// <snippet20>
#using <System.Xml.dll>
#using <System.dll>
#using <Person.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml::Serialization;

int main()
{
   XmlSerializer^ serializer = gcnew XmlSerializer( Person::typeid );
   FileStream^ file = gcnew FileStream( "test.xml",FileMode::Open );
   Person^ aPerson = dynamic_cast<Person^>(serializer->Deserialize( file ));
   Console::WriteLine( aPerson );
}
// </snippet20>
