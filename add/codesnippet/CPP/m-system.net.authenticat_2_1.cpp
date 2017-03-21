   // This is the program entry point. It allows the user to enter 
   // her credentials and the Internet resource (Web page) to access.
   // It also unregisters the standard and registers the customized basic 
   // authentication.
   static void Main()
   {
      array<String^>^args = Environment::GetCommandLineArgs();
      if ( args->Length < 4 )
            showusage();
      else
      {
         
         // Read the user's credentials.
         uri = args[ 1 ];
         username = args[ 2 ];
         password = args[ 3 ];
         if ( args->Length == 4 )
                  domain = String::Empty; // If the domain exists, store it. Usually the domain name
         else
                  domain = args[ 4 ];

         
         // is by default the name of the server hosting the Internet
         // resource.
         // Unregister the standard Basic authentication module.
         AuthenticationManager::Unregister( "Basic" );
         
         // Instantiate the custom Basic authentication module.
         CustomBasic^ customBasicModule = gcnew CustomBasic;
         
         // Register the custom Basic authentication module.
         AuthenticationManager::Register( customBasicModule );
         
         // Display registered Authorization modules.
         displayRegisteredModules();
         
         // Read the specified page and display it on the console.
         getPage( uri );
      }

      return;
   }
