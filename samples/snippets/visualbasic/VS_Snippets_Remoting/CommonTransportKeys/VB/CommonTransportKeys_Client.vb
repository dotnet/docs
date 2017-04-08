' Supporting file: Client

Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels

Imports Logging

Public Class Client
   
   Public Shared Sub Main()
      Try
         RemotingConfiguration.Configure("channels.config")
         RemotingConfiguration.Configure("client.exe.config")

         Dim server As New Foo()
         ' Call share method. 
         server.PrintString("String logged to console.")
         Console.WriteLine("Connected to server ...")
      Catch e As Exception
         Console.WriteLine("Exception :{0}", e.Message)
      End Try
   End Sub 'Main
End Class 'Client