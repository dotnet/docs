// <Snippet2>

using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Lifetime;
using System.Timers;

namespace TimerSample {
    public class TimerServer {
        public static void Main() {

            BinaryServerFormatterSinkProvider serverProv = new BinaryServerFormatterSinkProvider();
            serverProv.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
            BinaryClientFormatterSinkProvider clientProv = new BinaryClientFormatterSinkProvider();

            IDictionary props = new Hashtable();
            props["port"] = 9000;
            HttpChannel channel = new HttpChannel(props, clientProv, serverProv);
            ChannelServices.RegisterChannel(channel);
            RemotingConfiguration.RegisterWellKnownServiceType(
    									typeof(TimerService), 
    									"MyService/TimerService.soap",
    									WellKnownObjectMode.Singleton);
            
            Console.WriteLine("Press enter to end the server process.");
            Console.ReadLine();
        }
    }
}

// </Snippet2>