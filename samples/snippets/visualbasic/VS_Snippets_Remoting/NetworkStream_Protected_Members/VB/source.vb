 ' The following sample is intended to demonstrate how to use a 
'NetworkStream for synchronous communcation with a remote host
'This class uses several NetworkStream members that would be useful
' in a synchronous communciation senario
Imports System
Imports System.Text
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading

'<Snippet1>
Public Class MyNetworkStream_Sub_Class
   Inherits NetworkStream
   
   
   Public Sub New(socket As Socket, ownsSocket As Boolean)
      MyBase.New(socket, ownsSocket)
   End Sub 'New
   
   ' Suppose you wanted a property for determining if Socket is connected. You can use
   ' the protected method 'Socket' to return underlying Socket.
   
   Public ReadOnly Property IsConnected() As Boolean
      Get
         Return Me.Socket.Connected
      End Get
   End Property
   
   ' You could also use public NetworkStream methods 'CanRead' and 'CanWrite'.
   
   Public ReadOnly Property CanCommunicate() As Boolean
      Get
         If Not Me.Readable Or Not Me.Writeable  Then
            Return False
         Else
            Return True
         End If
      End Get
   End Property
    
   Public Shared Sub DoSomethingSignificant()
   End Sub 'DoSomethingSignificant
    ' Do something significant in here
   
   '</Snippet1>
   Public Shared Sub Main()
      MyNetworkStream_Sub_Class.DoSomethingSignificant()
   End Sub 'Main 
End Class 'MyNetworkStream_Sub_Class


