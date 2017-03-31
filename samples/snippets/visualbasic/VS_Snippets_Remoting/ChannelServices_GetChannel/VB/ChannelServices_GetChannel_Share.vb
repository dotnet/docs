' This program implments the remote method which will be called by the
' client.   

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
