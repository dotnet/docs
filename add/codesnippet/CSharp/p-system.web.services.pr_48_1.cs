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