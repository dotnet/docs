                  Console::WriteLine( "Writing data to the new file." );
                  while ( source->Position < source->Length )
                  {
                     inputChar = (Byte)source->ReadByte();
                     target->WriteByte( (Byte)source->ReadByte() );
                  }
                  
                  // Determine the size of the IsolatedStorageFileStream
                  // by checking its Length property.
                  Console::WriteLine( "Total Bytes Read: {0}", source->Length.ToString() );
                  