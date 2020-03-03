
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp
Imports System.Runtime.Remoting.Lifetime



Namespace RemotingSamples
   Class HelloServer

      Shared Sub Main()
         RemotingConfiguration.Configure("Server.config")
         Console.WriteLine("Server started.")
         Console.WriteLine("Hit enter to terminate...")
         Console.Read()
      End Sub
   End Class
End Namespace 'RemotingSamples