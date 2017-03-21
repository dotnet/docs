   Class CustomChannel
      Inherits BaseChannelWithProperties
      Implements IChannelReceiverHook, IChannelReceiver, IChannel, IChannelSender

      Public Sub AddHookChannelUri(ByVal channelUri As String) _
                           Implements IChannelReceiverHook.AddHookChannelUri

         If Not (channelUri Is Nothing) Then
            Dim uris As String() = dataStore.ChannelUris

            ' This implementation only allows one URI to be hooked in.
            If uris Is Nothing Then
               Dim newUris(1) As String
               newUris(0) = channelUri
               dataStore.ChannelUris = newUris
               wantsListen = False
            Else
               Dim msg As String
               msg = "This channel is already listening for data, and " + _
                     "can't be hooked into at this stage."
               Throw New System.Runtime.Remoting.RemotingException(msg)
            End If
         End If
      End Sub

      ' The rest of CustomChannel's implementation.