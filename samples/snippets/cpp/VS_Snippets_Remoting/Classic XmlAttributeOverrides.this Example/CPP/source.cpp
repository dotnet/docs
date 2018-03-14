#using <System.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;

// <Snippet1>
// This is the class that will be serialized.
public ref class Group
{
public:
   String^ GroupName;

   [XmlAttributeAttribute]
   int GroupCode;
};

public ref class Sample
{
public:
   XmlSerializer^ CreateOverrider()
   {
      // Create an XmlSerializer with overriding attributes.
      XmlAttributes^ attrs = gcnew XmlAttributes;
      XmlAttributeOverrides^ xOver = gcnew XmlAttributeOverrides;
      XmlRootAttribute^ xRoot = gcnew XmlRootAttribute;

      // Set a new Namespace and ElementName for the root element.
      xRoot->Namespace = "http://www.cpandl.com";
      xRoot->ElementName = "NewGroup";
      attrs->XmlRoot = xRoot;
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
};
// </Snippet1>
