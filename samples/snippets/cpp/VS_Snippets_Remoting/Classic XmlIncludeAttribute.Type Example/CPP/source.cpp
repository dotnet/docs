

// <Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml::Serialization;

ref class Employee;

ref class Manager;

ref class Group
{
public:
   array<Employee^>^Employees;
};

// Instruct the XmlSerializer to accept Manager types as well.
[XmlInclude(Manager::typeid)]
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

void SerializeObject( String^ filename )
{
   XmlSerializer^ s = gcnew XmlSerializer( Group::typeid );
   TextWriter^ writer = gcnew StreamWriter( filename );
   Group^ group = gcnew Group;
   Manager^ manager = gcnew Manager;
   Employee^ emp1 = gcnew Employee;
   Employee^ emp2 = gcnew Employee;
   manager->Name = "Zeus";
   manager->Level = 2;
   emp1->Name = "Ares";
   emp2->Name = "Artemis";
   array<Employee^>^emps = {manager,emp1,emp2};
   group->Employees = emps;
   s->Serialize( writer, group );
   writer->Close();
}

void DeserializeObject( String^ filename )
{
   FileStream^ fs = gcnew FileStream( filename,FileMode::Open );
   XmlSerializer^ x = gcnew XmlSerializer( Group::typeid );
   Group^ g = dynamic_cast<Group^>(x->Deserialize( fs ));
   Console::Write( "Members:" );
   System::Collections::IEnumerator^ myEnum = g->Employees->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Employee^ e = safe_cast<Employee^>(myEnum->Current);
      Console::WriteLine( "\t{0}", e->Name );
   }
}

int main()
{
   SerializeObject( "IncludeExample.xml" );
   DeserializeObject( "IncludeExample.xml" );
}
// </Snippet1>
