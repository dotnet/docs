/* This is supporting program for the 'SoapClientFormatterSinkProvider_CreateSink_Client'.
 */
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Collections;

public class ServerClass
{
   public static void Main()
   {
      try
      {
         IDictionary myDictionaryProperty = new Hashtable();
         myDictionaryProperty.Add("port", 8082);
         IServerChannelSinkProvider mySoapProvider = 
                  new SoapServerFormatterSinkProvider();
         TcpChannel myTcpChannel =
         new TcpChannel(myDictionaryProperty, null, mySoapProvider );
         ChannelServices.RegisterChannel(myTcpChannel, false);
         RemotingConfiguration.ApplicationName = "HelloServiceApplication";
         RemotingConfiguration.RegisterWellKnownServiceType(typeof(HelloService),
                                    "MyUri",WellKnownObjectMode.Singleton);
         Console.WriteLine("Press enter to stop this process.");
         Console.ReadLine();
      }
      catch(Exception ex)
      {
         Console.WriteLine("The following exception is raised at server side"+ex.Message);
      }
   }
}
