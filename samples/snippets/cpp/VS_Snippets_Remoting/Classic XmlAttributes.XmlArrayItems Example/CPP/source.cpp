

// <Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;
public ref class Member
{
public:
   String^ MemberName;
};

// This is the class that will be serialized.
public ref class Group
{
public:
   array<Member^>^Members;
};

public ref class NewMember: public Member
{
public:
   int MemberID;
};

public ref class RetiredMember: public NewMember
{
public:
   DateTime RetireDate;
};

// Return an XmlSerializer used for overriding. 
XmlSerializer^ CreateOverrider()
{
   // Create XmlAttributeOverrides and XmlAttributes objects.
   XmlAttributeOverrides^ xOver = gcnew XmlAttributeOverrides;
   XmlAttributes^ xAttrs = gcnew XmlAttributes;

   // Add an override for the XmlArrayItem.    
   XmlArrayItemAttribute^ xArrayItem = gcnew XmlArrayItemAttribute( NewMember::typeid );
   xArrayItem->Namespace = "http://www.cpandl.com";
   xAttrs->XmlArrayItems->Add( xArrayItem );

   // Add a second override.
   XmlArrayItemAttribute^ xArrayItem2 = gcnew XmlArrayItemAttribute( RetiredMember::typeid );
   xArrayItem2->Namespace = "http://www.cpandl.com";
   xAttrs->XmlArrayItems->Add( xArrayItem2 );

   // Add all overrides to XmlAttribueOverrides object.
   xOver->Add( Group::typeid, "Members", xAttrs );

   // Create the XmlSerializer and return it.
   return gcnew XmlSerializer( Group::typeid,xOver );
}

void SerializeObject( String^ filename )
{
   // Create an instance of the XmlSerializer class.
   XmlSerializer^ mySerializer = CreateOverrider();

   // Writing the file requires a TextWriter.
   TextWriter^ writer = gcnew StreamWriter( filename );

   // Create an instance of the class that will be serialized.
   Group^ myGroup = gcnew Group;

   // Set the object properties.
   NewMember^ m = gcnew NewMember;
   m->MemberName = "Paul";
   m->MemberID = 2;

   // Create a second member.
   RetiredMember^ m2 = gcnew RetiredMember;
   m2->MemberName = "Renaldo";
   m2->MemberID = 23;
   m2->RetireDate = DateTime(2000,10,10);
   array<Member^>^temp = {m,m2};
   myGroup->Members = temp;

   // Serialize the class, and close the TextWriter.
   mySerializer->Serialize( writer, myGroup );
   writer->Close();
}

void DeserializeObject( String^ filename )
{
   XmlSerializer^ mySerializer = CreateOverrider();
   FileStream^ fs = gcnew FileStream( filename,FileMode::Open );
   Group^ myGroup = dynamic_cast<Group^>(mySerializer->Deserialize( fs ));
   System::Collections::IEnumerator^ myEnum = myGroup->Members->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Member^ m = safe_cast<Member^>(myEnum->Current);
      Console::WriteLine( m->MemberName );
   }
}

int main()
{
   SerializeObject( "OverrideArrayItem.xml" );
   DeserializeObject( "OverrideArrayItem.xml" );
}
// </Snippet1>
