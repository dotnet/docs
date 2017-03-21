      // Create and send the object URL.
      public string[] GetUrlsForUri(string objectURI)
      {
         string[] myString = new string[1];
         myString[0] = Dns.Resolve(Dns.GetHostName()).AddressList[0]
                                                            + "/" + objectURI;
         return myString;
      }