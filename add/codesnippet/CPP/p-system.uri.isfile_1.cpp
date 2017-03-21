         Uri^ uriAddress2 = gcnew Uri( "file://server/filename.ext" );
         Console::WriteLine( uriAddress2->LocalPath );
         Console::WriteLine( "Uri {0} a UNC path", uriAddress2->IsUnc ? (String^)"is" : "is not" );
         Console::WriteLine( "Uri {0} a local host", uriAddress2->IsLoopback ? (String^)"is" : "is not" );
         Console::WriteLine( "Uri {0} a file", uriAddress2->IsFile ? (String^)"is" : "is not" );