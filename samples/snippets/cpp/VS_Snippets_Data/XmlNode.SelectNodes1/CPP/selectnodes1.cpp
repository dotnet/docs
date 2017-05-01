

//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Collections;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->Load( "booksort.xml" );
   
   // Create an XmlNamespaceManager for resolving namespaces.
   XmlNamespaceManager^ nsmgr = gcnew XmlNamespaceManager( doc->NameTable );
   nsmgr->AddNamespace( "bk", "urn:samples" );
   
   // Select and display the value of all the ISBN attributes.
   XmlNodeList^ nodeList;
   XmlElement^ root = doc->DocumentElement;
   nodeList = root->SelectNodes( "/bookstore/book/@bk:ISBN", nsmgr );
   IEnumerator^ myEnum = nodeList->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      XmlNode^ isbn = safe_cast<XmlNode^>(myEnum->Current);
      Console::WriteLine( isbn->Value );
   }
}

//</snippet1>
