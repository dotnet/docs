

#using <System.Xml.dll>
#using <system.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   array<String^>^args = Environment::GetCommandLineArgs();
   String^ UserName = args[ 1 ];
   String^ SecurelyStoredPassword = args[ 2 ];
   String^ Domain = args[ 3 ];
   
   //<snippet1>
   // Create the reader. -> 
   XmlTextReader^ txtreader = gcnew XmlTextReader( "book5.xml" );
   XmlValidatingReader^ reader = gcnew XmlValidatingReader( txtreader );
   txtreader->WhitespaceHandling = WhitespaceHandling::None;
   
   // Set the credentials necessary to access the DTD file stored on the network.
   XmlUrlResolver^ resolver = gcnew XmlUrlResolver;
   resolver->Credentials = System::Net::CredentialCache::DefaultCredentials;
   reader->XmlResolver = resolver;
   
   // Display each of the element nodes.
   while ( reader->Read() )
   {
      switch ( reader->NodeType )
      {
         case XmlNodeType::Element:
            Console::Write( "< {0}>", reader->Name );
            break;

         case XmlNodeType::Text:
            Console::Write( reader->Value );
            break;

         case XmlNodeType::DocumentType:
            Console::Write( "<!DOCTYPE {0} [ {1}]", reader->Name, reader->Value );
            break;

         case XmlNodeType::EntityReference:
            Console::Write( reader->Name );
            break;

         case XmlNodeType::EndElement:
            Console::Write( "</ {0}>", reader->Name );
            break;
      }
   }

   
   // Close the reader.
   reader->Close();
}

//</snippet1>
