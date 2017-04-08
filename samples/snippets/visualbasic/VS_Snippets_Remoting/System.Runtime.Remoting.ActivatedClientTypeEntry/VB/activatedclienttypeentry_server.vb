'<snippet10>
Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp

Public Class MyServer
    
    Public Shared Sub Main()
        ChannelServices.RegisterChannel(New TcpChannel(8082))
        RemotingConfiguration.RegisterActivatedServiceType(GetType(HelloServer))
        Console.WriteLine("Press enter to stop this process")
        Console.ReadLine()
    End Sub 'Main

End Class 'MyServer
'</snippet10>
