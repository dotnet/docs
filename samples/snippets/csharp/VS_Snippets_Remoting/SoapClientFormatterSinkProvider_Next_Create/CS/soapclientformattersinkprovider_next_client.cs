// System.Runtime.Remoting.Channels.SoapClientFormatterSinkProvider
// System.Runtime.Remoting.Channels.SoapClientFormatterSinkProvider.Next

/*
   The following program demonstrates the 'SoapClientFormatterSinkProvider' class
   and 'Next' property of 'SoapClientFormatterSinkProvider' class ,'CreateSink'
   method and 'Next' property of 'ServerFormatterSinkProvider' class.
   Custom client and server formatter provider are created by implementing
   the interfaces IClientChannelSinkProvider and IServerChannelSinkProvider.
   In the client side the custom client provider is assigned to 'Next' property
   of 'SoapClientFormatterSinkProvider'. In the server side, the
   'BinaryServerFormatterSinkProvider' is assigned to 'Next' property of
   'SoapServerFormatterSinkProvider'. The 'CreateSink' method is used to return a
   sink to the caller and form the sink chain which is used to process the message
   being passed through it.
*/
// <Snippet1>
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Security.Permissions;

public class ClientClass
{
[SecurityPermission(SecurityAction.Demand)]
   public static void Main()
   {
      try
      {
// <Snippet2>
      IClientChannelSinkProvider mySoapProvider =
                                 new SoapClientFormatterSinkProvider();
      IClientChannelSinkProvider myClientProvider = new MyClientProvider();
      // Set the custom provider as the next 'IClientChannelSinkProvider' in the sink chain.
      mySoapProvider.Next = myClientProvider;
// </Snippet2>
      TcpChannel myTcpChannel = new TcpChannel(null, mySoapProvider, null);

      ChannelServices.RegisterChannel(myTcpChannel);

      RemotingConfiguration.RegisterWellKnownClientType(typeof(HelloService),
                                 "tcp://localhost:8082/HelloServiceApplication/MyUri");

      HelloService myService = new HelloService();

      Console.WriteLine(myService.HelloMethod("Welcome to .Net"));
      }
      catch(Exception ex)
      {
         Console.WriteLine("The following  exception is raised at client side :"+ex.Message);
      }
   }
}
// </Snippet1>
