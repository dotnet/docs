using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

public class ClientClass
{
static void Main()
{
   try
   {
      ChannelServices.RegisterChannel(new TcpChannel());
      RemotingConfiguration.RegisterActivatedClientType(typeof(MyServerImpl),"tcp://localhost:8085");
      MyServerImpl myObject = new MyServerImpl();
      for(int i=0;i<=4;i++)
         Console.WriteLine(myObject.MyMethod("invoke the server method "+(i+1)+" time"));
   }
   catch(Exception e)
   {
      Console.WriteLine(e.Message);
   }
}
}