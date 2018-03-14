' <Snippet1>
Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp


Public Class HelloServer
   Inherits MarshalByRefObject
   
   Private n_called As Integer = 0
   
   
   Public Shared Sub Main()
' </Snippet1>
' <Snippet2>      
      ' Registers the server and waits until the user hits enter.
      Dim chan As New TcpChannel(8084)
      ChannelServices.RegisterChannel(chan)
      
      RemotingConfiguration.RegisterWellKnownServiceType(Type.GetType("HelloServer,server"), "SayHello", WellKnownObjectMode.SingleCall)
      System.Console.WriteLine("Hit <enter> to exit...")
      System.Console.ReadLine()
' </Snippet2>
' <Snippet3>
   End Sub 'Main
    
      
   Public Sub New()
      Console.WriteLine("HelloServer activated")
   End Sub 'New
   
      
   Protected Overrides Sub Finalize()
      Console.WriteLine("Object Destroyed")
      MyBase.Finalize()
   End Sub 'Finalize

         
   Public Function HelloMethod(name As [String]) As [String]
      ' Reports that the method was called.
      Console.WriteLine()
      Console.WriteLine("Hello.HelloMethod : {0}", name)
      n_called += 1
      Console.WriteLine("The method was called {0} times.", n_called)
      
      ' Calculates and returns the result to the client.
      Return "Hi there " + name
   End Function 'HelloMethod

End Class 'HelloServer
' </Snippet3>