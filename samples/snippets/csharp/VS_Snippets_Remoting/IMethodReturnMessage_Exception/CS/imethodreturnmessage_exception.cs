// System.Runtime.Remoting.Messaging.IMethodReturnMessage.Exception

/*
   The following example demonstrates 'Exception' property of 'IMethodReturnMessage'interface.
   A 'CustomServer' class is defined extending 'MarshalByRefObject'. A custom proxy
   is created by extending 'RealProxy' and overriding 'Invoke' method of 'RealProxy'.
   The Invoke method calls the methods and properties of 'IMethodMessage' interface
   and display the 'Exception' property value of 'IMethodReturnMessage' interface to
   the console.
*/

using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;

namespace CustomProxySample
{
   public class CustomServer : MarshalByRefObject
   {
      public void RaiseException()
      {
         throw new Exception("Raising an exception.");
      }
   }

   [PermissionSet(SecurityAction.Demand, Name="FullTrust")]
   public class MyProxy : RealProxy
   {
      String _URI;
      MarshalByRefObject myMarshalByRefObject;
      public MyProxy(Type myType): base(myType)
      {
         myMarshalByRefObject = (MarshalByRefObject)Activator.CreateInstance(myType);
         ObjRef myObjRef = RemotingServices.Marshal(myMarshalByRefObject);
         _URI = myObjRef.URI;
      }

// <Snippet1>
      public override IMessage Invoke(IMessage myMessage)
      {
         IMethodCallMessage myCallMessage = (IMethodCallMessage)myMessage;

         IMethodReturnMessage myIMethodReturnMessage =
            RemotingServices.ExecuteMessage(myMarshalByRefObject,myCallMessage);
         if(myIMethodReturnMessage.Exception != null)
            Console.WriteLine(myIMethodReturnMessage.MethodName +
               " raised an exception.");
         else
            Console.WriteLine(myIMethodReturnMessage.MethodName +
               " does not raised an exception.");

         return myIMethodReturnMessage;
      }
// </Snippet1>
   }

   public class ProxySample
   {
      [SecurityPermission(SecurityAction.LinkDemand)]
      public static void Main()
      {
         // Create an instance of MyProxy.
         MyProxy myCustomProxy = new MyProxy(typeof(CustomServer));
         // Get an instance of remote class.
         CustomServer myHelloServer = (CustomServer)myCustomProxy.GetTransparentProxy();
         try
         {
            // Invoke remote method.
            myHelloServer.RaiseException();
         }
         catch(Exception e)
         {
            Console.WriteLine("Exception: " + e.Message);
         }
      }
   }
}
