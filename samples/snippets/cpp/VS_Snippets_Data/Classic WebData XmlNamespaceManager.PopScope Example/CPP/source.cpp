

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
public ref class Sample
{
public:
   Sample()
   {
      
      // Create the XmlNamespaceManager.
      NameTable^ nt = gcnew NameTable;
      XmlNamespaceManager^ nsmgr = gcnew XmlNamespaceManager( nt );
      
      // Add prefix/namespace pairs to the XmlNamespaceManager.
      nsmgr->AddNamespace( "", "www.wideworldimporters.com" ); //Adds a default namespace.
      nsmgr->AddNamespace( "europe", "www.wideworldimporters.com/europe" );
      nsmgr->PushScope(); //Pushes a namespace scope on the stack.
      nsmgr->AddNamespace( "", "www.lucernepublishing.com" ); //Adds another default namespace.
      nsmgr->AddNamespace( "partners", "www.lucernepublishing.com/partners" );
      Console::WriteLine( "Show all the prefix/namespace pairs in the XmlNamespaceManager..." );
      ShowAllNamespaces( nsmgr );
   }


private:
   void ShowAllNamespaces( XmlNamespaceManager^ nsmgr )
   {
      do
      {
         System::Collections::IEnumerator^ myEnum = nsmgr->GetEnumerator();
         while ( myEnum->MoveNext() )
         {
            String^ prefix = safe_cast<String^>(myEnum->Current);
            Console::WriteLine( "Prefix={0}, Namespace={1}", prefix, nsmgr->LookupNamespace( prefix ) );
         }
      }
      while ( nsmgr->PopScope() );
   }

};

int main()
{
   gcnew Sample;
}

// </Snippet1>
