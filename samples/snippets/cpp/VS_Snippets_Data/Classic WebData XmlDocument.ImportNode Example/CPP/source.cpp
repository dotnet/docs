

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   
   //Create the XmlDocument.
   XmlDocument^ doc = gcnew XmlDocument;
   doc->LoadXml( "<bookstore><book genre='novel' ISBN='1-861001-57-5'><title>Pride And Prejudice</title></book></bookstore>" );
   
   //Create another XmlDocument which holds a list of books.
   XmlDocument^ doc2 = gcnew XmlDocument;
   doc2->Load( "books.xml" );
   
   //Import the last book node from doc2 into the original document.
   XmlNode^ newBook = doc->ImportNode( doc2->DocumentElement->LastChild, true );
   doc->DocumentElement->AppendChild( newBook );
   Console::WriteLine( "Display the modified XML..." );
   doc->Save( Console::Out );
}

// </Snippet1>
