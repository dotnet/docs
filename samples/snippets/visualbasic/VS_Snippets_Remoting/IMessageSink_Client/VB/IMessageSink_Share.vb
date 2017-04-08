Imports System

Namespace Share
   Public Class MyHelloService
      Inherits MarshalByRefObject

      Public Function myFunction(ByVal myName As String) As String
         Dim myMessage As String = "Hi there " + myName + ", you are using .NET Remoting"
         Console.WriteLine(myMessage)
         Return myMessage
      End Function 'myFunction
   End Class 'MyHelloService
End Namespace 'Share