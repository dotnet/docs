

// System.Xml.Serialization.XmlAttributeAttribute.XmlAttributeAttribute()
// System.Xml.Serialization.XmlAttributeAttribute.XmlAttributeAttribute(String)
/*  The following example demonstrates the constructor of XmlAttributeAttribute .
*  This sample serializes a class named 'Student'.The StudentName property is 
*  serialized as an XML attribute.It also serializes a class named 'Book' 
*/
// <Snippet1>
// <Snippet2>
#using <System.dll>
#using <System.xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;

// This is the class that will be serialized.
public ref class Student
{
public:
   String^ StudentName;
   int StudentNumber;
};

public ref class Book
{
public:
   String^ BookName;
   int BookNumber;
};

void SerializeObject( String^ studentFilename, String^ bookFilename )
{
   XmlSerializer^ mySerializer;
   TextWriter^ writer;

   // Create the XmlAttributeOverrides and XmlAttributes objects.
   XmlAttributeOverrides^ myXmlAttributeOverrides = gcnew XmlAttributeOverrides;
   XmlAttributes^ myXmlAttributes = gcnew XmlAttributes;

   /* Create an XmlAttributeAttribute set it to 
      the XmlAttribute property of the XmlAttributes object.*/
   XmlAttributeAttribute^ myXmlAttributeAttribute = gcnew XmlAttributeAttribute;
   myXmlAttributeAttribute->AttributeName = "Name";
   myXmlAttributes->XmlAttribute = myXmlAttributeAttribute;

   // Add to the XmlAttributeOverrides. Specify the member name.
   myXmlAttributeOverrides->Add( Student::typeid, "StudentName", myXmlAttributes );

   // Create the XmlSerializer.
   mySerializer = gcnew XmlSerializer( Student::typeid,myXmlAttributeOverrides );
   writer = gcnew StreamWriter( studentFilename );

   // Create an instance of the class that will be serialized.
   Student^ myStudent = gcnew Student;

   // Set the Name property, which will be generated as an XML attribute. 
   myStudent->StudentName = "James";
   myStudent->StudentNumber = 1;

   // Serialize the class, and close the TextWriter.
   mySerializer->Serialize( writer, myStudent );
   writer->Close();

   // Create the XmlAttributeOverrides and XmlAttributes objects.
   XmlAttributeOverrides^ myXmlBookAttributeOverrides = gcnew XmlAttributeOverrides;
   XmlAttributes^ myXmlBookAttributes = gcnew XmlAttributes;

   /* Create an XmlAttributeAttribute set it to 
      the XmlAttribute property of the XmlAttributes object.*/
   XmlAttributeAttribute^ myXmlBookAttributeAttribute = gcnew XmlAttributeAttribute( "Name" );
   myXmlBookAttributes->XmlAttribute = myXmlBookAttributeAttribute;

   // Add to the XmlAttributeOverrides. Specify the member name.
   myXmlBookAttributeOverrides->Add( Book::typeid, "BookName", myXmlBookAttributes );

   // Create the XmlSerializer.
   mySerializer = gcnew XmlSerializer( Book::typeid,myXmlBookAttributeOverrides );
   writer = gcnew StreamWriter( bookFilename );

   // Create an instance of the class that will be serialized.
   Book^ myBook = gcnew Book;

   // Set the Name property, which will be generated as an XML attribute. 
   myBook->BookName = ".NET";
   myBook->BookNumber = 10;

   // Serialize the class, and close the TextWriter.
   mySerializer->Serialize( writer, myBook );
   writer->Close();
}

int main()
{
   SerializeObject(  "Student.xml",  "Book.xml" );
}
// </Snippet2>
// </Snippet1>
