

// <Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;

public ref class MyClass
{
public:

   [XmlArrayAttribute("MyStrings")]
   array<String^>^MyStringArray;

   [XmlArrayAttribute(ElementName="MyIntegers")]
   array<Int32>^MyIntegerArray;
};

int main()
{
   String^ filename = "MyClass.xml";

   // Creates a new instance of the XmlSerializer class.
   XmlSerializer^ s = gcnew XmlSerializer( MyClass::typeid );

   // Needs a StreamWriter to write the file.
   TextWriter^ myWriter = gcnew StreamWriter( filename );
   MyClass^ myClass = gcnew MyClass;

   // Creates and populates a string array, then assigns
   // it to the MyStringArray property.
   array<String^>^myStrings = {"Hello","World","!"};
   myClass->MyStringArray = myStrings;

   /* Creates and populates an integer array, and assigns
      it to the MyIntegerArray property. */
   array<Int32>^myIntegers = {1,2,3};
   myClass->MyIntegerArray = myIntegers;

   // Serializes the class, and writes it to disk.
   s->Serialize( myWriter, myClass );
   myWriter->Close();
}
// </Snippet1>
