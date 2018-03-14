// System.Runtime.Remoting.Proxies.ProxyAttribute.CreateInstance;
// System.Runtime.Remoting.Proxies.ProxyAttribute.CreateProxy;
// System.Runtime.Remoting.Proxies.RealProxy.SetStubData;
// System.Runtime.Remoting.Proxies.RealProxy.Invoke;
// System.Runtime.Remoting.Proxies.RealProxy.InitializeServerObject;
// System.Runtime.Remoting.Proxies.RealProxy.CreateObjRef;
// System.Runtime.Remoting.Proxies.RealProxy.GetObjectData;
// System.Runtime.Remoting.Proxies.RealProxy.GetTransparentProxy;
// System.Runtime.Remoting.Proxies.RealProxy.GetStubData;
// System.Runtime.Remoting.Proxies.RealProxy.GetProxiedType;
// System.Runtime.Remoting.Proxies.ProxyAttribute;
// System.Runtime.Remoting.Proxies.RealProxy;

/* The following example demonstrates implementation of methods
   'CreateInstance' and 'CreateProxy' of System.Runtime.Remoting.Proxies.ProxyAttribute and methods
   'SetStubData', 'Invoke', 'InitializeServerObject', 'CreateObjRef', 'GetStubData', 'GetObjectData',
   'GetTransparentProxy', 'GetProxiedType' of System.Runtime.Remoting.Proxies.RealProxy.
   
   The following program has derived from'ProxyAttribute','RealProxy' classes. CustomProxy is implemented by deriving 
   from 'RealProxy' and overriding 'Invoke' method. The new statement for 'CustomServer' class is intercepted to
   derived 'CustomProxyAttribute' by setting 'ProxyAttribute' on the CustomServer class. Implementation of
   'RealProxy' and 'ProxyAttribute' methods are shown.
*/

// <Snippet12>
using System;
using System.Collections;
using System.Runtime.Serialization;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Contexts; 
using System.Security.Permissions;

