' This derived class demonstrates the use of three protected methods belonging to the UdpClient class.
Public Class MyUdpClientDerivedClass
   Inherits UdpClient
   
   Public Sub New()
   End Sub 'New
   
   Public Sub UsingProtectedMethods()
      
      'Uses the protected Active property belonging to the UdpClient base class to determine if a connection is established.
      If Me.Active Then
         ' Calls the protected Client property belonging to the UdpClient base class.
         Dim s As Socket = Me.Client
              'Uses the Socket returned by Client to set an option that is not available using UdpClient.
         s.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1)
      End If
   End Sub 'UsingProtectedMethods 
End Class 'MyUdpClientDerivedClass
 
