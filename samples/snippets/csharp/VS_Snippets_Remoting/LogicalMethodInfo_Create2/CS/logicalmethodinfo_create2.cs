// System.Web.Services.Protocols.LogicalMethodInfo.Create(MethodInfo[], LogicalMethodTypes)
// System.Web.Services.Protocols.LogicalMethodInfo.AsyncCallbackParameter
// System.Web.Services.Protocols.LogicalMethodInfo.AsyncStateParameter
// System.Web.Services.Protocols.LogicalMethodInfo.AsyncResultParameter

// System.Web.Services.Protocols.LogicalMethodInfo.BeginMethodInfo
// System.Web.Services.Protocols.LogicalMethodInfo.EndMethodInfo
// System.Web.Services.Protocols.LogicalMethodInfo.IsAsync
// System.Web.Services.Protocols.LogicalMethodTypes.Async

/*
   This following example demonstrates the 'AsyncCallbackParameter',
   'AsyncResultParameter', 'AsyncStateParameter', 'BeginMethodInfo',
   'EndMethodInfo', 'IsAsync' properties and 
   'Create(MethodInfo[], LogicalMethodTypes)' method of the 
   'LogicalMethodInfo' class and the 'Async' enum member of the 
   'LogicalMethodTypes' enumeration. This example displays the callback,
   result and state parameters for asynchronous methods. It also displays 
   the begin and end for such asynchronous methods.
   
   Note : The 'LogicalMethodInfo' class should only be used with
   'SoapMessage'. 'SoapClientMessage' and 'SoapServerMessage' contain
   a property named 'MethodInfo' which provides for an instance of
   'LogicalMethodInfo'. If you are interested only in the reflection
   of a type then use the 'System.Reflection' namespace and not this
   class. This class gives information about the method invoked for
   a web service and hence should only be used as such. For example
   purposes it is being showed in a more simplified scenario.
 */
// <Snippet1>
using System;
using System.Reflection;
using System.Web.Services.Protocols;

public class MyService : SoapHttpClientProtocol
{
   public IAsyncResult BeginAdd(int xValue, int yValue,
                                AsyncCallback callback,
                                object asyncState)
   {
      return this.BeginInvoke("Add", new object[] {xValue,yValue}, callback, asyncState);
   }

   public int EndAdd(System.IAsyncResult asyncResult) 
   {
      object[] results = this.EndInvoke(asyncResult);
      return ((int)(results[0]));
   } 
}

public class LogicalMethodInfo_Create
{
   public static void Main()
   {
      Type myType = typeof(MyService);
      MethodInfo myBeginMethod = myType.GetMethod("BeginAdd");
      MethodInfo myEndMethod = myType.GetMethod("EndAdd");
      LogicalMethodInfo myLogicalMethodInfo = 
         (LogicalMethodInfo.Create(new MethodInfo[] { myBeginMethod,
                                                      myEndMethod },
                                   LogicalMethodTypes.Async))[0];

      Console.WriteLine("\nThe asynchronous callback parameter of method {0} is :\n",
                           myLogicalMethodInfo.Name);
      Console.WriteLine("\t" + myLogicalMethodInfo.AsyncCallbackParameter.Name +
                              " : " + myLogicalMethodInfo.AsyncCallbackParameter.ParameterType);

            Console.WriteLine("\nThe asynchronous state parameter of method {0} is :\n",
         myLogicalMethodInfo.Name);
      Console.WriteLine("\t" + myLogicalMethodInfo.AsyncStateParameter.Name +
         " : " + myLogicalMethodInfo.AsyncStateParameter.ParameterType);

      Console.WriteLine("\nThe asynchronous result parameter of method {0} is :\n",
         myLogicalMethodInfo.Name);
      Console.WriteLine("\t" + myLogicalMethodInfo.AsyncResultParameter.Name +
         " : " + myLogicalMethodInfo.AsyncResultParameter.ParameterType);

      Console.WriteLine("\nThe begin method of the asynchronous method {0} is :\n",
         myLogicalMethodInfo.Name);
      Console.WriteLine("\t" + myLogicalMethodInfo.BeginMethodInfo);

      Console.WriteLine("\nThe end method of the asynchronous method {0} is :\n",
         myLogicalMethodInfo.Name);
      Console.WriteLine("\t" + myLogicalMethodInfo.EndMethodInfo);

      if(myLogicalMethodInfo.IsAsync)
         Console.WriteLine("\n{0} is asynchronous", myLogicalMethodInfo.Name);
      else
         Console.WriteLine("\n{0} is synchronous", myLogicalMethodInfo.Name);

   }
}
// </Snippet1>
