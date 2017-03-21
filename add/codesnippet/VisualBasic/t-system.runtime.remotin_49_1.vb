' Implementation of 'IChannelReceiverHook' interface.
<PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
Public Class MyCustomChannel
   Implements IChannelReceiverHook 
   Private portSet As Boolean

   ' Constructor for MyCustomChannel.
   Public Sub New(ByVal port As Integer)
      portSet = True
   End Sub 'New

   ' Constructor for MyCustomChannel.
   Public Sub New()
      portSet = False
   End Sub 'New

   Public ReadOnly Property WantsToListen() As Boolean Implements IChannelReceiverHook.WantsToListen
      Get
         If portSet Then
            Return False
         Else
            Return True
         End If
      End Get
   End Property

   Private MyChannelScheme As String = "http"

   Public ReadOnly Property ChannelScheme() As String Implements IChannelReceiverHook.ChannelScheme
      Get
         Return MyChannelScheme
      End Get
   End Property

   Public ReadOnly Property ChannelSinkChain() As IServerChannelSink _
                                       Implements IChannelReceiverHook.ChannelSinkChain
      Get
         ' Null implementation.
         Return Nothing
      End Get
   End Property

   Public Sub AddHookChannelUri(ByVal channelUri As String) _
                                          Implements IChannelReceiverHook.AddHookChannelUri
      ' Null implementation.
   End Sub 'AddHookChannelUri
End Class 'MyCustomChannel 