   public class MyProxy : RealProxy
   {

   String stringUri;
   MarshalByRefObject targetObject;

[SecurityPermission(SecurityAction.LinkDemand)]
public MyProxy(Type type) : base(type)
{
      targetObject = (MarshalByRefObject)Activator.CreateInstance(type);
      ObjRef myObject = RemotingServices.Marshal(targetObject);
      stringUri = myObject.URI;
   }

   [SecurityPermission(SecurityAction.LinkDemand)]
   public MyProxy(Type type, MarshalByRefObject targetObject) : base(type)
   {
      this.targetObject = targetObject;
   }


[SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags=SecurityPermissionFlag.Infrastructure)]
   public override IMessage Invoke(IMessage message)
   {
      message.Properties["__Uri"] = stringUri;
      IMethodMessage myMethodMessage = 
         (IMethodMessage)ChannelServices.SyncDispatchMessage(message);

      Console.WriteLine("---------IMethodMessage example-------");
      Console.WriteLine("Method name : " + myMethodMessage.MethodName);
      Console.WriteLine("LogicalCallContext has information : " +
         myMethodMessage.LogicalCallContext.HasInfo);
      Console.WriteLine("Uri : " + myMethodMessage.Uri);

      return myMethodMessage;
   }
}
