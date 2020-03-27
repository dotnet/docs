

//<snippet1>
#using <System.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;
public ref class Student
{
public:

   [XmlAttributeAttribute]
   String^ Name;

   [XmlNamespaceDeclarationsAttribute]
   XmlSerializerNamespaces^ myNamespaces;
};

void SerializeStudent( String^ filename );
void DeserializeStudent( String^ filename );
int main()
{
   SerializeStudent( "Student.xml" );
   DeserializeStudent( "Student.xml" );
}

void SerializeStudent( String^ filename )
{
   XmlAttributes^ atts = gcnew XmlAttributes;

   // Set to true to preserve namespaces, 
   // or false to ignore them.
   atts->Xmlns = true;
   XmlAttributeOverrides^ xover = gcnew XmlAttributeOverrides;

   // Add the XmlAttributes and specify the name of the element 
   // containing namespaces.
   xover->Add( Student::typeid, "myNamespaces", atts );

   // Create the XmlSerializer using the 
   // XmlAttributeOverrides object.
   XmlSerializer^ xser = gcnew XmlSerializer( Student::typeid,xover );
   Student^ myStudent = gcnew Student;
   XmlSerializerNamespaces^ ns = gcnew XmlSerializerNamespaces;
   ns->Add( "myns1", "http://www.cpandl.com" );
   ns->Add( "myns2", "http://www.cohowinery.com" );
   myStudent->myNamespaces = ns;
   myStudent->Name = "Student1";
   FileStream^ fs = gcnew FileStream( filename,FileMode::Create );
   xser->Serialize( fs, myStudent );
   fs->Close();
}

void DeserializeStudent( String^ filename )
{
   XmlAttributes^ atts = gcnew XmlAttributes;

   // Set to true to preserve namespaces, or false to ignore them.
   atts->Xmlns = true;
   XmlAttributeOverrides^ xover = gcnew XmlAttributeOverrides;

   // Add the XmlAttributes and specify the name of the 
   // element containing namespaces.
   xover->Add( Student::typeid, "myNamespaces", atts );

   // Create the XmlSerializer using the 
   // XmlAttributeOverrides object.
   XmlSerializer^ xser = gcnew XmlSerializer( Student::typeid,xover );
   FileStream^ fs = gcnew FileStream( filename,FileMode::Open );
   Student^ myStudent;
   myStudent = safe_cast<Student^>(xser->Deserialize( fs ));
   fs->Close();

   // Use the ToArray method to get an array of 
   // XmlQualifiedName objects.
   array<XmlQualifiedName^>^qNames = myStudent->myNamespaces->ToArray();
   for ( int i = 0; i < qNames->Length; i++ )
   {
      Console::WriteLine( "{0}:{1}", qNames[ i ]->Name, qNames[ i ]->Namespace );

   }
}
//</snippet1>
