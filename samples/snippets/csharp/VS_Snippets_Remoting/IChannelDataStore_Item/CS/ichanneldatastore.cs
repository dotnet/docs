// System.Runtime.Remoting.Channels.IChannelDataStore
// System.Runtime.Remoting.Channels.IChannelDataStore.ChannelUris
// System.Runtime.Remoting.Channels.IChannelDataStore.Item[object]

/* The following example demonstrates 'ChannelUris', 'Item' and 'IChannelDataStore'
   class.
   In the example after registering the channel, the object is registered with remoting
   infrastructure by calling 'RemotingServices.Marshal' method. After registering the
   object the channel information is obtained. From the channel information the required
   'IChannelInfo' is collected and displayed.
*/


// <Snippet1>
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
// <Snippet2>
// <Snippet3>

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

// </Snippet3>
// </Snippet2>
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
// </Snippet1>