

//<snippet1>
#using <System.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Net;
int main()
{
   
   // Create the reader.
   XmlTextReader^ reader = gcnew XmlTextReader( "http://myServer/data/books.xml" );
   
   // Create a secure resolver with default credentials.
   XmlUrlResolver^ resolver = gcnew XmlUrlResolver;
   XmlSecureResolver^ sResolver = gcnew XmlSecureResolver( resolver,"http://myServer/data/" );
   sResolver->Credentials = CredentialCache::DefaultCredentials;
   
   // Use the secure resolver to resolve resources.
   reader->XmlResolver = sResolver;
   
   // Parse the file.
   while ( reader->Read() )
   {
      
      // Do any additional processing here.
   }

   
   // Close the reader.
   reader->Close();
}

//</snippet1>
