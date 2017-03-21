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