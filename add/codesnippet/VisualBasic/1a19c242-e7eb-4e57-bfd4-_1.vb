               Dim myURLArray As String() = ChannelServices.GetUrlsForObject(myHelloServer)
               Console.WriteLine("Number of URLs for the specified Object: " + _
                                                            myURLArray.Length.ToString())
               Dim iIndex As Integer
               For iIndex = 0 To myURLArray.Length - 1
                  Console.WriteLine("URL: " + myURLArray(iIndex))
               Next iIndex 