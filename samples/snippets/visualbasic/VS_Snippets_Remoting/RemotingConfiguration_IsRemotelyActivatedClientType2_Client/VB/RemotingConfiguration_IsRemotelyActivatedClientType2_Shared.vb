
Imports System

Public Class MyServerImpl
   Inherits MarshalByRefObject
   Private i As Integer
   
   Public Sub New()
      i = 0
      Console.WriteLine("Server Activated...")
   End Sub 'New
   
   Public Function MyMethod(name As String) As String
      i = i + 1
      Return "The client requests to " + name + i.ToString() + " time"
   End Function 'MyMethod
End Class 'MyServerImpl

