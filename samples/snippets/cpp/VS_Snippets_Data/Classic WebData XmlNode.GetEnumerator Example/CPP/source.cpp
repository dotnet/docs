

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Xml;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->Load( "books.xml" );
   Console::WriteLine( "Display all the books..." );
   XmlNode^ root = doc->DocumentElement;
   IEnumerator^ ienum = root->GetEnumerator();
   XmlNode^ book;
   while ( ienum->MoveNext() )
   {
      book = dynamic_cast<XmlNode^>(ienum->Current);
      Console::WriteLine( book->OuterXml );
      Console::WriteLine();
   }
}

// </Snippet1>
