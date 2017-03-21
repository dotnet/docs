                        Console.WriteLine("Writing data to the new file.");
                        while (source.Position < source.Length)
                        {
                            inputChar = (byte)source.ReadByte();
                            target.WriteByte(inputChar);
                        }

                        // Determine the size of the IsolatedStorageFileStream
                        // by checking its Length property.
                        Console.WriteLine("Total Bytes Read: " + source.Length);