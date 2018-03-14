

// <Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;
public ref class Employee
{
public:
   String^ Name;
};

public ref class Manager: public Employee
{
public:
   int Level;
};

public ref class Group
{
public:

   [XmlElement(Manager::typeid)]
   array<Employee^>^Staff;

   [XmlElement(Int32::typeid),
   XmlElement(String::typeid),
   XmlElement(DateTime::typeid)]
   ArrayList^ ExtraInfo;
};

void SerializeObject( String^ filename )
{
   // Create an XmlSerializer instance.
   XmlSerializer^ xSer = gcnew XmlSerializer( Group::typeid );

   // Create object and serialize it.
   Group^ myGroup = gcnew Group;
   Manager^ e1 = gcnew Manager;
   e1->Name = "Manager1";
   Manager^ m1 = gcnew Manager;
   m1->Name = "Manager2";
   m1->Level = 4;
   array<Employee^>^emps = {e1,m1};
   myGroup->Staff = emps;
   myGroup->ExtraInfo = gcnew ArrayList;
   myGroup->ExtraInfo->Add( ".NET" );
   myGroup->ExtraInfo->Add( 42 );
   myGroup->ExtraInfo->Add( DateTime(2001,1,1) );
   TextWriter^ writer = gcnew StreamWriter( filename );
   xSer->Serialize( writer, myGroup );
   writer->Close();
}

int main()
{
   SerializeObject( "TypeEx.xml" );
}
// </Snippet1>
