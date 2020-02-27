' This program will define the methods to execute from the client.

Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Http

Public Class MyHelloServer
   Inherits MarshalByRefObject
   
   Public Sub New()
      Console.WriteLine("HelloServer activated")
   End Sub
   
   Public Function myHelloMethod(name As String) As String
      Console.WriteLine("Hello.HelloMethod : {0}", name)
      Return "Hi there " + name
   End Function 'myHelloMethod
End Class