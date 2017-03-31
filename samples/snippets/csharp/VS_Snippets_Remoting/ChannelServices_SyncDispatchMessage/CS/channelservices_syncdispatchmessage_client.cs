// System.Runtime.Remoting.Channels.ChannelServices.SyncDispatchMessage(IMessage)

/*
   The following example demonstrates 'SyncDispatchMessage' method of 
   'ChannelServices' class. In the example, 'MyProxy' extends 'RealProxy'
   class and overrides its constructor and 'Invoke' messages. In the 'Main' 
   method, the 'MyProxy' class is instantiated and 'MyPrintMethod' method 
   is called on it.
*/ 

using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;

// <Snippet1>
// Create a custom 'RealProxy'.
public class MyProxy : RealProxy
{
   String myURIString;
   MarshalByRefObject myMarshalByRefObject;   

   [PermissionSet(SecurityAction.LinkDemand)]
   public MyProxy(Type myType) : base(myType)
   {
      // RealProxy uses the Type to generate a transparent proxy.
      myMarshalByRefObject = (MarshalByRefObject)Activator.CreateInstance((myType));
      // Get 'ObjRef', for transmission serialization between application domains.
      ObjRef myObjRef = RemotingServices.Marshal(myMarshalByRefObject);
      // Get the 'URI' property of 'ObjRef' and store it.
      myURIString = myObjRef.URI;
      Console.WriteLine("URI :{0}", myObjRef.URI);
   }

   [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags=SecurityPermissionFlag.Infrastructure)]
   public override IMessage Invoke(IMessage myIMessage)
   {
      Console.WriteLine("MyProxy.Invoke Start");
      Console.WriteLine("");

      if (myIMessage is IMethodCallMessage)
         Console.WriteLine("IMethodCallMessage");

      if (myIMessage is IMethodReturnMessage)
         Console.WriteLine("IMethodReturnMessage");

      Type msgType = myIMessage.GetType();
      Console.WriteLine("Message Type: {0}", msgType.ToString());
      Console.WriteLine("Message Properties");
      IDictionary myIDictionary = myIMessage.Properties;
      // Set the '__Uri' property of 'IMessage' to 'URI' property of 'ObjRef'.
      myIDictionary["__Uri"] = myURIString;
      IDictionaryEnumerator myIDictionaryEnumerator = 
         (IDictionaryEnumerator) myIDictionary.GetEnumerator();

      while (myIDictionaryEnumerator.MoveNext())
      {
         Object myKey = myIDictionaryEnumerator.Key;
         String myKeyName = myKey.ToString();
         Object myValue = myIDictionaryEnumerator.Value;

         Console.WriteLine("\t{0} : {1}", myKeyName, 
            myIDictionaryEnumerator.Value);
         if (myKeyName == "__Args")
         {
            Object[] myObjectArray = (Object[])myValue;
            for (int aIndex = 0; aIndex < myObjectArray.Length; aIndex++)
               Console.WriteLine("\t\targ: {0} myValue: {1}", aIndex, 
                  myObjectArray[aIndex]);
         }

         if ((myKeyName == "__MethodSignature") && (null != myValue))
         {
            Object[] myObjectArray = (Object[])myValue;
            for (int aIndex = 0; aIndex < myObjectArray.Length; aIndex++)
               Console.WriteLine("\t\targ: {0} myValue: {1}", aIndex, 
                  myObjectArray[aIndex]);
         }
      }
      
      IMessage myReturnMessage;

      myIDictionary["__Uri"] = myURIString;
      Console.WriteLine("__Uri {0}", myIDictionary["__Uri"]);

      Console.WriteLine("ChannelServices.SyncDispatchMessage");
      myReturnMessage = ChannelServices.SyncDispatchMessage(myIMessage);

      // Push return value and OUT parameters back onto stack.

      IMethodReturnMessage myMethodReturnMessage = (IMethodReturnMessage)
         myReturnMessage;
      Console.WriteLine("IMethodReturnMessage.ReturnValue: {0}", 
         myMethodReturnMessage.ReturnValue);

      Console.WriteLine("MyProxy.Invoke - Finish");

      return myReturnMessage;
   }
}
// </Snippet1>
public class Client
{
   [PermissionSet(SecurityAction.LinkDemand)]
   public static void Main()
   {
      try
      {
         TcpChannel myTcpChannel = new TcpChannel(8086);
         ChannelServices.RegisterChannel(myTcpChannel);
         MyProxy myProxyObject = new MyProxy(typeof(PrintServer));
         PrintServer myPrintServer = (PrintServer)myProxyObject.GetTransparentProxy();
         if (myPrintServer == null) 
            Console.WriteLine("Could not locate server");
         else 
            Console.WriteLine(myPrintServer.MyPrintMethod("String1", 1.2, 6));
         Console.WriteLine("Calling the Proxy");
         int kValue = myPrintServer.MyPrintMethod("String1", 1.2, 6);
         Console.WriteLine("Checking result"); 
   
         if (kValue == 6)
         {
            Console.WriteLine("PrintServer.MyPrintMethod PASSED : returned {0}", 
               kValue);            
         }
         else
         {
            Console.WriteLine("PrintServer.MyPrintMethod FAILED : returned {0}", 
               kValue);            
         }
         Console.WriteLine("Sample Done");    
      } 
      catch(Exception e)
      {
         Console.WriteLine("Exception caught!!!");
         Console.WriteLine("The source of exception: "+e.Source);
         Console.WriteLine("The Message of exception: "+e.Message);
      }     
   }   
}

