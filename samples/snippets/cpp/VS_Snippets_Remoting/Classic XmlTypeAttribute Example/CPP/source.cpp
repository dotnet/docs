

#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;

// <Snippet1>

[XmlType(Namespace="http://www.cpandl.com",
TypeName="GroupMember")]
public ref class Person
{
public:
   String^ Name;
};


[XmlType(Namespace="http://www.cohowinery.com",
TypeName="GroupAddress")]
public ref class Address
{
public:
   String^ Line1;
   String^ Line2;
   String^ City;
   String^ State;
   String^ Zip;
};

public ref class Group
{
public:
   array<Person^>^Staff;
   Person^ Manager;
   Address^ Location;
};

// </Snippet1>
