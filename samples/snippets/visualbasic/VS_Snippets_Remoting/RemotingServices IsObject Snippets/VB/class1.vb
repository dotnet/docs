Imports System
Imports System.Runtime.Remoting


Namespace RemoteClient

   Class Client

      Public Overloads Shared Sub Main()
         Dim client As New Client()
         client.RunSnippet()
      End Sub 'Main

      Public Sub RunSnippet()

         ' <Snippet1>
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
         ' </Snippet1>		
         ' Print those function calls.
         System.Console.WriteLine("{0}", System.Runtime.Remoting.RemotingServices.IsObjectOutOfAppDomain(converter1))
         System.Console.WriteLine("{0}", System.Runtime.Remoting.RemotingServices.IsObjectOutOfAppDomain(converter2))

         System.Console.WriteLine("{0}", System.Runtime.Remoting.RemotingServices.IsObjectOutOfContext(converter1))
         System.Console.WriteLine("{0}", System.Runtime.Remoting.RemotingServices.IsObjectOutOfContext(converter2))
      End Sub
   End Class
End Namespace

Namespace TempConverter

   Public Class Converter
      Inherits MarshalByRefObject
   
   End Class
   
End Namespace

