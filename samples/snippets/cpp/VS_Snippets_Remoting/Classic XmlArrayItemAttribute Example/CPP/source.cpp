

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

   /* The XmlArrayItemAttribute allows the XmlSerializer to insert
      both the base type (Employee) and derived type (Manager) 
      into serialized arrays. */

   [XmlArrayItem(Manager::typeid),
   XmlArrayItem(Employee::typeid)]
   array<Employee^>^Employees;

   /* Use the XmlArrayItemAttribute to specify types allowed
      in an array of Object items. */

   [XmlArray]
   [XmlArrayItem(Int32::typeid,
   ElementName="MyNumber"),
   XmlArrayItem(String::typeid,
   ElementName="MyString"),
   XmlArrayItem(Manager::typeid)]
   array<Object^>^ExtraInfo;
};

void SerializeObject( String^ filename )
{
   // Creates a new XmlSerializer.
   XmlSerializer^ s = gcnew XmlSerializer( Group::typeid );

   // Writing the XML file to disk requires a TextWriter.
   TextWriter^ writer = gcnew StreamWriter( filename );
   Group^ group = gcnew Group;
   Manager^ manager = gcnew Manager;
   Employee^ emp1 = gcnew Employee;
   Employee^ emp2 = gcnew Employee;
   manager->Name = "Consuela";
   manager->Level = 3;
   emp1->Name = "Seiko";
   emp2->Name = "Martina";
   array<Employee^>^emps = {manager,emp1,emp2};
   group->Employees = emps;

   // Creates an int and a string and assigns to ExtraInfo.
   array<Object^>^temp = {43,"Extra",manager};
   group->ExtraInfo = temp;

   // Serializes the object, and closes the StreamWriter.
   s->Serialize( writer, group );
   writer->Close();
}

void DeserializeObject( String^ filename )
{
   FileStream^ fs = gcnew FileStream( filename,FileMode::Open );
   XmlSerializer^ x = gcnew XmlSerializer( Group::typeid );
   Group^ g = dynamic_cast<Group^>(x->Deserialize( fs ));
   Console::WriteLine( "Members:" );
   System::Collections::IEnumerator^ myEnum = g->Employees->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Employee^ e = safe_cast<Employee^>(myEnum->Current);
      Console::WriteLine( "\t{0}", e->Name );
   }
}

int main()
{
   SerializeObject( "TypeDoc.xml" );
   DeserializeObject( "TypeDoc.xml" );
}
// </Snippet1>
