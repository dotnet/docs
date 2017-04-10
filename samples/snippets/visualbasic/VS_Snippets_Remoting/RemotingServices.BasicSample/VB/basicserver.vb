
Imports System
Imports System.Collections
Imports System.IO
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Http
Imports System.Threading
Imports SampleNamespace




Public Class Server
    
    Public Shared Sub Main(ByVal args() As String) 
        Dim serverConfigFile As String = "basicserver.exe.config"
        If args.Length > 1 AndAlso(args(0).ToLower() = "/c" Or args(0).ToLower() = "-c") Then
            serverConfigFile = args(1)
        End If
        RemotingConfiguration.Configure("channels.config")
        RemotingConfiguration.Configure(serverConfigFile)
        
        Console.WriteLine("Listening...")
        
        Dim keyState As String = ""
        While String.Compare(keyState, "0", True) <> 0
            Console.WriteLine("***** Press 0 to exit this service *****")
            keyState = Console.ReadLine()
        End While
    
    End Sub 'Main
End Class 'Server
