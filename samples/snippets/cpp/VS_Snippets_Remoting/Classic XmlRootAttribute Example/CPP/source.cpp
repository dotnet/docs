

// <Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Schema;
using namespace System::Xml::Serialization;

[XmlRoot(Namespace="www.contoso.com",
ElementName="MyGroupName",
DataType="string",
IsNullable=true)]
public ref class Group
{
private:
   String^ groupNameValue;

public:

   // Insert code for the Group class.
   Group(){}

   Group( String^ groupNameVal )
   {
      groupNameValue = groupNameVal;
   }

   property String^ GroupName 
   {
      String^ get()
      {
         return groupNameValue;
      }
      void set( String^ value )
      {
         groupNameValue = value;
      }

   }

};

void SerializeGroup()
{
   // Create an instance of the Group class, and an
   // instance of the XmlSerializer to serialize it.
   Group^ myGroup = gcnew Group( "Redmond" );
   XmlSerializer^ ser = gcnew XmlSerializer( Group::typeid );

   // A FileStream is used to write the file.
   FileStream^ fs = gcnew FileStream( "group.xml",FileMode::Create );
   ser->Serialize( fs, myGroup );
   fs->Close();
   Console::WriteLine( myGroup->GroupName );
   Console::WriteLine( "Done" );
   Console::ReadLine();
}

int main()
{
   SerializeGroup();
}
// </Snippet1>
