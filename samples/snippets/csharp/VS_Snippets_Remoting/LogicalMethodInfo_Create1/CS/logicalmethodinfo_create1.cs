// All the following have been marked as 1 snippet : Snippet1

// System.Web.Services.Protocols.LogicalMethodInfo.Create(MethodInfo)
// System.Web.Services.Protocols.LogicalMethodInfo.Name
// System.Web.Services.Protocols.LogicalMethodInfo.InParameters
// System.Web.Services.Protocols.LogicalMethodInfo.OutParameters
// System.Web.Services.Protocols.LogicalMethodInfo.IsVoid

/*
   This following example demonstrates the 'Name',
   'InParameters', 'OutParameters', 'IsVoid' properties and 
   'Create(MethodInfo)' method of the 'LogicalMethodInfo' class. 
   This example displays the parameters, the in parameters and 
   out parameters.
   
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

public class MyService
{
   public void MyMethod(int inParameter, out int outParameter)
   {
      outParameter = inParameter;
   }
}

public class LogicalMethodInfo_Create
{
   public static void Main()
   {
      Type myType = typeof(MyService);
      MethodInfo myMethodInfo = myType.GetMethod("MyMethod");
      LogicalMethodInfo myLogicalMethodInfo = 
         (LogicalMethodInfo.Create(new MethodInfo[] {myMethodInfo}))[0];

      Console.WriteLine("\nPrinting parameters for the method : {0}",
                           myLogicalMethodInfo.Name);

      Console.WriteLine("\nThe parameters of the method {0} are :\n",
         myLogicalMethodInfo.Name);
      ParameterInfo[] myParameters = myLogicalMethodInfo.Parameters;
      for(int i = 0; i < myParameters.Length; i++)
      {
         Console.WriteLine("\t" + myParameters[i].Name +
            " : " + myParameters[i].ParameterType);
      }

      Console.WriteLine("\nThe in parameters of the method {0} are :\n",
         myLogicalMethodInfo.Name);
      myParameters = myLogicalMethodInfo.InParameters;
      for(int i = 0; i < myParameters.Length; i++)
      {
         Console.WriteLine("\t" + myParameters[i].Name +
            " : " + myParameters[i].ParameterType);
      }

      Console.WriteLine("\nThe out parameters of the method {0} are :\n",
         myLogicalMethodInfo.Name);
      myParameters = myLogicalMethodInfo.OutParameters;
      for(int i = 0; i < myParameters.Length; i++)
      {
         Console.WriteLine("\t" + myParameters[i].Name +
            " : " + myParameters[i].ParameterType);
      }

      if(myLogicalMethodInfo.IsVoid)
         Console.WriteLine("\nThe return type is void");
      else
         Console.WriteLine("\nThe return type is {0}",
                                 myLogicalMethodInfo.ReturnType);

   }
}
// </Snippet1>