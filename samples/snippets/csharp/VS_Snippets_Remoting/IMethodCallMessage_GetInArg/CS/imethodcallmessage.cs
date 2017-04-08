// System.Runtime.Remoting.IMethodCallMessage
// System.Runtime.Remoting.IMethodCallMessage.InArgCount
// System.Runtime.Remoting.IMethodCallMessage.InArgs
// System.Runtime.Remoting.IMethodCallMessage.GetArgName(int)
// System.Runtime.Remoting.IMethodCallMessage.GetInArg(int)

/*
   The following example demonstrates 'GetInArg', 'GetArgName', 'InArgCount' and 'InArgs' 
   members of 'IMethodCallMessage' interface.
   In this example custom proxy is accessed by passing message to the Invoke method.  
   In invoke method check the type of message. If the type is IMethodCallMessage, then
   InArgCount,InArgs,GetArgName(int) and GetInArg(int) of the interface are displayed. 
   This example also shows how to create a custom proxy.
*/


// <Snippet1>
using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;

namespace IMethodCallMessageNS
{
   // MyProxy extends the CLR Remoting RealProxy.
   // In the same class, in the Invoke method, the methods and properties of the 
   // IMethodCallMessage are demonstrated.

   [PermissionSet(SecurityAction.Demand, Name="FullTrust")]
   public class MyProxy : RealProxy
   {
      public MyProxy(Type myType) : base(myType)
      {
         // This constructor forwards the call to base RealProxy.
         // RealProxy uses the Type to generate a transparent proxy.
      }

// <Snippet2>

      public override IMessage Invoke(IMessage myIMessage)
      {
         Console.WriteLine("MyProxy.Invoke Start");
         Console.WriteLine("");
         ReturnMessage myReturnMessage = null;
         
         if (myIMessage is IMethodCallMessage)
         {
            Console.WriteLine("Message is of type 'IMethodCallMessage'.");
            Console.WriteLine("");

            IMethodCallMessage myIMethodCallMessage;
            myIMethodCallMessage=(IMethodCallMessage)myIMessage;
            Console.WriteLine("InArgCount is  : " + 
                              myIMethodCallMessage.InArgCount.ToString());
         
            foreach (object myObj in myIMethodCallMessage.InArgs)
            {
               Console.WriteLine("InArgs is : " + myObj.ToString());
            }

            for(int i=0; i<myIMethodCallMessage.InArgCount; i++)
            {
               Console.WriteLine("GetArgName(" +i.ToString() +") is : " + 
                                       myIMethodCallMessage.GetArgName(i));
               Console.WriteLine("GetInArg("+i.ToString() +") is : " +
                              myIMethodCallMessage.GetInArg(i).ToString());
            }
            Console.WriteLine("");
         }
         else if (myIMessage is IMethodReturnMessage)
            Console.WriteLine("Message is of type 'IMethodReturnMessage'.");
                  
         // Build Return Message
         myReturnMessage = new ReturnMessage(5,null,0,null,
                                       (IMethodCallMessage)myIMessage);
      
         Console.WriteLine("MyProxy.Invoke - Finish");
         return myReturnMessage;
      }


   }
  
   
   // The class used to obtain Metadata.
   [PermissionSet(SecurityAction.Demand, Name="FullTrust")]
   public class MyMarshalByRefClass : MarshalByRefObject
   {
      public int MyMethod(string str, double dbl, int i)
      {
         Console.WriteLine("MyMarshalByRefClass.MyMethod {0} {1} {2}", str, dbl, i);
         return 0;
      }
   }
// </Snippet2>
   // Main class that drives the whole sample.
   public class ProxySample
   {
      [SecurityPermission(SecurityAction.LinkDemand)]
      public static void Main()
      {
         Console.WriteLine("Generate a new MyProxy.");
         MyProxy myProxy = new MyProxy(typeof(MyMarshalByRefClass));

         Console.WriteLine("Obtain the transparent proxy from myProxy.");
         MyMarshalByRefClass myMarshalByRefClassObj = 
                              (MyMarshalByRefClass)myProxy.GetTransparentProxy();

         Console.WriteLine("Calling the Proxy.");
         object myReturnValue = myMarshalByRefClassObj.MyMethod("Microsoft", 1.2, 6);
         
         Console.WriteLine("Sample Done.");
      }
   }
}
// </Snippet1>