// System.Runtime.Remoting.Channels.SinkProviderData
// System.Runtime.Remoting.Channels.SinkProviderData.Children
// System.Runtime.Remoting.Channels.SinkProviderData.Name
// System.Runtime.Remoting.Channels.SinkProviderData.Properties

/* The following program demonstrates the SinkProviderData class and its properties
   'Children', 'Name', 'Properties'.The IP filter sink may be set up to be in accept
   or reject mode. In accept mode, the sink will only accept requests from ip addresses
   that matches one of the filters. In reject mode, the sink will reject requests from
   any ip address that matches one of the filters. The properties of the SinkProviderData
   class are added to an ArrayList and their outputs are displayed onto the console.
*/
using System;
using System.IO;
using System.Collections;
using System.Net;
using System.Reflection;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;

namespace IPFilter
{
    // <Snippet1>
    // <Snippet2>
    // <Snippet3>
    // <Snippet4>
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
    // </Snippet4>
    // </Snippet3>
    // </Snippet2>
    // </Snippet1>

    public class MyIPFilterChannelSink : BaseChannelSinkWithProperties, IServerChannelSink
    {
        private IServerChannelSink myIServerChannelSink_newSink;

        private bool myBool_Accept;

        // List of filters to filter with.
        private ArrayList myFilterSet;

        private class MyFilter : IFilter
        {
            private int myNewMask;
            private int myNewIPAddress;

            private IPAddress myMaskObject;
            private IPAddress myIPAddressObject;

            public MyFilter(IPAddress mask, IPAddress ipAddress1)
            {
                myMaskObject = mask;
                myIPAddressObject = ipAddress1;

                myNewMask = (int) mask.Address;
                myNewIPAddress = (int) ipAddress1.Address;

                if ((~myNewMask & myNewIPAddress) != 0)
                {
                    throw new Exception("Unable to create filter: IP address (" +
                        ipAddress1.ToString() + ") cannot be more specific than mask (" +
                        mask.ToString() + ")");
                }
            }

            public bool MatchIPAddress(int ipToMatch)
            {
                return (myNewMask & ipToMatch) == myNewIPAddress;
            } // MatchIPAddress

            public IPAddress Mask { get { return myMaskObject; }
            }
            public IPAddress IP   { get { return myIPAddressObject; }
            }

        }

        [SecurityPermission(SecurityAction.Demand)]
        public MyIPFilterChannelSink(bool myAcceptMode, IServerChannelSink myIServerChannelSink_nextSink) : base()
        {
            myFilterSet = new ArrayList();
            myIServerChannelSink_newSink = myIServerChannelSink_nextSink;

            myBool_Accept = myAcceptMode;
        } // MyIPFilterChannelSink


        public void AddFilter(IPAddress mask, IPAddress ipAddress1)
        {
            MyFilter f = new MyFilter(mask, ipAddress1);
            myFilterSet.Add(f);
        }

        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.Infrastructure)]
        public ServerProcessing ProcessMessage(
            IServerChannelSinkStack sinkStack,
            IMessage requestMessage,
            ITransportHeaders requestHeaders, 
            Stream requestStream,
            out IMessage msg, 
            out ITransportHeaders responseHeaders,
            out Stream responseStream)
        {
            IPAddress ipAddress1 = (IPAddress)requestHeaders[CommonTransportKeys.IPAddress];
            Console.WriteLine(ipAddress1);

            bool accept = !MatchIPAddress(ipAddress1) ^ myBool_Accept;

            if (accept)
            {
                return myIServerChannelSink_newSink.ProcessMessage(sinkStack, null, requestHeaders, requestStream,
                    out msg, out responseHeaders, out responseStream);
            }
            else
            {
                responseHeaders = new TransportHeaders();
                responseHeaders["__HttpStatusCode"] = "403";
                responseHeaders["__HttpReasonPhrase"] = "Forbidden";
                Console.WriteLine("Reject.");

                msg = null;
                responseStream = null;

                return ServerProcessing.Complete;
            }
        } // ProcessMessage

        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.Infrastructure)]
        public void AsyncProcessResponse(IServerResponseChannelSinkStack sinkStack, Object state,
            IMessage msg, ITransportHeaders headers, Stream stream)
        {
        } // AsyncProcessResponse

        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.Infrastructure)]
        public Stream GetResponseStream(IServerResponseChannelSinkStack sinkStack, Object state,
            IMessage msg, ITransportHeaders headers)
        {
            return null;
        } // GetResponseStream


        public IServerChannelSink NextChannelSink
        {
            [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.Infrastructure)]
            get { return myIServerChannelSink_newSink; }
        }

        // Match ip address against all filters in the filter set.
        private bool MatchIPAddress(IPAddress ipAddr)
        {
            int ip = (int) ipAddr.Address;

            foreach (MyFilter f in myFilterSet)
            {
                if (f.MatchIPAddress(ip))
                    return true;
            }

            return false;
        } // MatchIPAddress

        public FilterMode Mode
        {
            get
            {
                return (myBool_Accept ? FilterMode.Accept : FilterMode.Reject);
            }
        }

        public ICollection Filters
        {
            get
            {
                return myFilterSet;
            }
        }

    } // class MyIPFilterChannelSink

    public enum FilterMode
    {
        Accept,
        Reject
    }

    public interface IFilter
    {
        IPAddress Mask { get; }
        IPAddress IP { get; }
    } // interface IFilter

} // namespace IPFilter
