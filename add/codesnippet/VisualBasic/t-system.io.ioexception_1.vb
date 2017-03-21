                        ' Catch the IOException generated if the 
                        ' specified part of the file is locked.
                        Catch ex As IOException
                            Console.WriteLine( _
                                "{0}: The write operation could " & _
                                "not be performed because the " & _
                                "specified part of the file is " & _
                                "locked.", ex.GetType().Name)
                        End Try