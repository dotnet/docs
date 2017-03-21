                    ' Update the file.
                    Case "W"C
                        Try
                            aFileStream.Seek(textLength, _
                                SeekOrigin.Begin)
                            aFileStream.Read( _
                                readText, textLength - 1, byteCount)
                            tempString = New String( _
                                uniEncoding.GetChars( _
                                readText, textLength - 1, byteCount))
                            recordNumber = _
                                Integer.Parse(tempString) + 1
                            aFileStream.Seek( _
                                textLength, SeekOrigin.Begin)
                            aFileStream.Write(uniEncoding.GetBytes( _
                                recordNumber.ToString()), 0, byteCount)
                            aFileStream.Flush()
                            Console.WriteLine( _
                                "Record has been updated.")