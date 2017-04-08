// <Snippet1>
#using <System.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml::Serialization;

// This is the class that will be serialized.
public ref class Group
{
public:
   String^ GroupName;

   [XmlAttributeAttribute]
   int GroupCode;
};

// Return an XmlSerializer for overriding attributes.
XmlSerializer^ CreateOverrider()
{
   // Create the XmlAttributes and XmlAttributeOverrides objects.
   XmlAttributes^ attrs = gcnew XmlAttributes;
   XmlAttributeOverrides^ xOver = gcnew XmlAttributeOverrides;
   XmlRootAttribute^ xRoot = gcnew XmlRootAttribute;

   // Set a new Namespace and ElementName for the root element.
   xRoot->Namespace = "http://www.cpandl.com";
   xRoot->ElementName = "NewGroup";
   attrs->XmlRoot = xRoot;

   /* Add the XmlAttributes object to the XmlAttributeOverrides. 
      No  member name is needed because the whole class is 
      overridden. */
   xOver->Add( Group::typeid, attrs );

   // Get the XmlAttributes object, based on the type.
   XmlAttributes^ tempAttrs;
   tempAttrs = xOver[ Group::typeid ];

   // Print the Namespace and ElementName of the root.
   Console::WriteLine( tempAttrs->XmlRoot->Namespace );
   Console::WriteLine( tempAttrs->XmlRoot->ElementName );
   XmlSerializer^ xSer = gcnew XmlSerializer( Group::typeid,xOver );
   return xSer;
}

void SerializeObject( String^ filename )
{
   // Create the XmlSerializer using the CreateOverrider method.
   XmlSerializer^ xSer = CreateOverrider();

   // Create the object to serialize.
   Group^ myGroup = gcnew Group;
   myGroup->GroupName = ".NET";
   myGroup->GroupCode = 123;

   // To write the file, a TextWriter is required.
   TextWriter^ writer = gcnew StreamWriter( filename );

   // Serialize the object and close the TextWriter.
   xSer->Serialize( writer, myGroup );
   writer->Close();
}

int main()
{
   SerializeObject( "OverrideRoot.xml" );
}
// </Snippet1>
