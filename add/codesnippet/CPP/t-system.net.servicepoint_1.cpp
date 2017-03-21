// This example shows how to use the ServicePoint and ServicePointManager classes.
// The ServicePointManager class uses the ServicePoint class to manage connections
// to a remote host. The networking classes reuse service points for all 
// requests to a given URI. In fact, the same ServicePoint object 
// is used to issue requests to Internet resources identified by the same
// scheme identifier (for example,  HTTP) and host fragment (for example,  www.contoso.com).  
// This should improve your application performance. 
// Reusing service points in this way can help improve application performance.
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Threading;
using namespace System::Text::RegularExpressions;
void ShowProperties( ServicePoint^ sp )
{
   Console::WriteLine( "Done calling FindServicePoint()..." );
   
   // Display the ServicePoint Internet resource address.
   Console::WriteLine( "Address = {0}", sp->Address );
   
   // Display the date and time that the ServicePoint was last 
   // connected to a host.
   Console::WriteLine( "IdleSince = {0}", sp->IdleSince );
   
   // Display the maximum length of time that the ServicePoint instance  
   // is allowed to maintain an idle connection to an Internet  
   // resource before it is recycled for use in another connection.
   Console::WriteLine( "MaxIdleTime = {0}", sp->MaxIdleTime );
   
   Console::WriteLine( "ConnectionName = {0}", sp->ConnectionName );
   
   // Display the maximum number of connections allowed on this 
   // ServicePoint instance.
   Console::WriteLine( "ConnectionLimit = {0}", sp->ConnectionLimit );
   
   // Display the number of connections associated with this 
   // ServicePoint instance.
   Console::WriteLine( "CurrentConnections = {0}", sp->CurrentConnections );
   
   if ( sp->Certificate == nullptr )
      Console::WriteLine( "Certificate = (null)" );
   else
      Console::WriteLine( "Certificate = {0}", sp->Certificate );

   if ( sp->ClientCertificate == nullptr )
      Console::WriteLine( "Client Certificate = (null)" );
   else
      Console::WriteLine( "Client Certificate = {0}", sp->ClientCertificate );

   Console::WriteLine( "ProtocolVersion = {0}", sp->ProtocolVersion->ToString() );
   Console::WriteLine( "SupportsPipelining = {0}", sp->SupportsPipelining );
   
   Console::WriteLine( "UseNagleAlgorithm = {0} ", sp->UseNagleAlgorithm.ToString() );
   Console::WriteLine( "Expect 100-continue = {0}", sp->Expect100Continue.ToString() );
   
}


void makeWebRequest( int hashCode, String^ Uri )
{
   HttpWebResponse^ res = nullptr;
   
   // Make sure that the idle time has elapsed, so that a new 
   // ServicePoint instance is created.
   Console::WriteLine( "Sleeping for 2 sec." );
   Thread::Sleep( 2000 );
   try
   {
      
      // Create a request to the passed URI.
      HttpWebRequest^ req = dynamic_cast<HttpWebRequest^>(WebRequest::Create( Uri ));
      Console::WriteLine( "\nConnecting to {0} ............", Uri );
      
      // Get the response object.
      res = dynamic_cast<HttpWebResponse^>(req->GetResponse());
      Console::WriteLine( "Connected.\n" );
      ServicePoint^ currentServicePoint = req->ServicePoint;
      
      // Display new service point properties.
      int currentHashCode = currentServicePoint->GetHashCode();
      Console::WriteLine( "New service point hashcode: {0}", currentHashCode );
      Console::WriteLine( "New service point max idle time: {0}", currentServicePoint->MaxIdleTime );
      Console::WriteLine( "New service point is idle since {0}", currentServicePoint->IdleSince );
      
      // Check that a new ServicePoint instance has been created.
      if ( hashCode == currentHashCode )
            Console::WriteLine( "Service point reused." );
      else
            Console::WriteLine( "A new service point created." );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Source : {0}", e->Source );
      Console::WriteLine( "Message : {0}", e->Message );
   }
   finally
   {
      if ( res != nullptr )
            res->Close();
   }

}


// Show the user how to use this program when wrong inputs are entered.
void showUsage()
{
   Console::WriteLine( "Enter the proxy name as follows:" );
   Console::WriteLine( "\tcs_servicepoint proxyName" );
}


int main()
{
   array<String^>^args = Environment::GetCommandLineArgs();
   int port = 80;
   
   // Define a regular expression to parse the user's input.
   // This is a security check. It allows only
   // alphanumeric input strings between 2 to 40 characters long.
   Regex^ rex = gcnew Regex( "^[a-zA-Z]\\w{1,39}$" );
   if ( args->Length < 2 )
   {
      showUsage();
      return  -1;
   }

   String^ proxy = args[ 1 ];
   if ( (rex->Match(proxy))->Success != true )
   {
      Console::WriteLine( "Input string format not allowed." );
      return  -1;
   }

   String^ proxyAdd = String::Format( "http://{0}:{1}", proxy, port );
   
   // Create a proxy object.  
   WebProxy^ DefaultProxy = gcnew WebProxy( proxyAdd,true );
   
   // Set the proxy that all HttpWebRequest instances use.
   WebRequest::DefaultWebProxy = DefaultProxy;
   
   // Get the base interface for proxy access for the 
   // WebRequest-based classes.
   IWebProxy^ Iproxy = WebRequest::DefaultWebProxy;

   
   // Set the maximum number of ServicePoint instances to 
   // maintain. If a ServicePoint instance for that host already 
   // exists when your application requests a connection to
   // an Internet resource, the ServicePointManager object
   // returns this existing ServicePoint instance. If none exists 
   // for that host, it creates a new ServicePoint instance.
   ServicePointManager::MaxServicePoints = 4;
   
   // Set the maximum idle time of a ServicePoint instance to 10 seconds.
   // After the idle time expires, the ServicePoint object is eligible for
   // garbage collection and cannot be used by the ServicePointManager.
   ServicePointManager::MaxServicePointIdleTime = 10000;
   
   ServicePointManager::UseNagleAlgorithm = true;
   ServicePointManager::Expect100Continue = true;
   ServicePointManager::CheckCertificateRevocationList = true;
   ServicePointManager::DefaultConnectionLimit = ServicePointManager::DefaultPersistentConnectionLimit;
   
   // Create the Uri object for the resource you want to access.
   Uri^ MS = gcnew Uri( "http://msdn.microsoft.com/" );
   
   // Use the FindServicePoint method to find an existing 
   // ServicePoint object or to create a new one.   
   ServicePoint^ servicePoint = ServicePointManager::FindServicePoint( MS, Iproxy );
   ShowProperties( servicePoint );
   int hashCode = servicePoint->GetHashCode();
   Console::WriteLine( "Service point hashcode: {0}", hashCode );
   
   // Make a request with the same scheme identifier and host fragment
   // used to create the previous ServicePoint object.
   makeWebRequest( hashCode, "http://msdn.microsoft.com/library/" );
}
