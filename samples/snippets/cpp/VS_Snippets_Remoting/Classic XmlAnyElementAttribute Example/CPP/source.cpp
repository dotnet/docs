

#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;

// <Snippet1>
public ref class XClass
{
public:

   /* Apply the XmlAnyElementAttribute to a field returning an array
      of XmlElement objects. */

   [XmlAnyElement]
   array<XmlElement^>^AllElements;
};

public ref class Test
{
public:
   void DeserializeObject( String^ filename )
   {
      // Create an XmlSerializer.
      XmlSerializer^ mySerializer = gcnew XmlSerializer( XClass::typeid );

      // To read a file, a FileStream is needed.
      FileStream^ fs = gcnew FileStream( filename,FileMode::Open );

      // Deserialize the class.
      XClass^ x = dynamic_cast<XClass^>(mySerializer->Deserialize( fs ));

      // Read the element names and values.
      System::Collections::IEnumerator^ myEnum = x->AllElements->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         XmlElement^ xel = safe_cast<XmlElement^>(myEnum->Current);
         Console::WriteLine( "{0}: {1}", xel->LocalName, xel->Value );
      }
   }
};

int main()
{
   Test^ t = gcnew Test;
   t->DeserializeObject( "XFile.xml" );
}
// </Snippet1>
