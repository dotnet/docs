// System::Xml::Serialization::XmlSerializerNamespaces.constructor

// The following example demonstrates the constructor of class
// XmlSerializerNamespaces. This sample serializes an Object* of 'MyPriceClass'
// into an XML document.

#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Xml::Serialization;
using namespace System::IO;

public ref class MyPriceClass
{
public:
   [XmlAttributeAttribute]
   String^ Units;
   Decimal Price;
};

public ref class MyBook
{
public:
   String^ BookName;
   String^ Author;
   MyPriceClass^ BookPrice;
   String^ Description;
};

public ref class MyMainClass
{
// <Snippet1>
public:
   void CreateBook( String^ filename )
   {
      try
      {
         // Create instance of XmlSerializerNamespaces and add the namespaces.
         XmlSerializerNamespaces^ myNameSpaces = gcnew XmlSerializerNamespaces;
         myNameSpaces->Add( "BookName", "http://www.cpandl.com" );
         
         // Create instance of XmlSerializer and specify the type of object
         // to be serialized.
         XmlSerializer^ mySerializerObject =
            gcnew XmlSerializer( MyBook::typeid );

         TextWriter^ myWriter = gcnew StreamWriter( filename );
         // Create object to be serialized.
         MyBook^ myXMLBook = gcnew MyBook;

         myXMLBook->Author = "XMLAuthor";
         myXMLBook->BookName = "DIG THE XML";
         myXMLBook->Description = "This is a XML Book";

         MyPriceClass^ myBookPrice = gcnew MyPriceClass;
         myBookPrice->Price = (Decimal)45.89;
         myBookPrice->Units = "$";
         myXMLBook->BookPrice = myBookPrice;
         
         // Serialize the object.
         mySerializerObject->Serialize( myWriter, myXMLBook, myNameSpaces );
         myWriter->Close();
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Exception: {0} occurred", e->Message );
      }
   }
// </Snippet1>
};

int main()
{
   MyMainClass^ myMain = gcnew MyMainClass;
   // Create the XML document.
   myMain->CreateBook( "myBook.xml" );
}
