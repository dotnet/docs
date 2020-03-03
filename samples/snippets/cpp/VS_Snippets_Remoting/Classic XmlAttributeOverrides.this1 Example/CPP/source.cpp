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
      XmlAttributeOverrides^ xOver = gcnew XmlAttributeOverrides;

      /* Create an XmlAttributeAttribute object and set the 
            AttributeName property. */
      XmlAttributeAttribute^ xAtt = gcnew XmlAttributeAttribute;
      xAtt->AttributeName = "Code";

      /* Create a new XmlAttributes object and set the 
            XmlAttributeAttribute object to the XmlAttribute property. */
      XmlAttributes^ attrs = gcnew XmlAttributes;
      attrs->XmlAttribute = xAtt;

      /* Add the XmlAttributes to the XmlAttributeOverrides object. The
            name of the overridden attribute must be specified. */
      xOver->Add( Group::typeid, "GroupCode", attrs );

      // Get the XmlAttributes object for the type and member.
      XmlAttributes^ tempAttrs;
      tempAttrs = xOver[Group::typeid, "GroupCode"];
      Console::WriteLine( tempAttrs->XmlAttribute->AttributeName );

      // Create the XmlSerializer instance and return it.
      XmlSerializer^ xSer = gcnew XmlSerializer( Group::typeid,xOver );
      return xSer;
   }
};
// </Snippet1>
