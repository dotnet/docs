' This is supporting program for the 'SoapClientFormatterSinkProvider_CreateSink_Client'.

Imports System

Public Class HelloService
   Inherits MarshalByRefObject

   Public Sub New()
      Console.WriteLine("Server Started ")
   End Sub 'New

   Public Function HelloMethod(name As String) As String
      Return "Hi, " + name
   End Function 'HelloMethod
End Class 'HelloService