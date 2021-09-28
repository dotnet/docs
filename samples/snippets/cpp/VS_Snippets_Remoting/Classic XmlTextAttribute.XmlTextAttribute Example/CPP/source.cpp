

// <Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;
using namespace System::Xml::Schema;

public ref class Group
{
public:
   String^ GroupName;
   String^ Comment;
};

public ref class Test
{
public:
   static void main()
   {
      Test^ t = gcnew Test;
      t->SerializerOrder( "TextOverride.xml" );
   }

   /* Create an instance of the XmlSerializer class that overrides 
          the default way it serializes an object. */
   XmlSerializer^ CreateOverrider()
   {
      /* Create instances of the XmlAttributes and 
              XmlAttributeOverrides classes. */
      XmlAttributes^ attrs = gcnew XmlAttributes;
      XmlAttributeOverrides^ xOver = gcnew XmlAttributeOverrides;

      /* Create an XmlTextAttribute to override the default 
              serialization process. */
      XmlTextAttribute^ xText = gcnew XmlTextAttribute;
      attrs->XmlText = xText;

      // Add the XmlAttributes to the XmlAttributeOverrides.
      xOver->Add( Group::typeid, "Comment", attrs );

      // Create the XmlSerializer, and return it.
      XmlSerializer^ xSer = gcnew XmlSerializer( Group::typeid,xOver );
      return xSer;
   }

   void SerializerOrder( String^ filename )
   {
      // Create an XmlSerializer instance.
      XmlSerializer^ xSer = CreateOverrider();

      // Create the object and serialize it.
      Group^ myGroup = gcnew Group;
      myGroup->Comment = "This is a great product.";
      TextWriter^ writer = gcnew StreamWriter( filename );
      xSer->Serialize( writer, myGroup );
   }
};

int main()
{
   Test::main();
}
// </Snippet1>
