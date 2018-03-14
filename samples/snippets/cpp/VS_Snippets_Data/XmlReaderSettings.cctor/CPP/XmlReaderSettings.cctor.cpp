
#using <System.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Xml::Schema;
using namespace System::IO;
int main()
{
   
   // <snippet1>
   // Set the reader settings.
   XmlReaderSettings^ settings = gcnew XmlReaderSettings;
   settings->IgnoreComments = true;
   settings->IgnoreProcessingInstructions = true;
   settings->IgnoreWhitespace = true;
   
   // </snippet1>
   //<snippet2>
   // Create a resolver with default credentials.
   XmlUrlResolver^ resolver = gcnew XmlUrlResolver;
   resolver->Credentials = System::Net::CredentialCache::DefaultCredentials;

    // Set the reader settings object to use the resolver.
    settings->XmlResolver = resolver;
   
   // Create the XmlReader object.
   XmlReader^ reader = XmlReader::Create( L"http://ServerName/data/books.xml", settings );
   
   // </snippet2>
   // Parse the file. 
   while ( reader->Read() )
      ;

   return 1;
}

