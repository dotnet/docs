// System.Runtime.Remoting.Messaging.IMethodMessage
// System.Runtime.Remoting.Messaging.IMethodMessage.MethodName
// System.Runtime.Remoting.Messaging.IMethodMessage.ArgCount
// System.Runtime.Remoting.Messaging.IMethodMessage.GetArgName
// System.Runtime.Remoting.Messaging.IMethodMessage.GetArg
// System.Runtime.Remoting.Messaging.IMethodMessage.HasVarArgs
// System.Runtime.Remoting.Messaging.IMethodMessage.Args

/*
   The following program demonstrates the 'MethodName', 'ArgCount', 'HasVarArgs',
   'Args' properties, 'GetArgName', 'GetArg' methods of 'IMethodMessage' interface and
   'IMethodMessage' interface.
   In this example custom proxy is accessed by passing message to the Invoke method.
   The Invoke method calls the methods and properties of 'IMethodMessage' interface
   and displays the result to the console.
 */

using System;
using System.Reflection;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;

[PermissionSet(SecurityAction.Demand, Name="FullTrust")]
public class Reverser : MarshalByRefObject
{
   private string stringReversed;

   public string GetReversedString()
   {
      return stringReversed;
   }
   public void SetString(string temp)
   {
      DoReverse(temp);
   }

   // Exposed reverse as a method to reverse a string.
   private void DoReverse(string argString)
   {
      stringReversed = "";
      for (int i = argString.Length-1 ; i >= 0 ; i--)
      {
         stringReversed += argString[i];
      }
   }
}

// <Snippet1>
[PermissionSet(SecurityAction.Demand, Name="FullTrust")]
public class MyProxyClass : RealProxy
{
   private Object  myObjectInstance  = null;
   private Type    myType      = null;

   public MyProxyClass(Type argType) : base(argType)
   {
      myType = argType;
      myObjectInstance = Activator.CreateInstance(argType);
   }

// <Snippet2>
   // Overriding the Invoke method of RealProxy.
   public override IMessage Invoke(IMessage message)
   {
      IMethodMessage myMethodMessage = (IMethodMessage)message;

      Console.WriteLine("**** Begin Invoke ****");
      Console.WriteLine("\tType is : " + myType);
      Console.WriteLine("\tMethod name : " +  myMethodMessage.MethodName);

      for (int i=0; i < myMethodMessage.ArgCount; i++)
      {
         Console.WriteLine("\tArgName is : " + myMethodMessage.GetArgName(i));
         Console.WriteLine("\tArgValue is: " + myMethodMessage.GetArg(i));
      }

      if(myMethodMessage.HasVarArgs)
          Console.WriteLine("\t The method have variable arguments!!");
      else
          Console.WriteLine("\t The method does not have variable arguments!!");

      // Dispatch the method call to the real object.
      Object returnValue = myType.InvokeMember( myMethodMessage.MethodName, BindingFlags.InvokeMethod, null,
                                           myObjectInstance, myMethodMessage.Args );
      Console.WriteLine("**** End Invoke ****");

      // Build the return message to pass back to the transparent proxy.
      ReturnMessage myReturnMessage = new ReturnMessage( returnValue, null, 0, null,
          (IMethodCallMessage)message );
      return myReturnMessage;
   }
// </Snippet2>
}
// </Snippet1>

public class ApplicationClass
{
   [SecurityPermission(SecurityAction.LinkDemand)]
   public static void Main()
   {
      MyProxyClass myProxy = new MyProxyClass(typeof(Reverser));

      // The real proxy dynamically creates a transparent proxy.
      Reverser myReverser = (Reverser)myProxy.GetTransparentProxy();

      myReverser.SetString("Hello World!");
      Console.WriteLine("The out result is : {0}", myReverser.GetReversedString());
   }
}