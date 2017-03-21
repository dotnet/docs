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