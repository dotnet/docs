

// <Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml::Serialization;

public ref class Person
{
public:
   String^ Name;
};

public ref class Manager: public Person
{
public:
   int Rank;
};

public ref class Group
{
public:

   /* The Type property instructs the XmlSerializer to accept both
      the Person and Manager types in the array. */

   [XmlArrayItem(Type=Manager::typeid),
   XmlArrayItem(Type=Person::typeid)]
   array<Person^>^Staff;
};

void SerializeOrder( String^ filename )
{
   // Creates an XmlSerializer.
   XmlSerializer^ xSer = gcnew XmlSerializer( Group::typeid );

   // Creates the Group object, and two array items.
   Group^ myGroup = gcnew Group;
   Person^ p1 = gcnew Person;
   p1->Name = "Jacki";
   Manager^ p2 = gcnew Manager;
   p2->Name = "Megan";
   p2->Rank = 2;
   array<Person^>^myStaff = {p1,p2};
   myGroup->Staff = myStaff;
   
   // Serializes the object, and closes the StreamWriter.
   TextWriter^ writer = gcnew StreamWriter( filename );
   xSer->Serialize( writer, myGroup );
}

int main()
{
   SerializeOrder( "TypeEx.xml" );
}
// </Snippet1>
