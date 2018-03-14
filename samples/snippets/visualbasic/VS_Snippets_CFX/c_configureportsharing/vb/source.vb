
Imports System
Imports System.ServiceModel

Namespace Samples

    '<snippet1>
    <ServiceContract()> _
    Friend Interface IMyService

        'Define the contract operations.

    End Interface

    Friend Class MyService
        Implements IMyService

        'Implement the IMyService operations.

    End Class
    '</snippet1>

    Public Class Test
        Public Shared Sub Main()
        End Sub

        Private Sub CreateNetTcpBinding()
            '<snippet2>
            Dim portsharingBinding As New NetTcpBinding()
            portsharingBinding.PortSharingEnabled = True
            '</snippet2>

            '<snippet3>
            Dim host As New ServiceHost(GetType(MyService))
            host.AddServiceEndpoint(GetType(IMyService), portsharingBinding, "net.tcp://localhost/MyService")
            '</snippet3>

        End Sub

        Private Sub EnablePortSharing()

        End Sub

    End Class
End Namespace
