

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->Load( "booksort.xml" );
   XmlNodeList^ nodeList;
   XmlNode^ root = doc->DocumentElement;
   nodeList = root->SelectNodes( "descendant::book[author/last-name='Austen']" );
   
   //Change the price on the books.
   System::Collections::IEnumerator^ myEnum = nodeList->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      XmlNode^ book = safe_cast<XmlNode^>(myEnum->Current);
      book->LastChild->InnerText = "15.95";
   }

   Console::WriteLine( "Display the modified XML document...." );
   doc->Save( Console::Out );
}

// </Snippet1>
