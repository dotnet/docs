

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

   [XmlAttributeAttribute]
   String^ Publisher;
};

public ref class Periodical
{
private:
   String^ title;

public:

   property String^ Title 
   {
      String^ get()
      {
         return title;
      }
      void set( String^ value )
      {
         title = value;
      }
   }
};

public ref class Library
{
private:
   array<Book^>^books;
   array<Periodical^>^periodicals;

public:

   /* This element will be qualified with the prefix 
      that is associated with the namespace http://wwww.cpandl.com. */
   [XmlArray(ElementName="Titles",
   Namespace="http://wwww.cpandl.com")]
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

   /* This element will be qualified with the prefix that is
      associated with the namespace http://www.proseware.com. */
   [XmlArray(ElementName="Titles",Namespace=
   "http://www.proseware.com")]
   property array<Periodical^>^ Periodicals 
   {
      array<Periodical^>^ get()
      {
         return periodicals;
      }
      void set( array<Periodical^>^value )
      {
         periodicals = value;
      }
   }
};

void WriteBook( String^ filename )
{
   // Creates a new XmlSerializer.
   XmlSerializer^ mySerializer = gcnew XmlSerializer( Library::typeid );

   // Writing the file requires a StreamWriter.
   TextWriter^ myStreamWriter = gcnew StreamWriter( filename );

   /* Creates an XmlSerializerNamespaces and adds prefixes and 
      namespaces to be used. */
   XmlSerializerNamespaces^ myNamespaces = gcnew XmlSerializerNamespaces;
   myNamespaces->Add( "books", "http://wwww.cpandl.com" );
   myNamespaces->Add( "magazines", "http://www.proseware.com" );

   // Creates an instance of the class to be serialized.
   Library^ myLibrary = gcnew Library;

   // Creates two book objects.
   Book^ b1 = gcnew Book;
   b1->Title = "My Book Title";
   b1->Author = "An Author";
   b1->ISBN = "000000000";
   b1->Publisher = "Microsoft Press";
   Book^ b2 = gcnew Book;
   b2->Title = "Another Book Title";
   b2->Author = "Another Author";
   b2->ISBN = "00000001";
   b2->Publisher = "Another Press";

   /* Creates an array using the objects, and sets the Books property
      to the array. */
   array<Book^>^myBooks = {b1,b2};
   myLibrary->Books = myBooks;

   // Creates two Periodical objects.
   Periodical^ per1 = gcnew Periodical;
   per1->Title = "My Magazine Title";
   Periodical^ per2 = gcnew Periodical;
   per2->Title = "Another Magazine Title";

   // Sets the Periodicals property to the array. 
   array<Periodical^>^myPeridocials = {per1,per2};
   myLibrary->Periodicals = myPeridocials;

   // Serializes the myLibrary object.
   mySerializer->Serialize( myStreamWriter, myLibrary, myNamespaces );
   myStreamWriter->Close();
}

void ReadBook( String^ filename )
{
   /* Creates an instance of an XmlSerializer
      with the class used to read the document. */
   XmlSerializer^ mySerializer = gcnew XmlSerializer( Library::typeid );

   // A FileStream is needed to read the file.
   FileStream^ myFileStream = gcnew FileStream( filename,FileMode::Open );
   Library^ myLibrary = dynamic_cast<Library^>(mySerializer->Deserialize( myFileStream ));

   // Reads each book in the array returned by the Books property.      
   for ( int i = 0; i < myLibrary->Books->Length; i++ )
   {
      Console::WriteLine( myLibrary->Books[ i ]->Title );
      Console::WriteLine( myLibrary->Books[ i ]->Author );
      Console::WriteLine( myLibrary->Books[ i ]->ISBN );
      Console::WriteLine( myLibrary->Books[ i ]->Publisher );
      Console::WriteLine();
   }
   for ( int i = 0; i < myLibrary->Periodicals->Length; i++ )
   {
      Console::WriteLine( myLibrary->Periodicals[ i ]->Title );
   }
}

int main()
{
   WriteBook( "MyLibrary.xml" );
   ReadBook( "MyLibrary.xml" );
}
// </Snippet1>
