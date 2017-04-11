' System.Runtime.Remoting.Channels.IChannelReceiverHook
' System.Runtime.Remoting.Channels.IChannelReceiverHook.WantsToListen
' System.Runtime.Remoting.Channels.IChannelReceiverHook.ChannelScheme

' This example demonstrates the implementation of the 'ChannelScheme' and
' 'WantsToListen' properties of the 'IChannelReceiverHook' interface.
' It creates  a customized channel 'MyCustomChannel' by implementing 
' 'IChannelReceiverHook' interface.

Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Http
Imports System.Security.Permissions

Public Class IChannelReceiverHook_ChannelScheme

   Public Shared Sub Main()
      Try
         Dim myCustomChannelWithPort As New MyCustomChannel(8085)
         Dim myCustomChannelNoPort As New MyCustomChannel()
         Console.WriteLine("Channel Scheme of myCustomChannelWithPort : " + _
                                                         myCustomChannelWithPort.ChannelScheme)
         Console.WriteLine("Channel Scheme of myCustomChannelNoPort : " + _
                                                         myCustomChannelNoPort.ChannelScheme)
         ' 'WantsToListen' is false. It is already listening.
         If myCustomChannelWithPort.WantsToListen Then
             Console.WriteLine("myCustomChannelWithPort wants to listen.")
         Else
             Console.WriteLine("myCustomChannelWithPort doesn't want to listen.")
         End If
         ' 'WantsToListen' is true.
         If myCustomChannelNoPort.WantsToListen Then
             Console.WriteLine("myCustomChannelNoPort wants to listen.")
         Else
             Console.WriteLine("myCustomChannelNoPort doesn't want to listen.")
         End If
      Catch e As Exception
         Console.WriteLine("Exception caught!!!")
         Console.WriteLine("Source : " + e.Source)
         Console.WriteLine("Message : " + e.Message)
      End Try
   End Sub 'Main
End Class 'IChannelReceiverHook_ChannelScheme

' <Snippet1>
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

' <Snippet2>
   Public ReadOnly Property WantsToListen() As Boolean Implements IChannelReceiverHook.WantsToListen
      Get
         If portSet Then
            Return False
         Else
            Return True
         End If
      End Get
   End Property
' </Snippet2>

' <Snippet3>
   Private MyChannelScheme As String = "http"

   Public ReadOnly Property ChannelScheme() As String Implements IChannelReceiverHook.ChannelScheme
      Get
         Return MyChannelScheme
      End Get
   End Property
' </Snippet3>

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
' </Snippet1>