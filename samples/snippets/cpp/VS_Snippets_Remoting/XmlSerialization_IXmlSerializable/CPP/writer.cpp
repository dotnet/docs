

// <snippet10>
#using <System.Xml.dll>
#using <System.dll>
#using <Person.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Xml::Serialization;

int main()
{
   // Create a person object.
   Person ^ fred = gcnew Person( "Fred Flintstone" );

   // Serialize the object to a file.
   XmlTextWriter^ writer = gcnew XmlTextWriter( "test.xml", nullptr );
   XmlSerializer^ serializer = gcnew XmlSerializer( Person::typeid );
   serializer->Serialize( writer, fred );
}
// </snippet10>
