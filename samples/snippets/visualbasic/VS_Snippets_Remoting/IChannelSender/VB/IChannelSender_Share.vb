' This file is a support file for demonstrating the members of
' IChannelSender interface on the client side. The program will
' define the methods to execute from the client.

Imports System

Public Class MyHelloServer
   Inherits MarshalByRefObject
   
   Public Sub New()
      Console.WriteLine("HelloServer activated")
   End Sub 'New
   
   Public Function myHelloMethod(myString As String) As String
      Console.WriteLine("Hello.HelloMethod : {0}", myString)
      Return "Hi there " + myString
   End Function 'myHelloMethod
   
End Class 'MyHelloServer