' Supporting file: Server

Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels

Imports Logging

Public Class Server
   
   Public Shared Sub Main()
      RemotingConfiguration.Configure("channels.config")
      RemotingConfiguration.Configure("server.exe.config")
      
      Console.WriteLine("Listening...")
      
      Dim keyState As String = ""
      While String.Compare(keyState, "0", True) <> 0
         Console.WriteLine("***** Press 0 to exit this service *****")
         keyState = Console.ReadLine()
      End While
   End Sub 'Main
End Class 'Server