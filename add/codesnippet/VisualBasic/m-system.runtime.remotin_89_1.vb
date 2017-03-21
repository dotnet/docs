         ' Create remote version of TempConverter.Converter.
         Dim converter1 As TempConverter.Converter

         converter1 = CType(Activator.GetObject(GetType( _
                              TempConverter.Converter), _
                              "http://localhost:8085/TempConverter"), _
                              TempConverter.Converter)
         ' Create local version of TempConverter.Converter.
         Dim converter2 As New TempConverter.Converter()

         ' Returns true, converter1 is remote and in a different appdomain.
         System.Runtime.Remoting.RemotingServices.IsObjectOutOfAppDomain( _
                                                            converter1)

         ' Returns false, converter2 is local and running in this appdomain.
         System.Runtime.Remoting.RemotingServices.IsObjectOutOfAppDomain( _
                                                            converter2)

         ' Returns true, converter1 is remote and in a different context.
         System.Runtime.Remoting.RemotingServices.IsObjectOutOfContext( _
                                                            converter1)

         ' Returns false, converter2 is local and running in this context.
         System.Runtime.Remoting.RemotingServices.IsObjectOutOfContext( _
                                                            converter2)