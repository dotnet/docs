      void Level3Method()
      {
         try
         {
            ClassLevel4^ nestedClass = gcnew ClassLevel4;
            nestedClass->Level4Method();
         }
         catch ( Exception^ e ) 
         {
            Console::WriteLine( " Level3Method exception handler" );
            
            // Build a stack trace from a dummy stack frame.
            // Explicitly specify the source file name and line number.
            StackTrace^ st = gcnew StackTrace( gcnew StackFrame( "source.cs",60 ) );
            Console::WriteLine( " Stack trace with dummy stack frame: {0}", st->ToString() );
            for ( int i = 0; i < st->FrameCount; i++ )
            {
               
               // Display the stack frame properties.
               StackFrame^ sf = st->GetFrame( i );
               Console::WriteLine( " File: {0}", sf->GetFileName() );
               Console::WriteLine( " Line Number: {0}", sf->GetFileLineNumber().ToString() );
               
               // Note that the column number defaults to zero
               // when not initialized.
               Console::WriteLine( " Column Number: {0}", sf->GetFileColumnNumber().ToString() );
               Console::WriteLine( " Intermediate Language Offset: {0}", sf->GetILOffset().ToString() );
               Console::WriteLine( " Native Offset: {0}", sf->GetNativeOffset().ToString() );
               

            }
            Console::WriteLine();
            Console::WriteLine( "   ... throwing exception to next level ..." );
            Console::WriteLine( "-------------------------------------------------\n" );
            throw e;
         }

      }
