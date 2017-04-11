//NCLPingSync
//<snippet1>
using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace Examples.System.Net.NetworkInformation.PingTest
{
    public class PingExample
    {
        // args[0] can be an IPaddress or host name.
        public static void Main (string[] args)
        {
            //<snippet3>
            //<snippet2>
            Ping pingSender = new Ping ();
            PingOptions options = new PingOptions ();

            // Use the default Ttl value which is 128,
            // but change the fragmentation behavior.
            options.DontFragment = true;

            //</snippet2>
            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes (data);
            int timeout = 120;
            PingReply reply = pingSender.Send (args[0], timeout, buffer, options);
            //</snippet3>
            //<snippet4>
            if (reply.Status == IPStatus.Success)
            {
                Console.WriteLine ("Address: {0}", reply.Address.ToString ());
                Console.WriteLine ("RoundTrip time: {0}", reply.RoundtripTime);
                Console.WriteLine ("Time to live: {0}", reply.Options.Ttl);
                Console.WriteLine ("Don't fragment: {0}", reply.Options.DontFragment);
                Console.WriteLine ("Buffer size: {0}", reply.Buffer.Length);
            }
            //</snippet4>
        }
    }
}
//</snippet1>

