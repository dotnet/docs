   // Create a listener that outputs to the console screen 
   // and add it to the debug listeners.
   #if defined(DEBUG)
   TextWriterTraceListener^ myWriter = 
      gcnew TextWriterTraceListener( System::Console::Out );
   Debug::Listeners->Add( myWriter );
   #endif