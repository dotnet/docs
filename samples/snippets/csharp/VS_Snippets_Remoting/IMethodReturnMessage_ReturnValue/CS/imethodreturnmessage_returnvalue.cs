// System.Runtime.Remoting.Messaging.IMethodReturnMessage
// System.Runtime.Remoting.Messaging.IMethodReturnMessage.OutArgs
// System.Runtime.Remoting.Messaging.IMethodReturnMessage.ReturnValue
// System.Runtime.Remoting.Messaging.IMethodReturnMessage.OutArgCount
// System.Runtime.Remoting.Messaging.IMethodReturnMessage.GetOutArg
// System.Runtime.Remoting.Messaging.IMethodReturnMessage.GetOutArgName

/*
   The following example demonstrates 'ReturnValue', 'OutArgCount' properties,
   'GetOutArg', 'GetOutArgName' methods of 'IMethodReturnMessage' interface 
   and 'IMethodReturnMessage' interface.
   A custom proxy is created by extending 'RealProxy' and overriding 'Invoke' method of
   'RealProxy'. The custom proxy is accessed by passing message to the Invoke method.
   The Invoke method calls properties of 'IMethodReturnMessage' interface and
   prints the values to the console.
*/

using System;
using System.Collections;
using System.Runtime.Serialization;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;

namespace CustomProxySample
{
   public class CustomServer :MarshalByRefObject
   {
      public string HelloMethod(string myString, ref double myDoubleValue,
          out int myIntValue)
      {
         myIntValue = 100;
         return myString;
      }
   }
// <Snippet1>
   [PermissionSet(SecurityAction.Demand, Name="FullTrust")]
   public class MyProxy : RealProxy
   {
      String stringUri;
      MarshalByRefObject myMarshalByRefObject;

      public MyProxy(Type myType): base(myType)
      {
         myMarshalByRefObject = (MarshalByRefObject)Activator.CreateInstance(myType);
         ObjRef myObject = RemotingServices.Marshal(myMarshalByRefObject);
         stringUri = myObject.URI;
      }

// <Snippet2>
      public override IMessage Invoke(IMessage myMessage)
      {
         IMethodCallMessage myCallMessage = (IMethodCallMessage)myMessage;

         IMethodReturnMessage myIMethodReturnMessage =
            RemotingServices.ExecuteMessage(myMarshalByRefObject, myCallMessage);

         Console.WriteLine("Method name : " + myIMethodReturnMessage.MethodName);
         Console.WriteLine("The return value is : " + myIMethodReturnMessage.ReturnValue);

         // Get number of 'ref' and 'out' parameters.
         int myArgOutCount = myIMethodReturnMessage.OutArgCount;
         Console.WriteLine("The number of 'ref', 'out' parameters are : " +
            myIMethodReturnMessage.OutArgCount);
         // Gets name and values of 'ref' and 'out' parameters.
         for(int i = 0; i < myArgOutCount; i++)
         {
            Console.WriteLine("Name of argument {0} is '{1}'.",
               i, myIMethodReturnMessage.GetOutArgName(i));
            Console.WriteLine("Value of argument {0} is '{1}'.",
               i, myIMethodReturnMessage.GetOutArg(i));
         }
         Console.WriteLine();
         object[] myObjectArray = myIMethodReturnMessage.OutArgs; 
         for(int i = 0; i < myObjectArray.Length; i++)
            Console.WriteLine("Value of argument {0} is '{1}' in OutArgs",
               i, myObjectArray[i]);
         return myIMethodReturnMessage;
      }
// </Snippet2>
   }
// </Snippet1>
   public class ProxySample
   {
      [SecurityPermission(SecurityAction.LinkDemand)]
      public static void Main()
      {
         // Create an instance of MyProxy.
         MyProxy myCustomProxy = new MyProxy(typeof(CustomServer));
         // Get an instance of remote class.
         CustomServer myHelloServer =
               (CustomServer)myCustomProxy.GetTransparentProxy();
         double myDoubleValue = 10.5;
         int myIntValue = 200;
         // Invoke the remote method.
          myHelloServer.HelloMethod("Hello",ref myDoubleValue,out myIntValue);
       }
   }
}
