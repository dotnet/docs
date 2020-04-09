

// <Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;
public ref class Book
{
public:
   String^ Title;
   String^ Author;
   String^ ISBN;
};

public ref class Library
{
private:
   array<Book^>^books;

public:

   [XmlArray(ElementName="My_Books")]
   property array<Book^>^ Books 
   {
      array<Book^>^ get()
      {
         return books;
      }

      void set( array<Book^>^value )
      {
         books = value;
      }
   }
};

int main()
{
   String^ filename = "ArrayExample.xml";
   XmlSerializer^ mySerializer = gcnew XmlSerializer( Library::typeid );
   TextWriter^ t = gcnew StreamWriter( filename );
   XmlSerializerNamespaces^ ns = gcnew XmlSerializerNamespaces;
   ns->Add( "bk", "http://wwww.contoso.com" );
   Book^ b1 = gcnew Book;
   b1->Title = "MyBook Title";
   b1->Author = "An Author";
   b1->ISBN = "00000000";
   Book^ b2 = gcnew Book;
   b2->Title = "Another Title";
   b2->Author = "Another Author";
   b2->ISBN = "0000000";
   Library^ myLibrary = gcnew Library;
   array<Book^>^myBooks = {b1,b2};
   myLibrary->Books = myBooks;
   mySerializer->Serialize( t, myLibrary, ns );
   t->Close();
}
// </Snippet1>
