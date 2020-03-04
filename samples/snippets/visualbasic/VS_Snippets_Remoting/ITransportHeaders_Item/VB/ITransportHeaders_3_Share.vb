' Supporting file for the ITransportHeaders_3_Server.vb
Public Class MyHelloServer
   Inherits MarshalByRefObject

   Public Sub New()
      Console.WriteLine("HelloServer activated...")
   End Sub

   Public Function MyHelloMethod(name As String) As String
      Console.WriteLine("MyHelloServer.MyHelloMethod : {0}", name)
      Return "Hello " + name
   End Function 'MyHelloMethod
End Class