

//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->Load( "booksort.xml" );
   
   //Create an XmlNamespaceManager for resolving namespaces.
   XmlNamespaceManager^ nsmgr = gcnew XmlNamespaceManager( doc->NameTable );
   nsmgr->AddNamespace( "bk", "urn:samples" );
   
   //Select the book node with the matching attribute value.
   XmlNode^ book;
   XmlElement^ root = doc->DocumentElement;
   book = root->SelectSingleNode( "descendant::book->Item[@bk:ISBN='1-861001-57-6']", nsmgr );
   Console::WriteLine( book->OuterXml );
}

//</snippet1>
