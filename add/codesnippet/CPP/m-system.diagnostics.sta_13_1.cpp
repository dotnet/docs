
      [STAThread]
      static void Main()
      {
         ClassLevel1 ^ mainClass = gcnew ClassLevel1;
         try
         {
            mainClass->InternalMethod();
         }
         catch ( Exception^ e ) 
         {
            Console::WriteLine( " Main method exception handler" );
            
            // Display file and line information, if available.
            StackTrace^ st = gcnew StackTrace( gcnew StackFrame( true ) );
            Console::WriteLine( " Stack trace for current level: {0}", st->ToString() );
            Console::WriteLine( " File: {0}", st->GetFrame( 0 )->GetFileName() );
            Console::WriteLine( " Line Number: {0}", st->GetFrame( 0 )->GetFileLineNumber().ToString() );
            Console::WriteLine();
            Console::WriteLine( "-------------------------------------------------\n" );
         }

      }
