

// <Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;
public ref class Price
{
public:

   [XmlAttributeAttribute(Namespace="http://www.cpandl.com")]
   String^ currency;

   [XmlElement(Namespace="http://www.cohowinery.com")]
   Decimal price;
};

[XmlType(Namespace="http://www.cpandl.com")]
public ref class Book
{
public:

   [XmlElement(Namespace="http://www.cpandl.com")]
   String^ TITLE;

   [XmlElement(Namespace="http://www.cohowinery.com")]
   Price^ PRICE;
};

public ref class Books
{
public:

   [XmlElement(Namespace="http://www.cohowinery.com")]
   Book^ Book;
};

public ref class Run
{
public:
   static void main()
   {
      Run^ test = gcnew Run;
      test->SerializeObject( "XmlNamespaces.xml" );
   }

   void SerializeObject( String^ filename )
   {
      XmlSerializer^ s = gcnew XmlSerializer( Books::typeid );

      // Writing a file requires a TextWriter.
      TextWriter^ t = gcnew StreamWriter( filename );

      /* Create an XmlSerializerNamespaces object and add two
            prefix-namespace pairs. */
      XmlSerializerNamespaces^ ns = gcnew XmlSerializerNamespaces;
      ns->Add( "books", "http://www.cpandl.com" );
      ns->Add( "money", "http://www.cohowinery.com" );

      // Create a Book instance.
      Book^ b = gcnew Book;
      b->TITLE = "A Book Title";
      Price^ p = gcnew Price;
      p->price = (Decimal)9.95;
      p->currency = "US Dollar";
      b->PRICE = p;
      Books^ bks = gcnew Books;
      bks->Book = b;
      s->Serialize( t, bks, ns );
      t->Close();
   }
};

int main()
{
   Run::main();
}
// </Snippet1>
