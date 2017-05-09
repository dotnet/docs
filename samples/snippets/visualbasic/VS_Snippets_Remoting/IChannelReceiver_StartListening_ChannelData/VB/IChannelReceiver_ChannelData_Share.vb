' The class 'HelloServer' is derived from 'MarshalByRefObject' to make
' it remotable. Ihe method 'HelloMethod' can be called by the client
' after creating instance of the 'HelloServer' class.

Imports System

Namespace RemotingSamples
   Public Class HelloServer
      Inherits MarshalByRefObject

      Public Sub New()
         Console.WriteLine("HelloServer activated")
      End Sub 'New
      
      Public Function HelloMethod(name As String) As String
         Console.WriteLine("Hello.HelloMethod : {0}", name)
         Return "Hi there " + name
      End Function 'HelloMethod
   End Class 'HelloServer
End Namespace 'RemotingSamples