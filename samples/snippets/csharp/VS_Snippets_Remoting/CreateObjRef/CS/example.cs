// <Snippet2>
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.Security.Permissions;

public class ObjRefExample  {
   [PermissionSet(SecurityAction.LinkDemand)]
   public static void Main() {

      ChannelServices.RegisterChannel(new HttpChannel(8090));

      RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteObject), 
                                                         "RemoteObject", 
                                                         WellKnownObjectMode.Singleton);

      RemoteObject RObj = 
         (RemoteObject)Activator.GetObject(typeof(RemoteObject), 
                                           "http://localhost:8090/RemoteObject");
      
      LocalObject  LObj = new LocalObject();
      
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
// </Snippet2>



// <Snippet1>
// a custom ObjRef class that outputs its status
[PermissionSet(SecurityAction.Demand, Name="FullTrust")]
public class MyObjRef : ObjRef {
   
   // only instantiate via marshaling or deserialization
   private MyObjRef() { }

   public MyObjRef(MarshalByRefObject o, Type t) : base(o, t) {
      Console.WriteLine("Created MyObjRef.");
      ORDump();
   }

   public MyObjRef(SerializationInfo i, StreamingContext c) : base(i, c) {
      Console.WriteLine("Deserialized MyObjRef.");
   }

   public override void GetObjectData(SerializationInfo s, StreamingContext c) {
      // After calling the base method, change the type from ObjRef to MyObjRef
      base.GetObjectData(s, c);
      s.SetType(GetType());
      Console.WriteLine("Serialized MyObjRef.");
   }

   public override Object GetRealObject(StreamingContext context) {

      if ( IsFromThisAppDomain() || IsFromThisProcess() )  {
         Console.WriteLine("Returning actual object referenced by MyObjRef.");
         return base.GetRealObject(context);
      }
      else {
         Console.WriteLine("Returning proxy to remote object.");
         return RemotingServices.Unmarshal(this);
      }
   }   

   public void ORDump() {

      Console.WriteLine(" --- Reporting MyObjRef Info --- ");
      Console.WriteLine("Reference to {0}.", TypeInfo.TypeName);
      Console.WriteLine("URI is {0}.", URI);

      Console.WriteLine("\nWriting EnvoyInfo: ");
      
      if ( EnvoyInfo != null) {

         IMessageSink EISinks = EnvoyInfo.EnvoySinks;

         while (EISinks != null) {
            Console.WriteLine("\tSink: " + EISinks.ToString());  
            EISinks = EISinks.NextSink;
         }
      }
      else
         Console.WriteLine("\t {no sinks}");

      Console.WriteLine("\nWriting ChannelInfo: ");
      for (int i = 0; i < ChannelInfo.ChannelData.Length; i++)
         Console.WriteLine ("\tChannel: {0}", ChannelInfo.ChannelData[i]);
      
      Console.WriteLine(" ----------------------------- ");
   }
}

// a class that uses MyObjRef
[PermissionSet(SecurityAction.Demand, Name="FullTrust")]
public class LocalObject : MarshalByRefObject  {

   // overriding CreateObjRef will allow us to return a custom ObjRef
   public override ObjRef CreateObjRef(Type t) {

      return new MyObjRef(this, t);
   }
}
// </Snippet1>

