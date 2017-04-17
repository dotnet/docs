// System.Runtime.Remoting.Channels.SoapServerFormatterSinkProvider.Next;

using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Security.Permissions;
using System.Collections;

public class ServerClass
{
[SecurityPermission(SecurityAction.Demand)]
   public static void Main()
   {
      try
      {
         IDictionary myDictionaryProperty = new Hashtable();
         myDictionaryProperty.Add("port", 8082);
// <Snippet4>
         IServerChannelSinkProvider myCustomProvider = new MyServerProvider();
         IServerChannelSinkProvider mySoapProvider =
            new SoapServerFormatterSinkProvider();
         myCustomProvider.Next = mySoapProvider;
         // Set the Binary provider as the next 'IServerChannelSinkProvider' in the
         // sink chain.
         mySoapProvider.Next =  new BinaryServerFormatterSinkProvider();
// </Snippet4>
         TcpChannel myTcpChannel =
            new TcpChannel(myDictionaryProperty, null, myCustomProvider);

         ChannelServices.RegisterChannel(myTcpChannel);

         RemotingConfiguration.ApplicationName = "HelloServiceApplication";

         RemotingConfiguration.RegisterWellKnownServiceType( typeof(HelloService),
            "MyUri",WellKnownObjectMode.Singleton);
         Console.WriteLine("Press enter to stop this process.");
         Console.ReadLine();
      }
      catch(Exception ex)
      {
         Console.WriteLine("The following exception is raised at server side: " + ex.Message);
      }
   }
}
