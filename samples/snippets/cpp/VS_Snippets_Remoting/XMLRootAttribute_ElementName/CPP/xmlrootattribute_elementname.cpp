// System::Xml::Serialization::XmlRootAttribute.ElementName 

// The following example demonstrates the property 
// 'ElementName' of class 'XmlRootAttribute'.
// This program demonstrates 'Student' class to 
// which the 'ElementName' property has been applied.

#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml::Serialization;

// This is the class that is the default root element.
public ref class Student
{
public:
   String^ Name;
};

public ref class XMLRootAttributeClass
{
// <Snippet1>
public:
   void SerializeOrder( String^ filename )
   {
      // Create an XmlSerializer instance using the method below.
      XmlSerializer^ myXmlSerializer = CreateOverrider();
      
      // Create the object, and set its Name property.
      Student^ myStudent = gcnew Student;
      myStudent->Name = "Student class1";
      
      // Serialize the class, and close the TextWriter.
      TextWriter^ writer = gcnew StreamWriter( filename );
      myXmlSerializer->Serialize( writer, myStudent );
      writer->Close();
   }

   // Return an XmlSerializer to  the root serialization.
   XmlSerializer^ CreateOverrider()
   {
      // Create an XmlAttributes to  the default root element.
      XmlAttributes^ myXmlAttributes = gcnew XmlAttributes;
      
      // Create an XmlRootAttribute and set its element name and namespace.
      XmlRootAttribute^ myXmlRootAttribute = gcnew XmlRootAttribute;
      myXmlRootAttribute->ElementName = "OverriddenRootElementName";
      myXmlRootAttribute->Namespace = "http://www.microsoft.com";
      
      // Set the XmlRoot property to the XmlRoot object.
      myXmlAttributes->XmlRoot = myXmlRootAttribute;
      XmlAttributeOverrides^ myXmlAttributeOverrides =
         gcnew XmlAttributeOverrides;
      
      // Add the XmlAttributes object to the XmlAttributeOverrides object.
      myXmlAttributeOverrides->Add( Student::typeid, myXmlAttributes );
      
      // Create the Serializer, and return it.
      XmlSerializer^ myXmlSerializer = gcnew XmlSerializer(
         Student::typeid, myXmlAttributeOverrides );
      return myXmlSerializer;
   }
// </Snippet1>
};

int main()
{
   XMLRootAttributeClass^ myXMLRootAttributeClass =
      gcnew XMLRootAttributeClass;
   myXMLRootAttributeClass->SerializeOrder(
      "XMLRootAttributeConstuctor.xml" );
}