namespace Samples
{
// <Snippet11>
   [AttributeUsage(AttributeTargets.Class)]
   [SecurityPermissionAttribute(SecurityAction.Demand, Flags=SecurityPermissionFlag.Infrastructure)]
   public class MyProxyAttribute : ProxyAttribute
   {
      public MyProxyAttribute()
      {
      }
// <Snippet1>
      // Create an instance of ServicedComponentProxy
      public override MarshalByRefObject CreateInstance(Type serverType)
      {  
         return base.CreateInstance(serverType);
      }
// </Snippet1>
// <Snippet2>
// <Snippet3>
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
// </Snippet3>
// </Snippet2>
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
// </Snippet11>
   [PermissionSet(SecurityAction.Demand, Name="FullTrust")]
   public class MyProxy : RealProxy
   {
      String myUri;
      MarshalByRefObject myMarshalByRefObject;
      public MyProxy(): base()
      {
         Console.WriteLine("MyProxy Constructor Called...");
         myMarshalByRefObject = (MarshalByRefObject)Activator.CreateInstance(typeof(CustomServer));
         ObjRef myObjRef = RemotingServices.Marshal(myMarshalByRefObject);
         myUri = myObjRef.URI;
      }
      public MyProxy(Type type1): base(type1)
      {
         Console.WriteLine("MyProxy Constructor Called...");
         myMarshalByRefObject = (MarshalByRefObject)Activator.CreateInstance(type1);
         ObjRef myObjRef = RemotingServices.Marshal(myMarshalByRefObject);
         myUri = myObjRef.URI;
      }
      public MyProxy(Type type1, MarshalByRefObject targetObject) : base(type1)
      {
         Console.WriteLine("MyProxy Constructor Called...");
         myMarshalByRefObject = targetObject;
         ObjRef myObjRef = RemotingServices.Marshal(myMarshalByRefObject);
         myUri = myObjRef.URI;
      }
// <Snippet4>
// <Snippet5>
      public override IMessage Invoke(IMessage myMessage)
      {
         Console.WriteLine("MyProxy 'Invoke method' Called...");
         if (myMessage is IMethodCallMessage)
         {
            Console.WriteLine("IMethodCallMessage");
         }
         if (myMessage is IMethodReturnMessage)
         {
            Console.WriteLine("IMethodReturnMessage");
         }
         if (myMessage is IConstructionCallMessage)
         {  
            // Initialize a new instance of remote object
            IConstructionReturnMessage myIConstructionReturnMessage = 
               this.InitializeServerObject((IConstructionCallMessage)myMessage);
            ConstructionResponse constructionResponse = new 
               ConstructionResponse(null,(IMethodCallMessage) myMessage);
            return constructionResponse;
         }
         IDictionary myIDictionary = myMessage.Properties;
         IMessage returnMessage;
         myIDictionary["__Uri"] = myUri;

         // Synchronously dispatch messages to server.
         returnMessage = ChannelServices.SyncDispatchMessage(myMessage);
         // Pushing return value and OUT parameters back onto stack.
         IMethodReturnMessage myMethodReturnMessage = (IMethodReturnMessage)returnMessage;
         return returnMessage;
      }
// </Snippet5>
// </Snippet4>
// <Snippet6>
      public override ObjRef CreateObjRef(Type ServerType)
      {  
         Console.WriteLine ("CreateObjRef Method Called ..."); 
         CustomObjRef myObjRef = new CustomObjRef(myMarshalByRefObject,ServerType);
         myObjRef.URI = myUri ;
         return myObjRef;
      }
// </Snippet6>
// <Snippet7>
      [PermissionSet(SecurityAction.Demand, Name="FullTrust")]
      public override void GetObjectData( SerializationInfo info, 
                                          StreamingContext context)
      {
         // Add your custom data if any here.
         base.GetObjectData(info, context);
      }
// </Snippet7>
      [PermissionSet(SecurityAction.Demand, Name="FullTrust")]
      public class CustomObjRef :ObjRef
      {
         public CustomObjRef(MarshalByRefObject myMarshalByRefObject,Type serverType): 
                           base(myMarshalByRefObject,serverType)
         {  
            Console.WriteLine("ObjRef 'Constructor' called");
         }
         // Override this method to store custom data.
         [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter=true)]
         public override void GetObjectData(SerializationInfo info,
                                            StreamingContext context)
         {
            base.GetObjectData(info,context);
         }
      }
   }      
   public class ProxySample
   {
      // Acts as a custom proxy user.
      [PermissionSet(SecurityAction.LinkDemand)]
      public static void Main()
      {  
         Console.WriteLine("");
         Console.WriteLine("CustomProxy Sample");
         Console.WriteLine("================");
         Console.WriteLine("");
// <Snippet8>
// <Snippet9>
// <Snippet10>
         // Create an instance of MyProxy.
         MyProxy myProxyInstance = new MyProxy(typeof(CustomServer));
         // Get a CustomServer proxy.
         CustomServer myHelloServer = (CustomServer)myProxyInstance.GetTransparentProxy();
// </Snippet10>
         // Get stubdata.
         Console.WriteLine("GetStubData = " + RealProxy.GetStubData(myProxyInstance).ToString()); 
// </Snippet9>
         // Get ProxyType.
         Console.WriteLine("Type of object represented by RealProxy is :" 
                           + myProxyInstance.GetProxiedType());
// </Snippet8>
         myHelloServer.HelloMethod("RealProxy Sample");
         Console.WriteLine("");
         // Get a reference object from server.
         Console.WriteLine("Create an objRef object to be marshalled across Application Domains...");
         ObjRef CustomObjRef = myProxyInstance.CreateObjRef(typeof(CustomServer));
         Console.WriteLine("URI of 'ObjRef' object =  " + CustomObjRef.URI);
      }
   }
}
// </Snippet12>
