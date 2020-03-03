
//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->Load( L"newbooks.xml" );
   
   // Create an XmlNamespaceManager to resolve the default namespace.
   XmlNamespaceManager^ nsmgr = gcnew XmlNamespaceManager( doc->NameTable );
   nsmgr->AddNamespace( L"bk", L"urn:newbooks-schema" );
   
   // Select the first book written by an author whose last name is Atwood.
   XmlNode^ book;
   XmlElement^ root = doc->DocumentElement;
   book = root->SelectSingleNode( L"descendant::bk:book[bk:author/bk:last-name='Atwood']", nsmgr );
   Console::WriteLine( book->OuterXml );
   return 0;
}

//</snippet1>
