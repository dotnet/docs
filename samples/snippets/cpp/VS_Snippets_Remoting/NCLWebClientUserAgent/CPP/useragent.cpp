

//<Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::IO;
int main()
{
   array<String^>^args = Environment::GetCommandLineArgs();
   if ( args == nullptr || args->Length == 1 )
   {
      throw gcnew ApplicationException( "Specify the URI of the resource to retrieve." );
   }

   WebClient^ client = gcnew WebClient;
   
   // Add a user agent header in case the 
   // requested URI contains a query.
   client->Headers->Add( "user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)" );
   Stream^ data = client->OpenRead( args[ 1 ] );
   StreamReader^ reader = gcnew StreamReader( data );
   String^ s = reader->ReadToEnd();
   Console::WriteLine( s );
   data->Close();
   reader->Close();
}

//</Snippet1>
