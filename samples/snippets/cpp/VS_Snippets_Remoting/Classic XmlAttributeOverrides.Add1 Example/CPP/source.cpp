

#using <System.Xml.dll>
#using <System.dll>

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
      // Create an XmlAttributeOverrides object. 
      XmlAttributeOverrides^ xOver = gcnew XmlAttributeOverrides;

      /* Create an XmlAttributeAttribute to override the base class
            object's XmlAttributeAttribute object. Give the overriding object
            a new attribute name ("Code"). */
      XmlAttributeAttribute^ xAtt = gcnew XmlAttributeAttribute;
      xAtt->AttributeName = "Code";

      /* Create an instance of the XmlAttributes class and set the 
            XmlAttribute property to the XmlAttributeAttribute object. */
      XmlAttributes^ attrs = gcnew XmlAttributes;
      attrs->XmlAttribute = xAtt;

      /* Add the XmlAttributes object to the XmlAttributeOverrides
            and specify the type and member name to override. */
      xOver->Add( Group::typeid, "GroupCode", attrs );
      XmlSerializer^ xSer = gcnew XmlSerializer( Group::typeid,xOver );
      return xSer;
   }
};
// </Snippet1>
