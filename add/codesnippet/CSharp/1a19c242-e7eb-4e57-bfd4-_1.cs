               string[] myURLArray = ChannelServices.GetUrlsForObject(myHelloServer);
               Console.WriteLine("Number of URLs for the specified Object: "
                  +myURLArray.Length);
               for (int iIndex=0; iIndex<myURLArray.Length; iIndex++)
                  Console.WriteLine("URL: "+myURLArray[iIndex]);