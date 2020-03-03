

// <Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
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

   [XmlArray(IsNullable=true)]
   [XmlArrayItem(Manager::typeid,IsNullable=false),
   XmlArrayItem(Employee::typeid,IsNullable=false)]
   array<Employee^>^Employees;
};

void SerializeObject( String^ filename )
{
   XmlSerializer^ s = gcnew XmlSerializer( Group::typeid );

   // To write the file, a TextWriter is required.
   TextWriter^ writer = gcnew StreamWriter( filename );

   // Creates the object to serialize.
   Group^ group = gcnew Group;

   // Creates a null Manager object.
   Manager^ mgr = nullptr;

   // Creates a null Employee object.
   Employee^ y = nullptr;
   array<Employee^>^temp = {mgr,y};
   group->Employees = temp;

   // Serializes the object and closes the TextWriter.
   s->Serialize( writer, group );
   writer->Close();
}

int main()
{
   SerializeObject( "TypeDoc.xml" );
}
// </Snippet1>
