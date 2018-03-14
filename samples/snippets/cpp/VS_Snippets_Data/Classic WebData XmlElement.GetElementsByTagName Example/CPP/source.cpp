// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;

int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->Load( "2books.xml" );
   
   // Get and display all the book titles.
   XmlElement^ root = doc->DocumentElement;
   XmlNodeList^ elemList = root->GetElementsByTagName( "title" );
   for ( int i = 0; i < elemList->Count; i++ )
   {
      Console::WriteLine( elemList[ i ]->InnerXml );
   }
}
// </Snippet1>
