    public class MySinkProviderData : IServerChannelSinkProvider
    {
        private IServerChannelSinkProvider myIServerChannelSinkProviderNew;

        private bool myAcceptMode = true;
        private ICollection myCollectionData = null;

        public MySinkProviderData()
        {
        }

        public MySinkProviderData(IDictionary properties, ICollection providerData)
        {
            String myMode = (String)properties["mode"];
            if (String.Compare(myMode, "accept", true) == 0)
                myAcceptMode = true;
            else
                if (String.Compare(myMode, "reject", true) == 0)
                myAcceptMode = false;
            myCollectionData = providerData;
        }

        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.Infrastructure)]
        public void GetChannelData(IChannelDataStore myLocalChannelData)
        {
        }
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.Infrastructure)]
        public IServerChannelSink CreateSink(IChannelReceiver myChannel)
        {
            IServerChannelSink myIServerChannelSink_nextSink = null;
            if (myIServerChannelSinkProviderNew != null)
                myIServerChannelSink_nextSink = myIServerChannelSinkProviderNew.CreateSink(myChannel);
            MyIPFilterChannelSink mySink = new MyIPFilterChannelSink(myAcceptMode,
                myIServerChannelSink_nextSink);
            // Create and initialize a new ArrayList.
            ArrayList myArrayList = new ArrayList();

            // Add filters.
            foreach (SinkProviderData mySinkData in myCollectionData)
            {
                // The SinkProviderData properties are added to the ArrayList.
                myArrayList.Add(mySinkData.Children);
                myArrayList.Add(mySinkData.Name);

                String myMaskString = (String)mySinkData.Properties["mask"];
                String myIPString = (String)mySinkData.Properties["ip"];
                String myMachineString = (String)mySinkData.Properties["machine"];

                IPAddress mask = null;
                IPAddress ip = null;

                if (myIPString != null)
                {
                    mask = IPAddress.Parse(myMaskString);
                    ip = IPAddress.Parse(myIPString);
                }
                else
                {
                    mask = IPAddress.Parse("255.255.255.255");
                    ip = Dns.Resolve(myMachineString).AddressList[0];
                }

                mySink.AddFilter(mask, ip);
            }
            Console.WriteLine("The Count of the ArrayList is  :"+ myArrayList.Count);
            Console.WriteLine("The values in the SinkProviderData collection are:");

            // Call the PrintValues function to enumerate and print values to the console.
            PrintValues( myArrayList );

            return mySink;
        }

        public IServerChannelSinkProvider Next
        {
            [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.Infrastructure)]
            get
            {
                return myIServerChannelSinkProviderNew;
            }
            [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.Infrastructure)]
            set
            {
                myIServerChannelSinkProviderNew = value;
            }
        }

        public FilterMode Mode
        {
            get
            {
                return (myAcceptMode ? FilterMode.Accept : FilterMode.Reject);
            }
            set
            {
                myAcceptMode = (value == FilterMode.Accept);
            }
        }

        public static void PrintValues( IEnumerable myList )
        {
            IEnumerator myEnumerator = myList.GetEnumerator();
            while ( myEnumerator.MoveNext() )
                Console.Write( "\t{0}", myEnumerator.Current );
            Console.WriteLine();
        }
    } // class MySinkProviderData