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
      public override ObjRef CreateObjRef(Type ServerType)
      {  
         Console.WriteLine ("CreateObjRef Method Called ..."); 
         CustomObjRef myObjRef = new CustomObjRef(myMarshalByRefObject,ServerType);
         myObjRef.URI = myUri ;
         return myObjRef;
      }
      [PermissionSet(SecurityAction.Demand, Name="FullTrust")]
      public override void GetObjectData( SerializationInfo info, 
                                          StreamingContext context)
      {
         // Add your custom data if any here.
         base.GetObjectData(info, context);
      }
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
         // Create an instance of MyProxy.
         MyProxy myProxyInstance = new MyProxy(typeof(CustomServer));
         // Get a CustomServer proxy.
         CustomServer myHelloServer = (CustomServer)myProxyInstance.GetTransparentProxy();
         // Get stubdata.
         Console.WriteLine("GetStubData = " + RealProxy.GetStubData(myProxyInstance).ToString()); 
         // Get ProxyType.
         Console.WriteLine("Type of object represented by RealProxy is :" 
                           + myProxyInstance.GetProxiedType());
         myHelloServer.HelloMethod("RealProxy Sample");
         Console.WriteLine("");
         // Get a reference object from server.
         Console.WriteLine("Create an objRef object to be marshalled across Application Domains...");
         ObjRef CustomObjRef = myProxyInstance.CreateObjRef(typeof(CustomServer));
         Console.WriteLine("URI of 'ObjRef' object =  " + CustomObjRef.URI);
      }
   }
}