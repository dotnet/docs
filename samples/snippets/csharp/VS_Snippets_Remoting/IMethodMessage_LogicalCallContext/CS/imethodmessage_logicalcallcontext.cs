// System.Runtime.Remoting.Messaging.IMethodMessage.LogicalCallContext
// System.Runtime.Remoting.Messaging.IMethodMessage.Uri

/*
   The program demonstrates the 'LogicalCallContext' and 'Uri' properties of 
   the IMethodMessage interface.
   In the program a remote object is created with a method by extending 'MarshalByRefObject'.
   A custom proxy is created by extending 'RealProxy' and overriding 'Invoke' 
   method of 'RealProxy'. In this example custom proxy is accessed by passing message 
   to the Invoke method. Then the values of 'Uri' and 'LogicalCallContext' properties
   are displayed to the console.
*/

using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;

[AttributeUsage(AttributeTargets.Class)]
public class MyProxyAttribute : ProxyAttribute
{
[SecurityPermission(SecurityAction.LinkDemand)]
   public MyProxyAttribute()
   {
   }

[SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags=SecurityPermissionFlag.Infrastructure)]
   public override MarshalByRefObject CreateInstance(Type serverType)
   {
      if (serverType.IsMarshalByRef)
      {
         MarshalByRefObject targetObject = 
            (MarshalByRefObject)Activator.CreateInstance(serverType);
         MyProxy proxy = new MyProxy(serverType, targetObject);
         return(MarshalByRefObject)proxy.GetTransparentProxy();
      }
      else
         throw new Exception("Proxies only work on MarshalByRefObject objects" + 
            " and their children");
   }
}

// MyProxy extends the CLR Remoting RealProxy.
// This demonstrate the RealProxy extensiblity.
// <Snippet1>
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


// <Snippet2>
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
// </Snippet2>
}

// </Snippet1>
public class Zip : MarshalByRefObject, ILogicalThreadAffinative
{
   public Zip()
   {
   }
   public int Method1(int i)
   {
      return i;
   }
}

public class ProxySample
{
   [SecurityPermission(SecurityAction.LinkDemand)]
   public static void Main()
   {
      MyProxy proxy = new MyProxy(typeof(Zip));
      Zip myZip = (Zip)proxy.GetTransparentProxy();
      CallContext.SetData("USER", new Zip());
      myZip.Method1(6);
   }
}