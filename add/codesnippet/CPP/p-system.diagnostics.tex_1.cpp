      #if defined(TRACE)
      TextWriterTraceListener^ myWriter = gcnew TextWriterTraceListener;
      myWriter->Writer = System::Console::Out;
      Trace::Listeners->Add( myWriter );
      #endif