

// <snippet1>
#using <System.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Net;
int main()
{
   
   // Supply the credentials necessary to access the DTD file stored on the network.
   XmlUrlResolver^ resolver = gcnew XmlUrlResolver;
   resolver->Credentials = CredentialCache::DefaultCredentials;
   
   // Create and load the XmlDocument.
   XmlDocument^ doc = gcnew XmlDocument;
   doc->XmlResolver = resolver; // Set the resolver.
   doc->Load( "book5.xml" );
   
   // Display the entity replacement text which is pulled from the DTD file.
   Console::WriteLine( doc->DocumentElement->LastChild->InnerText );
}

// </snippet1>
