   // Signals when the resolve has finished.
public:
   static ManualResetEvent^ GetHostEntryFinished =
      gcnew ManualResetEvent( false );

   // define the state object for the callback. 
   // use hostName to correlate calls with the proper result.
   ref class ResolveState
   {
   public:
      String^ hostName;
      IPHostEntry^ resolvedIPs;

      ResolveState( String^ host )
      {
         hostName = host;
      }

      property IPHostEntry^ IPs 
      {
         IPHostEntry^ get()
         {
            return resolvedIPs;
         }
         void set( IPHostEntry^ IPs )
         {
            resolvedIPs = IPs;
         }
      }

      property String^ host 
      {
         String^ get()
         {
            return hostName;
         }
         void set( String^ host )
         {
            hostName = host;
         }
      }
   };

   // Record the IPs in the state object for later use.
   static void GetHostEntryCallback( IAsyncResult^ ar )
   {	  
      ResolveState^ ioContext = (ResolveState^)( ar->AsyncState );

      ioContext->IPs = Dns::EndGetHostEntry( ar );
      GetHostEntryFinished->Set();
   }


   // Determine the Internet Protocol(IP) addresses for this 
   // host asynchronously.
public:
   static void DoGetHostEntryAsync( String^ hostName )
   {
      GetHostEntryFinished->Reset();
      ResolveState^ ioContext = gcnew ResolveState( hostName );

      Dns::BeginGetHostEntry( ioContext->host,
         gcnew AsyncCallback( GetHostEntryCallback ), ioContext );
      // Wait here until the resolve completes 
      // (the callback calls .Set())
      GetHostEntryFinished->WaitOne();

      Console::WriteLine("EndGetHostEntry({0}) returns:", ioContext->host);
      
      for (int i = 0; i < ioContext->IPs->AddressList->Length; i++)
      {				
		Console::WriteLine("    {0}", ioContext->IPs->AddressList[i]->ToString());			
      }
      

//      for each ( IPAddress^ ip in ioContext->IPs )
 //     {
 //        Console::WriteLine( "{0} ", ip );
 //     }
   }