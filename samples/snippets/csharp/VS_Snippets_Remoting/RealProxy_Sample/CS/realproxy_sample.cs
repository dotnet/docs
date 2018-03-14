// System.Runtime.Remoting.Proxies.RealProxy.SupportsInterface(Guid);
// System.Runtime.Remoting.Proxies.RealProxy.GetCOMIUnknown(bool);
// System.Runtime.Remoting.Proxies.RealProxy.SetCOMIUnknown(IntPtr);
/* The following example demonstrates implementation of methods
   'GetCOMIUnknown','SupportsInterface' and 'SetCOMIUnknown' of 
   System.Runtime.Remoting.Proxies.RealProxy.
   
   The following program has a 'CustomProxy' referring to unmanaged COM component.
   A COM Runtime Wrapper takes care of method call to unmanaged world. SupportsInterface
   method is overridden to return address of COM Runtime Wrapper.
*/

using System;
using System.Collections;
using System.Runtime.Serialization;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Contexts; 
using System.Security.Permissions;
using System.Runtime.InteropServices;
using ActiveDs;

namespace CustomProxySample
{
   public class MyProxy : RealProxy
   {
      String m_URI;
      MarshalByRefObject myMarshalByRefObject;
      [SecurityPermission(SecurityAction.LinkDemand)]
      public MyProxy(): base()
      {
         Console.WriteLine("MyProxy Constructor Called...");
         myMarshalByRefObject = (MarshalByRefObject)Activator.CreateInstance(typeof(WinNTSystemInfo));
         ObjRef myObjRef = RemotingServices.Marshal(myMarshalByRefObject);
         m_URI = myObjRef.URI;
      }
      [SecurityPermission(SecurityAction.LinkDemand)]
      public MyProxy(Type myType): base(myType)
      {
         Console.WriteLine("MyProxy Constructor Called...");
         myMarshalByRefObject = (MarshalByRefObject)Activator.CreateInstance(myType);
         ObjRef myObjRef = RemotingServices.Marshal(myMarshalByRefObject);
         m_URI = myObjRef.URI;
      }
      [SecurityPermission(SecurityAction.LinkDemand)]
      public MyProxy(Type myType, MarshalByRefObject targetObject) : base(myType)
      {
         Console.WriteLine("MyProxy Constructor Called...");
         myMarshalByRefObject = targetObject;
         ObjRef myObjRef = RemotingServices.Marshal(myMarshalByRefObject);
         m_URI = myObjRef.URI;
      }
      [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
      public override IMessage Invoke(IMessage msg)
      {
         if (msg is IConstructionCallMessage)
         {  
            // Initialize a new instance of remote object
            IConstructionReturnMessage myIConstructionReturnMessage = 
               this.InitializeServerObject((IConstructionCallMessage)msg);
            ConstructionResponse constructionResponse = new 
               ConstructionResponse(null,(IMethodCallMessage) msg);
            return constructionResponse;
         }
         IDictionary myIDictionary = msg.Properties;
         IMessage retMsg;
         myIDictionary["__Uri"] = m_URI;

         // Synchronously dispatch messages to server.
         retMsg = ChannelServices.SyncDispatchMessage(msg);
         // Pushing return value and OUT parameters back onto stack
         IMethodReturnMessage mrm = (IMethodReturnMessage)retMsg;
         return retMsg;
      }
// <Snippet1>
// <Snippet2>
// <Snippet3>
      [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
      public override IntPtr SupportsInterface(ref Guid myGuid)
      {
         Console.WriteLine("SupportsInterface method called");
         // Object reference is requested for communication with unmanaged objects
         // in the current process through COM.
         IntPtr myIntPtr = this.GetCOMIUnknown(false);
         // Stores an unmanaged proxy of the object.
         this.SetCOMIUnknown(myIntPtr);
         // return COM Runtime Wrapper pointer.
         return myIntPtr;
      }
// </Snippet3>
// </Snippet2>
// </Snippet1>
   }      
   public class ProxySample
   {
      // Acts as a custom proxy user.
      [SecurityPermission(SecurityAction.LinkDemand)]
      public static void Main()
      {  
         Console.WriteLine("");
         Console.WriteLine("CustomProxy Sample");
         Console.WriteLine("==================");
         MyProxy mProxy = new MyProxy(typeof(WinNTSystemInfo));
         WinNTSystemInfo myHelloServer = (WinNTSystemInfo)mProxy.GetTransparentProxy();
         Console.WriteLine("Machine Name = " + myHelloServer.ComputerName);  
         Console.WriteLine("Domain Name = " + myHelloServer.DomainName);  
         Console.WriteLine("User Name = " + myHelloServer.UserName);  
         // Construct Guid object from unmanaged Interface 'IADsWinNTSystemInfo' guid.
         Guid myGuid = new Guid("{6C6D65DC-AFD1-11D2-9CB9-0000F87A369E}");
         IntPtr myIntrPtr = mProxy.SupportsInterface(ref myGuid);
         Console.WriteLine("Requested Interface Pointer= " +myIntrPtr.ToInt32());
      }
   }
}