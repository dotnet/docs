// Class-level declaration.
// Create a TraceSwitch.
private:
   static TraceSwitch^ generalSwitch = 
      gcnew TraceSwitch( "General", "Entire Application" );

public:
   static void MyErrorMethod( Object^ myObject )
   {
      #if defined(TRACE)
      // Write the message if the TraceSwitch level 
      // is set to Error or higher.
      if ( generalSwitch->TraceError )
      {
         Trace::Write( myObject );
      }
      
      // Write a second message if the TraceSwitch level
      // is set to Verbose.
      if ( generalSwitch->TraceVerbose )
      {
          Trace::WriteLine( " is not a valid value for this method." );
      }
      #endif
   }