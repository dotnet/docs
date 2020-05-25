

#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;

// <Snippet1>
public ref class Group
{
public:

   // The XmlSerializer ignores this field.

   [XmlIgnore]
   String^ Comment;

   // The XmlSerializer serializes this field.
   String^ GroupName;
};

// </Snippet1>
