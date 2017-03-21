   [AttributeUsage(AttributeTargets.Class)]
   [SecurityPermissionAttribute(SecurityAction.Demand, Flags=SecurityPermissionFlag.Infrastructure)]
   public class MyProxyAttribute : ProxyAttribute
   {
      public MyProxyAttribute()
      {
      }
      // Create an instance of ServicedComponentProxy
      public override MarshalByRefObject CreateInstance(Type serverType)
      {  
         return base.CreateInstance(serverType);
      }
      public override RealProxy CreateProxy(ObjRef objRef1,
         Type serverType,
         object serverObject,
         Context serverContext)
      {
         MyProxy myCustomProxy = new MyProxy(serverType);
         if(serverContext != null)
         {
            RealProxy.SetStubData(myCustomProxy,serverContext);
         }
         if((!serverType.IsMarshalByRef)&&(serverContext == null))
         {
            throw new RemotingException("Bad Type for CreateProxy");
         }
         return myCustomProxy;
      }
   }
   [PermissionSet(SecurityAction.Demand, Name="FullTrust")]
   [MyProxyAttribute]
   public class CustomServer :ContextBoundObject
   {
      public CustomServer()
      {
         Console.WriteLine("CustomServer Base Class constructor called");
      }
      public void HelloMethod(string str)
      {
         Console.WriteLine("HelloMethod of Server is invoked with message : " + str);
      }
   }