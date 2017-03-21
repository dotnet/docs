using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.Security.Permissions;

public class ObjRefExample {

   [PermissionSet(SecurityAction.LinkDemand)]
   public static void Main() {

      ChannelServices.RegisterChannel(new HttpChannel(8090));

      WellKnownServiceTypeEntry wkste = 
         new WellKnownServiceTypeEntry(typeof(RemoteObject), 
                                       "RemoteObject", 
                                       WellKnownObjectMode.Singleton);
      
      RemotingConfiguration.RegisterWellKnownServiceType( wkste );

      RemoteObject RObj = 
         (RemoteObject)Activator.GetObject(typeof(RemoteObject), 
                                           "http://localhost:8090/RemoteObject");

      LocalObject LObj = new LocalObject();
      
      RObj.Method1( LObj );

      Console.WriteLine("Press Return to exit...");
      Console.ReadLine();
   }
}

[PermissionSet(SecurityAction.Demand, Name="FullTrust")] 
public class RemoteObject : MarshalByRefObject {

   public void Method1(LocalObject param) {
      Console.WriteLine("Invoked: Method1({0})", param);
   }
}