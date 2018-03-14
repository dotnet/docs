// System.Xml.Serialization.XmlRootAttribute.ElementName 

/* The following example demonstrates the property 
   'ElementName' of class 'XmlRootAttribute'.
   This program demonstrates 'Student' class to 
   which the 'ElementName' property has been applied.
 */

using System;
using System.IO;
using System.Xml.Serialization;

// This is the class that is the default root element.
public class Student
{
   public string Name;
}

public class XMLRootAttributeClass 
{
   public static void Main()
   {
      XMLRootAttributeClass myXMLRootAttributeClass = 
                                    new XMLRootAttributeClass();
      myXMLRootAttributeClass.SerializeOrder("XMLRootAttributeConstuctor.xml");
   }
// <Snippet1>
   public void SerializeOrder(string filename)
   {
      // Create an XmlSerializer instance using the method below.
      XmlSerializer myXmlSerializer = CreateOverrider();

      // Create the object, and set its Name property.
      Student myStudent = new Student();
      myStudent.Name = "Student class1";

      // Serialize the class, and close the TextWriter.
      TextWriter writer = new StreamWriter(filename);
      myXmlSerializer.Serialize(writer, myStudent);
      writer.Close();
   }

   // Return an XmlSerializer to override the root serialization.
   public XmlSerializer CreateOverrider()
   {
      // Create an XmlAttributes to override the default root element.
      XmlAttributes myXmlAttributes = new XmlAttributes();

      // Create an XmlRootAttribute and set its element name and namespace.
      XmlRootAttribute myXmlRootAttribute = new XmlRootAttribute();
      myXmlRootAttribute.ElementName = "OverriddenRootElementName";
      myXmlRootAttribute.Namespace = "http://www.microsoft.com";

      // Set the XmlRoot property to the XmlRoot object.
      myXmlAttributes.XmlRoot = myXmlRootAttribute;
      XmlAttributeOverrides myXmlAttributeOverrides = 
                                    new XmlAttributeOverrides();
      
      /* Add the XmlAttributes object to the 
      XmlAttributeOverrides object. */
      myXmlAttributeOverrides.Add(typeof(Student), myXmlAttributes);

      // Create the Serializer, and return it.
      XmlSerializer myXmlSerializer = new XmlSerializer
         (typeof(Student), myXmlAttributeOverrides);
      return myXmlSerializer;
   }
// </Snippet1>
}