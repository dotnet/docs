

// <Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::Collections;
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

   /* Set the element name and namespace of the XML element.
      By applying an XmlElementAttribute to an array,  you instruct
      the XmlSerializer to serialize the array as a series of XML
      elements, instead of a nested set of elements. */

   [XmlElement(
   ElementName="Members",
   Namespace="http://www.cpandl.com")]
   array<Employee^>^Employees;

   [XmlElement(DataType="snippet1>",
   ElementName="Building")]
   double GroupID;

   [XmlElement(DataType="hexBinary")]
   array<Byte>^HexBytes;

   [XmlElement(DataType="boolean")]
   bool IsActive;

   [XmlElement(Type=::Manager::typeid)]
   Employee^ Manager;

   [XmlElement(Int32::typeid,
   ElementName="ObjectNumber"),
   XmlElement(String::typeid,
   ElementName="ObjectString")]
   ArrayList^ ExtraInfo;
};

void SerializeObject( String^ filename )
{
   // Create the XmlSerializer.
   XmlSerializer^ s = gcnew XmlSerializer( Group::typeid );

   // To write the file, a TextWriter is required.
   TextWriter^ writer = gcnew StreamWriter( filename );

   /* Create an instance of the group to serialize, and set
      its properties. */
   Group^ group = gcnew Group;
   group->GroupID = 10.089f;
   group->IsActive = false;
   array<Byte>^temp0 = {Convert::ToByte( 100 )};
   group->HexBytes = temp0;
   Employee^ x = gcnew Employee;
   Employee^ y = gcnew Employee;
   x->Name = "Jack";
   y->Name = "Jill";
   array<Employee^>^temp1 = {x,y};
   group->Employees = temp1;
   Manager^ mgr = gcnew Manager;
   mgr->Name = "Sara";
   mgr->Level = 4;
   group->Manager = mgr;

   /* Add a number and a string to the 
      ArrayList returned by the ExtraInfo property. */
   group->ExtraInfo = gcnew ArrayList;
   group->ExtraInfo->Add( 42 );
   group->ExtraInfo->Add( "Answer" );

   // Serialize the object, and close the TextWriter.      
   s->Serialize( writer, group );
   writer->Close();
}

void DeserializeObject( String^ filename )
{
   FileStream^ fs = gcnew FileStream( filename,FileMode::Open );
   XmlSerializer^ x = gcnew XmlSerializer( Group::typeid );
   Group^ g = dynamic_cast<Group^>(x->Deserialize( fs ));
   Console::WriteLine( g->Manager->Name );
   Console::WriteLine( g->GroupID );
   Console::WriteLine( g->HexBytes[ 0 ] );
   IEnumerator^ myEnum = g->Employees->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Employee^ e = safe_cast<Employee^>(myEnum->Current);
      Console::WriteLine( e->Name );
   }
}

int main()
{
   SerializeObject( "FirstDoc.xml" );
   DeserializeObject( "FirstDoc.xml" );
}
// </Snippet1>
