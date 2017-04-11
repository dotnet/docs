

#using <System.dll>

using namespace System;
using namespace System::Net;

//<snippet1>
// The following method displays the properties of the 
// specified WebProxy instance.
void DisplayProxyProperties( WebProxy^ proxy )
{
   Console::WriteLine( "Address: {0}", proxy->Address );
   Console::WriteLine( "Bypass on local: {0}", proxy->BypassProxyOnLocal );

   int count = proxy->BypassList->Length;
   if ( count == 0 )
   {
      Console::WriteLine( "The bypass list is empty." );
      return;
   }

   array<String^>^bypass = proxy->BypassList;
   Console::WriteLine( "The bypass list contents:" );
   for ( int i = 0; i < count; i++ )
   {
      Console::WriteLine( bypass[ i ] );

   }
}
//</snippet1>

//<snippet6>
// The following method creates a Web proxy that uses 
// Web proxy auto-discovery and supplies
// credentials to be used to download the wpad.dat script.
void CheckAutoProxyForRequest( Uri^ resource )
{
   WebProxy^ proxy = gcnew WebProxy;
   
   // See what proxy is used for the resource.
   Uri^ resourceProxy = proxy->GetProxy( resource );
   
   // Test to see if a proxy was selected.
   if ( resourceProxy == resource )
   {
      Console::WriteLine( "No proxy for {0}", resource );
   }
   else
   {
      Console::WriteLine( "Proxy for {0} is {1}", 
          resource, resourceProxy );
   }
}
//</snippet6>

//<snippet2> 
// The following method creates a WebProxy object that uses Internet Explorer's  
// detected script if it is found in the registry; otherwise, it 
// tries to use Web proxy auto-discovery to set the proxy used for
// the request.
void CheckAutoGlobalProxyForRequest( Uri^ resource )
{
   WebProxy^ proxy = gcnew WebProxy;
   
   // Display the proxy's properties.
   DisplayProxyProperties( proxy );
   
   // See what proxy is used for the resource.
   Uri^ resourceProxy = proxy->GetProxy( resource );
   
   // Test to see whether a proxy was selected.
   if ( resourceProxy == resource )
   {
      Console::WriteLine( "No proxy for {0}", resource );
   }
   else
   {
      Console::WriteLine( "Proxy for {0} is {1}", resource, resourceProxy );
   }
}
//</snippet2>     

// The following method creates a Web proxy that 
// has its initial values set by the Internet Explorer's
// explicit proxy address and bypass list.
// The proxy uses Internet Explorer's automatically detected
// script if it found in the registry; otherwise, it tries to use
// Web proxy auto-discovery to set the proxy used for
// the request.
void CheckAutoDefaultProxyForRequest( Uri^ resource )
{
   WebProxy^ proxy = dynamic_cast<WebProxy^>(WebRequest::DefaultWebProxy);
   
   // Display the proxy properties.
   DisplayProxyProperties( proxy );
   
   // See what proxy is used for resource.
   Uri^ resourceProxy = proxy->GetProxy( resource );
   
   // Test to see if a proxy was selected.
   if ( resourceProxy == resource )
   {
      Console::WriteLine( "No proxy for {0}", resource );
   }
   else
   {
      Console::WriteLine( "Proxy for {0} is {1}", resource, resourceProxy );
   }
}

//<snippet3>   
// This method  specifies a script that should
// be used in the event that auto-discovery fails.
void CheckAutoProxyAndScriptForRequest( Uri^ resource, Uri^ script )
{
   WebProxy^ proxy = gcnew WebProxy;
   DisplayProxyProperties( proxy );
   
   // See what proxy is used for resource.
   Uri^ resourceProxy = dynamic_cast<Uri^>(proxy->GetProxy(resource));
   
   // Test to see whether a proxy was selected.
   if ( resourceProxy == resource )
   {
      Console::WriteLine( "No proxy for {0}", resource );
   }
   else
   {
      Console::WriteLine( "Proxy for {0} is {1}", resource, resourceProxy );
   }
}
//</snippet3> 

