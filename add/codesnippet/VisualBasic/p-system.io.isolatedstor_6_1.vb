                            Console.WriteLine("Writing data to the new file.")
                            While source.Position < source.Length
                                inputChar = CByte(source.ReadByte())
                                target.WriteByte(inputChar)
                            End While

                            ' Determine the size of the IsolatedStorageFileStream
                            ' by checking its Length property.
                            Console.WriteLine(("Total Bytes Read: " & source.Length))