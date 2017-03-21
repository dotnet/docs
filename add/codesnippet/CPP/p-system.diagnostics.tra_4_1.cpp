      // Create a ConsoletTraceListener and add it to the trace listeners.
      #if defined(TRACE)
      ConsoleTraceListener^ myWriter = gcnew ConsoleTraceListener( );
      Trace::Listeners->Add( myWriter );
      #endif