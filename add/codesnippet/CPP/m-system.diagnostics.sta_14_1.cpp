            StackTrace^ st = gcnew StackTrace( 1,true );
            array<StackFrame^>^stFrames = st->GetFrames();
            for ( int i; i < stFrames->Length; i++ )
            {
               StackFrame^ sf = stFrames[ i ];
               Console::WriteLine( "Method: {0}", sf->GetMethod() );

            }