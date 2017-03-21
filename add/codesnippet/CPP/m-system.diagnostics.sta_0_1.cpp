               // Display the stack frame properties.
               StackFrame^ sf = st->GetFrame( i );
               Console::WriteLine( " File: {0}", sf->GetFileName() );
               Console::WriteLine( " Line Number: {0}", sf->GetFileLineNumber().ToString() );
               
               // Note that the column number defaults to zero
               // when not initialized.
               Console::WriteLine( " Column Number: {0}", sf->GetFileColumnNumber().ToString() );
               Console::WriteLine( " Intermediate Language Offset: {0}", sf->GetILOffset().ToString() );
               Console::WriteLine( " Native Offset: {0}", sf->GetNativeOffset().ToString() );
               