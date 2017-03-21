      Dim channelUri() As String = New String(4) {}
      Dim myIChannelDataStore = New ChannelDataStore(channelUri)
      Dim myIChannelDataStore1 = New ChannelDataStore(channelUri)
      myIServerChannelSinkProvider.GetChannelData(myIChannelDataStore)
      myIServerChannelSinkProvider1.GetChannelData(myIChannelDataStore1)