using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Services;
using System.Security.Permissions;

public class ServerProcess
{
   [PermissionSet(SecurityAction.LinkDemand)]
   public static void Main()
   {

      TcpChannel myChannel = new TcpChannel(8085);
      ChannelServices.RegisterChannel(myChannel);

      MyServiceClass myService  = new MyServiceClass();

      // After the channel is registered, register the object
      // with remoting infrastructure by calling Marshal method.
      ObjRef myObjRef = RemotingServices.Marshal(myService,"TcpService");

      // Get the information contributed by active channel.
      IChannelInfo myChannelInfo = myObjRef.ChannelInfo;
      IChannelDataStore myIChannelData;
      foreach(object myChannelData in myChannelInfo.ChannelData)
      {
         if(myChannelData is IChannelDataStore)
         {
            myIChannelData = (IChannelDataStore)myChannelData;
            foreach(string myUri in myIChannelData.ChannelUris)
               Console.WriteLine("Channel Uris are -> " + myUri);
            // Add custom data.
            string myKey = "Key1";
            myIChannelData[myKey] = "My Data";
            Console.WriteLine(myIChannelData[myKey].ToString());
         }
      }

   }
}

// Marshal ByRef Object class.
public class MyServiceClass : MarshalByRefObject
{
   public string HelloWorld()
   {
      return "Hello World";
   }
}