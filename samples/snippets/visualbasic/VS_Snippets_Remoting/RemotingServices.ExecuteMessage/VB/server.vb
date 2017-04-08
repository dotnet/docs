
Imports System
Imports System.Diagnostics
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp
Imports System.Runtime.Remoting.Contexts



Public Class ServerProcess
    
    Public Shared Sub Main(ByVal args() As String) 
        Dim channel As TcpChannel
        Dim isReplicationServer As Boolean = False
        ' Determine if this should be the replication server
        If args.Length > 0 AndAlso args(0).ToLower() = "r" Then
            isReplicationServer = True
            channel = New TcpChannel(9001)
        Else
            channel = New TcpChannel(9000)
        End If
        ChannelServices.RegisterChannel(channel)
        Dim entry As New WellKnownServiceTypeEntry(GetType(SampleService), "SampleServiceUri", WellKnownObjectMode.Singleton)
        RemotingConfiguration.RegisterWellKnownServiceType(entry)
        If Not isReplicationServer Then
            Dim myProp As New ReplicationSinkProp()
            Context.RegisterDynamicProperty(myProp, Nothing, Nothing)
        End If
        Console.WriteLine("**** Press enter to stop this process. ****" + vbLf)
        Console.ReadLine()
    
    End Sub 'Main
End Class 'ServerProcess


