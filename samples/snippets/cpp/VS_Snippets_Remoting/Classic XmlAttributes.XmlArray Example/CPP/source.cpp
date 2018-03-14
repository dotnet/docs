

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

   // This field will be overridden.
   array<Member^>^Members;
};


// Return an XmlSerializer used for overriding. 
XmlSerializer^ CreateOverrider()
{
   // Creating XmlAttributeOverrides and XmlAttributes objects.
   XmlAttributeOverrides^ xOver = gcnew XmlAttributeOverrides;
   XmlAttributes^ xAttrs = gcnew XmlAttributes;

   // Add an override for the XmlArray.    
   XmlArrayAttribute^ xArray = gcnew XmlArrayAttribute( "Staff" );
   xArray->Namespace = "http://www.cpandl.com";
   xAttrs->XmlArray = xArray;
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
   Member^ m = gcnew Member;
   m->MemberName = "Paul";
   array<Member^>^temp = {m};
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
   SerializeObject( "OverrideArray.xml" );
   DeserializeObject( "OverrideArray.xml" );
}
// </Snippet1>
