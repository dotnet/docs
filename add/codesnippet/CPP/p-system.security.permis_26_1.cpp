   // Use the enumeration flags to indicate that this method exposes shared state and 
   // self-affecting process management.
   // Either of the following attribute statements can be used to set the 
   // resource flags.
   // Exit the sample when an exception is thrown.

   [HostProtection(SharedState=true,SelfAffectingProcessMgmt=true)]
   [HostProtection(Resources=HostProtectionResource::SharedState|
   HostProtectionResource::SelfAffectingProcessMgmt)]
   static void Exit( String^ Message, int Code )
   {
      Console::WriteLine( "\nFAILED: {0} {1}", Message, Code );
      Environment::ExitCode = Code;
      Environment::Exit( Code );
   }