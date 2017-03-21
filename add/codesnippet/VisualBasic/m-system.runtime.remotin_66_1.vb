         Dim myClientChannel As New HttpChannel(myProperties, New SoapClientFormatterSinkProvider(), _
                                                            New SoapServerFormatterSinkProvider())
         ChannelServices.RegisterChannel(myClientChannel)
         ' Get the registered channel. 
         Console.WriteLine("Channel Name : " + ChannelServices.GetChannel _
                                                      (myClientChannel.ChannelName).ChannelName)
         Console.WriteLine("Channel Priorty : " + _
               ChannelServices.GetChannel(myClientChannel.ChannelName).ChannelPriority.ToString())