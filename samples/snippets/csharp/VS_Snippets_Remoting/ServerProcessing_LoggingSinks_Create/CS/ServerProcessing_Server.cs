/* This file is a support file for demonstrating IClientChannelSinkProvider 
and ServerProcessing. */

using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Security.Permissions;
using System.Collections;
using MyLogging;

public class MyServerClass 
{
   [SecurityPermission(SecurityAction.LinkDemand)]
   public static void Main()  
   {
      IDictionary prop = new Hashtable();      
      prop.Add("port", 8082);

      IServerChannelSinkProvider myServerFormatterProvider = new SoapServerFormatterSinkProvider();
      IServerChannelSinkProvider myServerLoggingProvider = 
            new MyServerProcessingLogServerChannelSinkProviderData();
      myServerLoggingProvider.Next = myServerFormatterProvider;

      IClientChannelSinkProvider myClientFormatterProvider = new SoapClientFormatterSinkProvider();
      IClientChannelSinkProvider myClientLoggingProvider = 
            new MyServerProcessingLogClientChannelSinkProviderData();
      myClientLoggingProvider.Next = myClientFormatterProvider;
      
      TcpChannel channel = new TcpChannel(prop, myClientLoggingProvider, myServerLoggingProvider);

      ChannelServices.RegisterChannel(channel);

      RemotingConfiguration.ApplicationName = "HelloServiceApplication";

      RemotingConfiguration.RegisterWellKnownServiceType( typeof(MyHelloService),
                                                           "MyUri", WellKnownObjectMode.SingleCall);
      Console.WriteLine("Press enter to stop this process.");
      Console.ReadLine();
   }
}
