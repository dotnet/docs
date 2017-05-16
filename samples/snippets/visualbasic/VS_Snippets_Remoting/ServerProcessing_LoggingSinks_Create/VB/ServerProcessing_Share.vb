' This file is a support file for demonstrating IClientChannelSinkProvider 
' and ServerProcessing.

Imports System

Public Class MyHelloService
   Inherits MarshalByRefObject
   Private Shared myInstances As Integer

   Public Sub New()
      myInstances += 1
      Console.WriteLine("")
       Console.WriteLine("MyHelloService activated - instance # {0}.", myInstances)
   End Sub 'New
   
   Public Function HelloMethod(myString As String) As String
      Console.WriteLine("HelloMethod called on MyHelloService instance {0}.", myInstances)
      Return "Hi there " +  myString + "."
   End Function 'HelloMethod
End Class 'MyHelloService