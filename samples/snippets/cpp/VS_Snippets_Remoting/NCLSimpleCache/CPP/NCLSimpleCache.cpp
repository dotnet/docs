
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Net::Cache;
using namespace System::IO;
using namespace System::Text;
using namespace System::Collections::Specialized;
using namespace System::Collections;

public ref class CacheExample
{
public:

   //<snippet1>
   static WebResponse^ GetResponseUsingDefaultCache( Uri^ uri )
   {
      // Set a cache policy level for the "http:" scheme.
      HttpRequestCachePolicy^ policy = gcnew HttpRequestCachePolicy( HttpRequestCacheLevel::Default );

      // Create the request.
      WebRequest^ request = WebRequest::Create( uri );
      request->CachePolicy = policy;
      WebResponse^ response = request->GetResponse();
      Console::WriteLine( L"Policy {0}.", policy );
      Console::WriteLine( L"Is the response from the cache? {0}", response->IsFromCache );
      return response;
   }
   //</snippet1>

   //<snippet2>
   // The following method demonstrates overriding the
   // caching policy for a request.
   static WebResponse^ GetResponseNoCache( Uri^ uri )
   {
      // Set a default policy level for the "http:" and "https" schemes.
      HttpRequestCachePolicy^ policy = gcnew HttpRequestCachePolicy( HttpRequestCacheLevel::Default );
      HttpWebRequest::DefaultCachePolicy = policy;

      // Create the request.
      WebRequest^ request = WebRequest::Create( uri );

      // Define a cache policy for this request only. 
      HttpRequestCachePolicy^ noCachePolicy = gcnew HttpRequestCachePolicy( HttpRequestCacheLevel::NoCacheNoStore );
      request->CachePolicy = noCachePolicy;
      WebResponse^ response = request->GetResponse();
      Console::WriteLine( L"IsFromCache? {0}", response->IsFromCache );
      
      return response;
   }
   //</snippet2>

   //<snippet3>
   static HttpRequestCachePolicy^ CreateLastSyncPolicy( DateTime when )
   {
      HttpRequestCachePolicy^ policy = gcnew HttpRequestCachePolicy( when );
      Console::WriteLine( L"When: {0}", when );
      Console::WriteLine( policy->CacheSyncDate );
      return policy;
   }
   //</snippet3>

   //<snippet4>
   static void DisplayPolicyDetails( HttpRequestCachePolicy^ policy )
   {
      Console::WriteLine( L"Synchronize date: {0}", policy->CacheSyncDate );
      Console::WriteLine( L"Max age:   {0}", policy->MaxAge );
      Console::WriteLine( L"Max stale: {0}", policy->MaxStale );
      Console::WriteLine( L"Min fresh: {0}", policy->MinFresh );
   }
   //</snippet4>

   //<snippet5> 
   static HttpRequestCachePolicy^ CreateMinFreshPolicy( TimeSpan span )
   {
      HttpRequestCachePolicy^ policy = gcnew HttpRequestCachePolicy( HttpCacheAgeControl::MinFresh,span );
      Console::WriteLine( L"Minimum freshness {0}", policy->MinFresh );
      return policy;
   }
   //</snippet5>

   //<snippet6>
   static HttpRequestCachePolicy^ CreateMaxStalePolicy( TimeSpan span )
   {
      HttpRequestCachePolicy^ policy = gcnew HttpRequestCachePolicy( HttpCacheAgeControl::MaxStale,span );
      Console::WriteLine( L"Max stale is {0}", policy->MaxStale );
      return policy;
   }
   //</snippet6> 

   //<snippet7>
   static HttpRequestCachePolicy^ CreateMaxAgePolicy( TimeSpan span )
   {
      HttpRequestCachePolicy^ policy = gcnew HttpRequestCachePolicy( HttpCacheAgeControl::MaxAge,span );
      Console::WriteLine( L"Max age is {0}", policy->MaxAge );
      return policy;
   }
   //</snippet7>

   //<snippet8>
   static HttpRequestCachePolicy^ CreateDefaultPolicy()
   {
      HttpRequestCachePolicy^ policy = gcnew HttpRequestCachePolicy;
      Console::WriteLine( policy );
      return policy;
   }
   //</snippet8>

   //<snippet9>
   static HttpRequestCachePolicy^ CreateFreshAndAgePolicy( TimeSpan freshMinimum, TimeSpan ageMaximum )
   {
      HttpRequestCachePolicy^ policy = gcnew HttpRequestCachePolicy( HttpCacheAgeControl::MaxAgeAndMinFresh,
          ageMaximum, freshMinimum );
      Console::WriteLine( policy );
      return policy;
   }
   //</snippet9> 

   //<snippet10>
   static HttpRequestCachePolicy^ CreateFreshAndAgePolicy2( TimeSpan freshMinimum, TimeSpan ageMaximum, DateTime when )
   {
      HttpRequestCachePolicy^ policy = 
          gcnew HttpRequestCachePolicy( HttpCacheAgeControl::MaxAgeAndMinFresh, 
          ageMaximum, freshMinimum, when );
      Console::WriteLine( policy );
      return policy;
      
      // For the following invocation: CreateFreshAndAgePolicy(new TimeSpan(5,0,0), new TimeSpan(10,0,0),         );
      // the output is:
      // Level:Automatic AgeControl:MinFreshAndMaxAge MinFresh:18000 MaxAge:36000
   }
   //</snippet10>

   //<snippet11>
   static WebResponse^ GetResponseUsingCacheDefault( Uri^ uri )
   {
      // Set  the default cache policy level for the "http:" scheme.
      RequestCachePolicy^ policy = gcnew RequestCachePolicy;

      // Create the request.
      WebRequest^ request = WebRequest::Create( uri );
      request->CachePolicy = policy;
      WebResponse^ response = request->GetResponse();
      Console::WriteLine( L"Policy level is {0}.", policy->Level );
      Console::WriteLine( L"Is the response from the cache? {0}", response->IsFromCache );
      return response;
   }
   //</snippet11>

   //<snippet12>
   static HttpRequestCachePolicy^ CreateCacheIfAvailablePolicy()
   {
      HttpRequestCachePolicy^ policy = gcnew HttpRequestCachePolicy( HttpRequestCacheLevel::CacheIfAvailable );
      Console::WriteLine( policy );
      return policy;
   }
   //</snippet12>

   //<snippet13>
   static WebResponse^ GetResponseFromCache( Uri^ uri )
   {
      RequestCachePolicy^ policy = gcnew RequestCachePolicy( RequestCacheLevel::CacheOnly );
      WebRequest^ request = WebRequest::Create( uri );
      request->CachePolicy = policy;
      WebResponse^ response = request->GetResponse();
      Console::WriteLine( L"Policy level is {0}.", policy->Level );
      Console::WriteLine( L"Is the response from the cache? {0}", response->IsFromCache );
      return response;
   }
   //</snippet13>

   //<snippet14>
   static WebResponse^ GetResponseFromServer( Uri^ uri )
   {
      RequestCachePolicy^ policy = gcnew RequestCachePolicy( RequestCacheLevel::NoCacheNoStore );
      WebRequest^ request = WebRequest::Create( uri );
      request->CachePolicy = policy;
      WebResponse^ response = request->GetResponse();
      Console::WriteLine( L"Policy is {0}.", policy );
      Console::WriteLine( L"Is the response from the cache? {0}", response->IsFromCache );
      return response;
   }
   //</snippet14>

   // <snippet15>
   static WebResponse^ GetResponseFromServer2( Uri^ uri )
   {
      RequestCachePolicy^ policy = gcnew RequestCachePolicy( RequestCacheLevel::NoCacheNoStore );
      WebRequest^ request = WebRequest::Create( uri );
      WebRequest::DefaultCachePolicy = policy;
      WebResponse^ response = request->GetResponse();
      Console::WriteLine( L"Policy is {0}.", policy );
      Console::WriteLine( L"Is the response from the cache? {0}", response->IsFromCache );
      return response;
   }
   // </snippet15>

   void TestSimpleCache()
   {
      /*           WebResponse response = GetResponseUsingDefaultCache (new Uri("http://www.example.com")); 
              DisplayResponseStream (response);
              Console.WriteLine("hit enter for next test..."); Console.ReadLine();
                  response = GetResponseNoCache (new Uri("http://www.example.com"));
              DisplayResponseStream (response);
      
              DisplayPolicyDetails(CreateLastSyncPolicy(DateTime.Now));
              Console.WriteLine("hit enter for next test...");  Console.ReadLine();
      
              DisplayPolicyDetails(CreateMinFreshPolicy(new TimeSpan(10,0,0)));
              Console.WriteLine("hit enter for next test...");  Console.ReadLine();
      
              DisplayPolicyDetails(CreateMaxStalePolicy(new TimeSpan(1,10,0)));
              Console.WriteLine("hit enter for next test...");  Console.ReadLine();
              DisplayPolicyDetails(CreateMaxAgePolicy(new TimeSpan(10,0,0)));
              Console.WriteLine("hit enter for next test...");  Console.ReadLine();
      
              DisplayPolicyDetails(CreateDefaultPolicy());
              Console.WriteLine("hit enter for next test...");  Console.ReadLine();
      
              DisplayPolicyDetails(CreateFreshAndAgePolicy(new TimeSpan(5,0,0), new TimeSpan(10,0,0)));
              Console.WriteLine("hit enter for next test...");  Console.ReadLine();
      
              DisplayPolicyDetails(CreateFreshAndAgePolicy2(new TimeSpan(5,0,0), new TimeSpan(10,0,0), DateTime.Now));
              Console.WriteLine("hit enter for next test...");  Console.ReadLine();
      
                  response = GetResponseUsingCacheDefault (new Uri("http://www.example.com")); 
              DisplayResponseStream (response);
              Console.WriteLine("hit enter for next test...");  Console.ReadLine();
      
              DisplayPolicyDetails(CreateCacheIfAvailablePolicy());
      
              response =  GetResponseFromCache (new Uri("http://www.example.com")); 
              DisplayResponseStream (response);
              Console.WriteLine("hit enter for next test..."); Console.ReadLine();
              response =  GetResponseFromServer (new Uri("http://www.example.com")); 
              DisplayResponseStream (response);
      
                          Console.WriteLine("hit enter for next test..."); Console.ReadLine();
      */
      WebResponse^ response = GetResponseFromServer2( gcnew Uri( L"http://www.example.com" ) );
      DisplayResponseStream( response );
      Console::WriteLine( L"done." );
   }

   static void DisplayResponseStream( WebResponse^ response )
   {
      Stream^ stream = response->GetResponseStream();
      while ( true )
      {
         array<Byte>^buffer = gcnew array<Byte>(1024);
         int read = stream->Read( buffer, 0, buffer->Length );
         if ( read == 0 )
         {
            stream->Close();
            break;
         }
         else
         {
            Console::Write( Encoding::UTF8->GetString( buffer ) );
         }
      }

      stream->Close();
   }

};

void main()
{
   CacheExample^ ce = gcnew CacheExample;
   ce->TestSimpleCache();
}

