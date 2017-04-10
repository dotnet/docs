// System.Xml.Serialization.XmlTypeAttribute.XmlTypeAttribute()
// System.Xml.Serialization.XmlTypeAttribute.XmlTypeAttribute(string)

/* The following example demonstrates the contructors 'XmlTypeAttribute()'
   and 'XmlTypeAttribute(string)' of class 'XmlTypeAttribute'.
   This program demonstrates 'Person' and 'Address' classes to 
   which the 'XmlTypeAttribute' has been applied.This sample then 
   serializes an object of class 'Person' into an XML document.
 */
// <Snippet1>
// <Snippet2>
using System;
using System.IO;
using System.Xml.Serialization;

public class Person
{
   public string personName;
   public Address address;
}
public class Address
{
   public string state;
   public string zip;
}

public class PersonTypeAttribute
{
   public static void Main()
   {
      PersonTypeAttribute myPersonTypeAttribute= new PersonTypeAttribute();
      myPersonTypeAttribute.SerializeObject("XmlType.xml");
   }
   
   public XmlSerializer CreateOverrider()
   {
      XmlAttributeOverrides personOverride = new XmlAttributeOverrides();      

      XmlAttributes personAttributes = new XmlAttributes();      
      XmlTypeAttribute personType = new XmlTypeAttribute();
      personType.TypeName = "Employee";
      personType.Namespace = "http://www.microsoft.com";
      personAttributes.XmlType = personType;

      XmlAttributes addressAttributes = new XmlAttributes();
      // Create 'XmlTypeAttribute' with 'TypeName' as an argument.
      XmlTypeAttribute addressType = new XmlTypeAttribute("Address");
      addressType.Namespace = "http://www.microsoft.com";
      addressAttributes.XmlType=addressType;

      personOverride.Add(typeof(Person) ,personAttributes);
      personOverride.Add(typeof(Address),addressAttributes);

      XmlSerializer myXmlSerializer = new XmlSerializer
         (typeof(Person), personOverride);
      return myXmlSerializer;
   }

   public void SerializeObject(string filename)
   {
      XmlSerializer myXmlSerializer = CreateOverrider();

      Address myAddress = new Address();
      myAddress.state="AAA";
      myAddress.zip="11111";

      Person myPerson = new Person();
      myPerson.personName="Smith";
      myPerson.address=myAddress;
      // Serialize to a file.
      TextWriter writer = new StreamWriter(filename);
      myXmlSerializer.Serialize(writer, myPerson);
   }
}
// </Snippet2> 
// </Snippet1>
