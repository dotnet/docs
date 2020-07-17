

// <Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml::Serialization;

// This is the class that is the default root element.
public ref class MyClass
{
public:
   String^ Name;
};

XmlSerializer^ CreateOverrider();
void SerializeOrder( String^ filename )
{
   // Create an XmlSerializer instance using the method below.
   XmlSerializer^ xSer = CreateOverrider();

   // Create the object, and set its Name property.
   MyClass^ myClass = gcnew MyClass;
   myClass->Name = "New Class Name";

   // Serialize the class, and close the TextWriter.
   TextWriter^ writer = gcnew StreamWriter( filename );
   xSer->Serialize( writer, myClass );
   writer->Close();
}

// Return an XmlSerializer to override the root serialization.
XmlSerializer^ CreateOverrider()
{
   // Create an XmlAttributes to override the default root element.
   XmlAttributes^ attrs = gcnew XmlAttributes;

   // Create an XmlRootAttribute and set its element name and namespace.
   XmlRootAttribute^ xRoot = gcnew XmlRootAttribute;
   xRoot->ElementName = "OverriddenRootElementName";
   xRoot->Namespace = "http://www.microsoft.com";

   // Set the XmlRoot property to the XmlRoot object.
   attrs->XmlRoot = xRoot;
   XmlAttributeOverrides^ xOver = gcnew XmlAttributeOverrides;

   /* Add the XmlAttributes object to the 
      XmlAttributeOverrides object. */
   xOver->Add( MyClass::typeid, attrs );

   // Create the Serializer, and return it.
   XmlSerializer^ xSer = gcnew XmlSerializer( MyClass::typeid,xOver );
   return xSer;
}

int main()
{
   SerializeOrder( "OverrideAttribute.xml" );
}
// </Snippet1>
