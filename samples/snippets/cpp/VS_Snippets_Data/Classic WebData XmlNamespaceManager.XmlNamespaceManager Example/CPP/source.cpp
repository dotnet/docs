

#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;
using namespace System::Xml::Xsl;
using namespace System::Xml::XPath;
using namespace System::Xml::Schema;
public ref class Class1
{
public:
   void Method1()
   {
      
      // <Snippet1>
      XmlTextReader^ reader = gcnew XmlTextReader( "myfile.xml" );
      XmlNamespaceManager^ nsmanager = gcnew XmlNamespaceManager( reader->NameTable );
      nsmanager->AddNamespace( "msbooks", "www.microsoft.com/books" );
      nsmanager->PushScope();
      nsmanager->AddNamespace( "msstore", "www.microsoft.com/store" );
      while ( reader->Read() )
      {
         Console::WriteLine( "Reader Prefix:{0}", reader->Prefix );
         Console::WriteLine( "XmlNamespaceManager Prefix:{0}", nsmanager->LookupPrefix( nsmanager->NameTable->Get( reader->NamespaceURI ) ) );
      }
   }

};

// </Snippet1>
