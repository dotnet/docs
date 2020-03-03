

// <Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;

// This is the class that will be serialized.
public ref class Group
{
public:
   String^ GroupName;

   // This field will be serialized as XML text. 
   String^ Comment;
};

// Return an XmlSerializer to be used for overriding. 
XmlSerializer^ CreateOverrider()
{
   // Create the XmlAttributeOverrides and XmlAttributes objects.
   XmlAttributeOverrides^ xOver = gcnew XmlAttributeOverrides;
   XmlAttributes^ xAttrs = gcnew XmlAttributes;

   /* Create an XmlTextAttribute and assign it to the XmlText 
      property. This instructs the XmlSerializer to treat the 
      Comment field as XML text. */
   XmlTextAttribute^ xText = gcnew XmlTextAttribute;
   xAttrs->XmlText = xText;
   xOver->Add( Group::typeid, "Comment", xAttrs );

   // Create the XmlSerializer, and return it.
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
   myGroup->GroupName = ".NET";
   myGroup->Comment = "Great Stuff!";

   // Serialize the class, and close the TextWriter.
   mySerializer->Serialize( writer, myGroup );
   writer->Close();
}

void DeserializeObject( String^ filename )
{
   XmlSerializer^ mySerializer = CreateOverrider();
   FileStream^ fs = gcnew FileStream( filename,FileMode::Open );
   Group^ myGroup = dynamic_cast<Group^>(mySerializer->Deserialize( fs ));
   Console::WriteLine( myGroup->GroupName );
   Console::WriteLine( myGroup->Comment );
}

int main()
{
   SerializeObject( "OverrideText.xml" );
   DeserializeObject( "OverrideText.xml" );
}
// </Snippet1>
