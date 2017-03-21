   class MyCustomChannel : IChannelReceiver
   {
      private ChannelDataStore myChannelData;
      private int myChannelPriority = 25;
      // Set the 'ChannelName' to 'MyCustomChannel'.
      private string myChanneName = "tcp";
      // Implement 'ChannelName' property.
      private TcpListener myTcpListener;
      private int myPortNo;
      private bool myListening = false;
      private Thread myThread;
      public MyCustomChannel(int portNo)
      {  
         myPortNo = portNo;
         string [] myURI = new string[1];
         myURI[0] = Dns.Resolve(Dns.GetHostName()).AddressList[0] + ":" +
                                                            portNo.ToString();
         // Store the 'URI' in 'myChannelDataStore'.
         myChannelData = new ChannelDataStore(myURI);
         // Create 'myTcpListener' to listen at the 'myPortNo' port.
         myTcpListener = new TcpListener(myPortNo);
         // Create the thread 'myThread'.
         myThread = new Thread(new ThreadStart(myTcpListener.Start));
         this.StartListening(null);
      }
      public string ChannelName
      {
         get
         {
            return myChanneName;
         }
      }
      public int ChannelPriority
      {
         get
         {
            return myChannelPriority;
         }
      }
      public string Parse(string myUrl, out string objectURI)
      {
         Regex myRegex = new Regex("/",RegexOptions.RightToLeft);
         // Check for '/' in 'myUrl' from Right to left.
         Match myMatch = myRegex.Match(myUrl);
         // Get the object URI.
         objectURI = myUrl.Substring(myMatch.Index);
         // Return the channel url.
         return myUrl.Substring(0,myMatch.Index);   
      }
      // Implementation of 'IChannelReceiver' interface.
      public object ChannelData
      {
         get
         {
            return myChannelData;
         }
      }

      // Create and send the object URL.
      public string[] GetUrlsForUri(string objectURI)
      {
         string[] myString = new string[1];
         myString[0] = Dns.Resolve(Dns.GetHostName()).AddressList[0]
                                                            + "/" + objectURI;
         return myString;
      }

      // Start listening to the port.
      public void StartListening(object data)
      {
         if(myListening == false)
         {
            myTcpListener.Start();
            myListening = true;
            Console.WriteLine("Server Started Listening !!!");
         }
      }

      // Stop listening to the port.
      public void StopListening(object data)
      {
         if(myListening == true)
         {
            myTcpListener.Stop();
            myListening = false;
            Console.WriteLine("Server Stopped Listening !!!");
         }
      }
   }