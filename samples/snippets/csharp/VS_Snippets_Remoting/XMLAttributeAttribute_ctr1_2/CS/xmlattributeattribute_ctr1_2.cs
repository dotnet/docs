// System.Xml.Serialization.XmlAttributeAttribute.XmlAttributeAttribute()
// System.Xml.Serialization.XmlAttributeAttribute.XmlAttributeAttribute(String)

/*  The following example demonstrates the constructor of XmlAttributeAttribute .
 *  This sample serializes a class named 'Student'.The StudentName property is 
 *  serialized as an XML attribute.It also serializes a class named 'Book' 
 */
// <Snippet1>
// <Snippet2>
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

// This is the class that will be serialized.
public class Student
{
   public string StudentName;
   public int StudentNumber;
}
 
public class Book
{
   public string BookName;
   public int BookNumber;
}
public class XMLAttributeAttribute_ctr1
{
   public static void Main()
   {
      XMLAttributeAttribute_ctr1 myAttribute = 
                                 new XMLAttributeAttribute_ctr1();
      myAttribute.SerializeObject("Student.xml","Book.xml");
   }
 
   public void SerializeObject(string studentFilename,string bookFilename)
   {
      XmlSerializer mySerializer;
      TextWriter writer;

      // Create the XmlAttributeOverrides and XmlAttributes objects.
      XmlAttributeOverrides myXmlAttributeOverrides = 
                                                     new XmlAttributeOverrides();
      XmlAttributes myXmlAttributes = new XmlAttributes();

      /* Create an XmlAttributeAttribute set it to 
      the XmlAttribute property of the XmlAttributes object.*/
      XmlAttributeAttribute myXmlAttributeAttribute = 
                                                new XmlAttributeAttribute();
      myXmlAttributeAttribute.AttributeName="Name";
      myXmlAttributes.XmlAttribute = myXmlAttributeAttribute;
      
      
      // Add to the XmlAttributeOverrides. Specify the member name.
      myXmlAttributeOverrides.Add(typeof(Student), "StudentName", 
                                                      myXmlAttributes);

      // Create the XmlSerializer.
      mySerializer = new  XmlSerializer(typeof(Student), 
                                                myXmlAttributeOverrides);
      
      writer = new StreamWriter(studentFilename);

      // Create an instance of the class that will be serialized.
      Student myStudent = new Student();

      // Set the Name property, which will be generated as an XML attribute. 
      myStudent.StudentName= "James";
      myStudent.StudentNumber=1;
      // Serialize the class, and close the TextWriter.
      mySerializer.Serialize(writer, myStudent);
      writer.Close();

      // Create the XmlAttributeOverrides and XmlAttributes objects.
      XmlAttributeOverrides myXmlBookAttributeOverrides = 
                                                new XmlAttributeOverrides();
      XmlAttributes myXmlBookAttributes = new XmlAttributes();

      /* Create an XmlAttributeAttribute set it to 
      the XmlAttribute property of the XmlAttributes object.*/
      XmlAttributeAttribute myXmlBookAttributeAttribute = 
                                           new XmlAttributeAttribute("Name");
      myXmlBookAttributes.XmlAttribute = myXmlBookAttributeAttribute;
      
      
      // Add to the XmlAttributeOverrides. Specify the member name.
      myXmlBookAttributeOverrides.Add(typeof(Book), "BookName", 
                                             myXmlBookAttributes);

      // Create the XmlSerializer.
      mySerializer = new  XmlSerializer(typeof(Book), 
                                       myXmlBookAttributeOverrides);
      
      writer = new StreamWriter(bookFilename);

      // Create an instance of the class that will be serialized.
      Book myBook = new Book();

      // Set the Name property, which will be generated as an XML attribute. 
      myBook.BookName= ".NET";
      myBook.BookNumber=10;
      // Serialize the class, and close the TextWriter.
      mySerializer.Serialize(writer, myBook);
      writer.Close();

   }
}
// </Snippet2>
// </Snippet1>