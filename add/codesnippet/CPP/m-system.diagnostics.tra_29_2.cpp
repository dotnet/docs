   // Class-level declaration.
   /* Create a TraceSwitch to use in the entire application.*/
private:
   static TraceSwitch^ mySwitch = gcnew TraceSwitch( "General", "Entire Application" );

public:
   static void MyMethod()
   {
      // Write the message if the TraceSwitch level is set to Error or higher.
      if ( mySwitch->TraceError )
         Console::WriteLine( "My error message." );
      
      // Write the message if the TraceSwitch level is set to Verbose.
      if ( mySwitch->TraceVerbose )
         Console::WriteLine( "My second error message." );
   }

   static void main()
   {
      // Run the method that prints error messages based on the switch level.
      MyMethod();
   }