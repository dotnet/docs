

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Collections;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->Load( "2books.xml" );
   
   //Get and display all the book titles.
   XmlElement^ root = doc->DocumentElement;
   XmlNodeList^ elemList = root->GetElementsByTagName( "title" );
   IEnumerator^ ienum = elemList->GetEnumerator();
   while ( ienum->MoveNext() )
   {
      XmlNode^ title = dynamic_cast<XmlNode^>(ienum->Current);
      Console::WriteLine( title->InnerText );
   }
}

// </Snippet1>
