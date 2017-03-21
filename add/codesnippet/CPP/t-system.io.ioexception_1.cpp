               // Catch the IOException generated if the 
               // specified part of the file is locked.
               catch ( IOException^ e ) 
               {
                  Console::WriteLine( "{0}: The write operation could not "
                  "be performed because the specified "
                  "part of the file is locked.", e->GetType()->Name );
               }

               