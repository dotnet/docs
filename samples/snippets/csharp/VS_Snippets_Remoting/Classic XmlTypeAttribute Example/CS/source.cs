using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

// <Snippet1>
[XmlType(Namespace = "http://www.cpandl.com",
TypeName = "GroupMember")]
public class Person
{
   public string Name;
}

[XmlType(Namespace = "http://www.cohowinery.com",
TypeName = "GroupAddress")]
public class Address
{
   public string Line1;
   public string Line2;
   public string City;
   public string State;
   public string Zip;
}

public class Group
{
   public Person[] Staff;
   public Person Manager;
   public Address Location;
}

// </Snippet1>

