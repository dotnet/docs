// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;

int main()
{
   //Create the XmlDocument.
   XmlDocument^ doc = gcnew XmlDocument;
   doc->Load( "books.xml" );
   
   //Display all the book titles.
   XmlNodeList^ elemList = doc->GetElementsByTagName( "title" );
   for ( int i = 0; i < elemList->Count; i++ )
   {
      Console::WriteLine( elemList[ i ]->InnerXml );
   }
}
// </Snippet1>