// if construct with glocabl select
// if use system = true then if proxy = Glocalproxy.Select - the returned instance
// will have its values set 
// by IE settings.  If you do webProxy get default roxy reads manual setting (proxy address and 
// bypass - doesn't matter what the config file has.
//<snippet4> 
// The following method explicitly identifies
// the script to be downloaded and used to select the proxy.
void CheckScriptedProxyForRequest( Uri^ resource, Uri^ script )
{
   WebProxy^ proxy = gcnew WebProxy;
   
   // See what proxy is used for resource.
   Uri^ resourceProxy = dynamic_cast<Uri^>(proxy->GetProxy(resource));
   
   // Test to see whether a proxy was selected.
   if ( resourceProxy == nullptr )
   {
      Console::WriteLine( "No proxy selected for {0}.", resource );
      return;
   }
   else
   {
      Console::WriteLine( "proxy returned for {0}.", resource );
      {
         
         // DIRECT in script is returned as a null Uri object.
         if ( resourceProxy == nullptr )
                  Console::WriteLine( "DIRECT" );
         else
                  Console::WriteLine( "{0}", resourceProxy );

      }
   }
}
//</snippet4>    

//<snippet5>
WebResponse^ CheckLatestScriptRequest( Uri^ resource, WebProxy^ proxy )
{
   WebRequest^ request = WebRequest::Create( resource );
   request->Proxy = proxy;
   WebResponse^ response = request->GetResponse();
   return response;
}
//</snippet5>

void CheckScriptedProxyForRequest2( Uri^ resource, Uri^ script )
{
   WebProxy^ proxy = gcnew WebProxy;
   
   // if use ssystem = true then if proxy = Glocalproxy.Select - the returned instance
   // will have its values set 
   // by IE settings.  If you do webProxy get defaultProxy reads manual setting (proxy address and 
   // bypass - doesn't matter what the config file has.
   
   // if construct with global select

   // See what proxy is used for resource.
   Uri^ resourceProxy = proxy->GetProxy( resource );
   Console::WriteLine( "GetProxy  returned for {0} is {1}.", resource, resourceProxy );
   

}

void Underline()
{
   Console::WriteLine( "=======================================" );
}

int main()
{
   Uri^ resource = gcnew Uri( "http://www.example.com" );
   
   //  Console.WriteLine("nothing - default ctor"); Underline();
   //   DisplayProxyProperties(new WebProxy());
   //   Console.WriteLine ("\n\nAuto-only - default ctor"); Underline();
   //   CheckAutoProxyForRequest(resource);
   Console::WriteLine( "\n\nAuto-only - GlobalProxySelection.Select" );
   Underline();
   CheckAutoGlobalProxyForRequest( resource );
   
   /*
       Console.WriteLine ("\n\nAuto-only - DefaultProxy"); Underline();
       CheckAutoDefaultProxyForRequest(resource);
       */
   //  Console.WriteLine("\n\n IE auto + Valid Script-only");
   //  CheckScriptedProxyForRequest(resource, new Uri("http://sharriso1/wpad.dat"));
   // Console.WriteLine("\n\n IE auto Invalid Script-only");
   //  CheckScriptedProxyForRequest(resource, new Uri("http://sharriso1/wpadx.dat"));
   /* Console.WriteLine("Auto and Valid script");
       CheckAutoProxyAndScriptForRequest(resource, new Uri("http://sharriso1/wpad.dat"));
   
       Console.WriteLine("Auto and Invalid script");
       CheckAutoProxyAndScriptForRequest(resource, new Uri("http://sharriso1/wpadx.dat"));
       */
   // check snippet 5
   // CheckLatestScriptRequest(resource, WebProxy.GetDefaultProxy());
   // check snippet 6
   //CheckAutoProxyForRequest( resource);
}
