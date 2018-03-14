
Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp
Imports System.Runtime.Remoting.Lifetime


Namespace RemotingSamples
   Public Class HelloService
      Inherits MarshalByRefObject

      Public Function HelloMethod(name As String) As String
         Console.WriteLine("Hello " + name)
         Return "Hello " + name
      End Function 'HelloMethod
   End Class 'HelloService
End Namespace 'RemotingSamples