

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
   
   // Supply the credentials necessary to access the Web server.
   XmlUrlResolver^ resolver = gcnew XmlUrlResolver;
   resolver->Credentials = CredentialCache::DefaultCredentials;
   reader->XmlResolver = resolver;
   
   // Parse the file.
   while ( reader->Read() )
   {
      
      // Do any additional processing here.
   }

   
   // Close the reader.
   reader->Close();
}

//</snippet1>
