Imports System

Public Class HelloServer
   Inherits MarshalByRefObject
   
   Public Sub New()
      Console.WriteLine("The hashcode of servicing object:" + Me.GetHashCode().ToString())
   End Sub 'New
   
   Public Function HelloMethod(name As String) As String
      Console.WriteLine("'HelloServer.HelloMethod' method is called by : {0}", name)
      Return "Hi! " + name + " is calling 'HelloServer.HelloMethod' method. "
   End Function 'HelloMethod
End Class 'HelloServer