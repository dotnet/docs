

// <Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml::Serialization;

// This is the class that will be serialized. 
public ref class Group
{
public:

   // The GroupName value will be serialized--unless it's overridden.
   String^ GroupName;

   /* This field will be ignored when serialized--
      unless it's overridden. */

   [XmlIgnoreAttribute]
   String^ Comment;
};


// Return an XmlSerializer used for overriding.
XmlSerializer^ CreateOverrider()
{
   // Create the XmlAttributeOverrides and XmlAttributes objects.
   XmlAttributeOverrides^ xOver = gcnew XmlAttributeOverrides;
   XmlAttributes^ attrs = gcnew XmlAttributes;

   /* Setting XmlIgnore to false overrides the XmlIgnoreAttribute
      applied to the Comment field. Thus it will be serialized.*/
   attrs->XmlIgnore = false;
   xOver->Add( Group::typeid, "Comment", attrs );

   /* Use the XmlIgnore to instruct the XmlSerializer to ignore
      the GroupName instead. */
   attrs = gcnew XmlAttributes;
   attrs->XmlIgnore = true;
   xOver->Add( Group::typeid, "GroupName", attrs );
   XmlSerializer^ xSer = gcnew XmlSerializer( Group::typeid,xOver );
   return xSer;
}

void SerializeObject( String^ filename )
{
   // Create an XmlSerializer instance.
   XmlSerializer^ xSer = CreateOverrider();

   // Create the object to serialize and set its properties.
   Group^ myGroup = gcnew Group;
   myGroup->GroupName = ".NET";
   myGroup->Comment = "My Comment...";

   // Writing the file requires a TextWriter.
   TextWriter^ writer = gcnew StreamWriter( filename );

   // Serialize the object and close the TextWriter.
   xSer->Serialize( writer, myGroup );
   writer->Close();
}

int main()
{
   SerializeObject( "IgnoreXml.xml" );
}
// </Snippet1>
