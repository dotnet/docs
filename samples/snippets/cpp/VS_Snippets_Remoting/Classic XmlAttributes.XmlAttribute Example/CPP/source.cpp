

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

   // This is the attribute that will be overridden.

   [XmlAttributeAttribute]
   String^ GroupName;
   int GroupNumber;
};

// Return an XmlSerializer used for overriding. 
XmlSerializer^ CreateOverrider()
{
   // Create the XmlAttributeOverrides and XmlAttributes objects.
   XmlAttributeOverrides^ xOver = gcnew XmlAttributeOverrides;
   XmlAttributes^ xAttrs = gcnew XmlAttributes;

   /* Create an overriding XmlAttributeAttribute set it to 
      the XmlAttribute property of the XmlAttributes object.*/
   XmlAttributeAttribute^ xAttribute = gcnew XmlAttributeAttribute( "SplinterName" );
   xAttrs->XmlAttribute = xAttribute;

   // Add to the XmlAttributeOverrides. Specify the member name.
   xOver->Add( Group::typeid, "GroupName", xAttrs );

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

   /* Set the Name property, which will be generated 
      as an XML attribute. */
   myGroup->GroupName = ".NET";
   myGroup->GroupNumber = 1;

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
   Console::WriteLine( myGroup->GroupNumber );
}

int main()
{
   SerializeObject( "OverrideAttribute.xml" );
   DeserializeObject( "OverrideAttribute.xml" );
}
// </Snippet1>
