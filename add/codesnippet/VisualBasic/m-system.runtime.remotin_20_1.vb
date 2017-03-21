      ' Create and send the object URL.
      Public Function GetUrlsForUri(ByVal objectURI As String) As String() _
                                                Implements IChannelReceiver.GetUrlsForUri
         Dim myString(0) As String
         myString(0) = Dns.Resolve(Dns.GetHostName()).AddressList(0).ToString() + "/" + objectURI
         Return myString
      End Function 'GetUrlsForUri