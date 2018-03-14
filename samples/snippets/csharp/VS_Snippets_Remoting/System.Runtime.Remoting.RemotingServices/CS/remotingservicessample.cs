// C:\Program Files\Microsoft.NET\FrameworkSDK\Samples\technologies\remoting\advanced\customproxies

//<snippet1>
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Channels;
using System.Reflection;
//</snippet1>

//<snippet4>
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Lifetime;
using System.Runtime.Remoting.Proxies;
//</snippet4>

//<snippet5>
using System.Runtime.Remoting.Channels.Http;
using System.Net;
using System.IO;
//</snippet5>

using System.Security.Permissions;

//<snippet6>
// An instance of ClientApp will call an instance of this class remotely.

public class TcpServerApp {
[SecurityPermission(SecurityAction.Demand)]
   public TcpServerApp()
   {
      // Register a class over TCP at tcp://localhost:8085/HttpHelloServer.

      const string myObjectUri = "TcpHelloServer";
      const int myPort = 8085;

      TcpChannel myTcpChannel = new TcpChannel(myPort);
      ChannelServices.RegisterChannel(myTcpChannel);

      RemotingConfiguration.RegisterWellKnownServiceType(
         typeof(HelloServer),
         myObjectUri,
         WellKnownObjectMode.Singleton
      );
      //</snippet6>

      //<snippet7>
      Console.WriteLine("Server type: {0}",
                        RemotingServices.GetServerTypeForUri(myObjectUri));
      //</snippet7>

//<snippet8>
      Console.WriteLine("Press Enter to stop the demo.");
      Console.ReadLine();
   }
}
//</snippet8>

//<snippet9>
public class HttpServerApp {
[SecurityPermission(SecurityAction.Demand)]
   public HttpServerApp() {
      // Marshal an object over HTTP at http://localhost:8090/HttpHelloServer.

      const string myObjectUri = "HttpHelloServer";
      const int myPort = 8090;

      HttpChannel myHttpChannel = new HttpChannel(myPort);
      ChannelServices.RegisterChannel(myHttpChannel);

      MarshalByRefObject myMbro = (MarshalByRefObject)Activator.CreateInstance(typeof(HelloServer));
      RemotingServices.SetObjectUriForMarshal(myMbro, myObjectUri);
      ObjRef myObjRef = RemotingServices.Marshal(myMbro);

      Console.WriteLine("Press Enter to stop the demo.");
      Console.ReadLine();

      HelloServer umObj = (HelloServer)RemotingServices.Unmarshal(myObjRef);
      RemotingServices.Disconnect(myMbro);
   }
}
//</snippet9>

//<snippet2>
public class HelloServer : MarshalByRefObject {

   public HelloServer() {
      Console.WriteLine("HelloServer activated.");
   }

   [OneWay()]
   public void SayHelloToServer(string name) {
      Console.WriteLine("Client invoked SayHelloToServer(\"{0}\").", name);
   }   

[SecurityPermission(SecurityAction.Demand)]
   //<snippet3> 
   // IsOneWay
   // Note the lack of the OneWayAttribute adornment on this method.
   public string SayHelloToServerAndWait(string name) {
      Console.WriteLine("Client invoked SayHelloToServerAndWait(\"{0}\").", name);

      Console.WriteLine(
         "Client waiting for return? {0}",
         RemotingServices.IsOneWay(MethodBase.GetCurrentMethod()) ? "No" : "Yes"
      );

      return "Hi there, " + name + ".";
   }
   //</snippet3>
}
//</snippet2>

//<snippet11>
// An instance of this class will call an instance of ServerApp remotely.

public class TcpClientApp {
[SecurityPermission(SecurityAction.Demand)]
   public TcpClientApp() {
      const string myHelloServerUrl = "tcp://localhost:8085/TcpHelloServer";

      HelloServer obj = (HelloServer)RemotingServices.Connect(
         typeof(HelloServer),
         myHelloServerUrl
      );
//</snippet11>


      //<snippet18> 
      // GetRealProxy, GetObjectUri, GetEnvoyChainForProxy
      RealProxy proxy = RemotingServices.GetRealProxy(obj);
      Console.WriteLine("Real proxy type: {0}", proxy.GetProxiedType().ToString());

      Console.WriteLine("Object URI: {0}", RemotingServices.GetObjectUri(obj).ToString());

      IMessageSink  msgSink = RemotingServices.GetEnvoyChainForProxy(obj).NextSink;
      //</snippet18>



      //<snippet12> 
      //IsTransparentProxy, IsObjectOutOfAppDomain, IsObjectOutOfContext
      Console.WriteLine("Proxy transparent? {0}",
         RemotingServices.IsTransparentProxy(obj) ? "Yes" : "No"
      );

      Console.WriteLine("Object outside app domain? {0}",
         RemotingServices.IsObjectOutOfAppDomain(obj) ? "Yes" : "No"
      );

      Console.WriteLine("Object out of context? {0}",
         RemotingServices.IsObjectOutOfContext(obj) ? "Yes" : "No"
         );
      //</snippet12>

      //<snippet21> 
      // GetLifetimeService
      ILease lease = (ILease)RemotingServices.GetLifetimeService(obj);
      Console.WriteLine("Object lease time remaining: {0}.",
         lease.CurrentLeaseTime.ToString()
         );
      //</snippet21>

      //<snippet16>
      string twoWayMethodArg = "John";

      Console.WriteLine("Invoking SayHelloToServerAndWait(\"{0}\").", twoWayMethodArg);
      Console.WriteLine("Server returned: {0}", obj.SayHelloToServerAndWait(twoWayMethodArg));
      //</snippet16>
      
      //<snippet17>
      string oneWayMethodArg = "Mary";

      Console.WriteLine("Invoking SayHelloToServer(\"{0}\").", oneWayMethodArg);
      obj.SayHelloToServer(oneWayMethodArg);
      //</snippet17>

   //<snippet23>
   }
   //</snippet23>

//<snippet13>
}
//</snippet13>

//<snippet22>
public class HttpClientApp {
   public HttpClientApp() {
      const string myHelloServerUrl = "http://localhost:8090/HttpHelloServer";

      // Output the WSDL for the marshalled object.

      WebClient myWebClient = new WebClient();
      Stream myStream = myWebClient.OpenRead(myHelloServerUrl + "?wsdl");
      
      int b = myStream.ReadByte();
      while (b != -1) {
         Console.Write((char)b);
         b = myStream.ReadByte();
      }
   }
}
//</snippet22>

//<snippet14>
class EntryPoint {
   static void Main(string[] args) {
      //</snippet14>

      if (args.Length == 0 || args[0].ToLower() != "s" ) {
         Console.WriteLine("Run this program in another window,\npassing the letter 's' as an argument.\nPress Enter here when the server has been activated.");
         Console.ReadLine();
         Console.WriteLine("Running TCP client.");
      }

      //<snippet19>
      if (args.Length > 0 && args[0].ToLower() == "s" ) {
         new TcpServerApp();
      }
      else {
         new TcpClientApp();
      }
      //</snippet19>

      if (args.Length == 0 || args[0].ToLower() != "s" ) {
         Console.WriteLine("\nPress Enter in the other window to continue to the next demo.\nThen press Enter here.");
         Console.ReadLine();
      }

      //<snippet20>
      if (args.Length > 0 && args[0].ToLower() == "s" ) {
         new HttpServerApp();
      }
      else {
         new HttpClientApp();
      }
      //</snippet20>

      //<snippet15>
   }
}
//</snippet15>