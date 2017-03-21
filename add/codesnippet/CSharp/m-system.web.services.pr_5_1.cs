using System;
using System.Reflection;
using System.Security.Permissions;
using System.Web.Services.Protocols;

public class MyService 
{
   public int Add(int xValue, int yValue)
   {
      return (xValue + yValue);
   }
}

class LogicalMethodInfo_Constructor
{
   [PermissionSetAttribute(SecurityAction.Demand, Name="FullTrust")]
   static void Run()
   {
      Type myType = typeof(MyService);
      MethodInfo myMethodInfo = myType.GetMethod("Add");
      LogicalMethodInfo myLogicalMethodInfo = 
                  new LogicalMethodInfo(myMethodInfo);

      Console.WriteLine("\nPrinting properties of method : {0}\n",
                              myLogicalMethodInfo.ToString());

      Console.WriteLine("\nThe declaring type of the method {0} is :\n",
                              myLogicalMethodInfo.Name);
      Console.WriteLine("\t" + myLogicalMethodInfo.DeclaringType);

      Console.WriteLine("\nThe parameters of the method {0} are :\n",
                              myLogicalMethodInfo.Name);
      ParameterInfo[] myParameters = myLogicalMethodInfo.Parameters;
      for(int i = 0; i < myParameters.Length; i++)
      {
         Console.WriteLine("\t" + myParameters[i].Name +
                                 " : " + myParameters[i].ParameterType);
      }

      Console.WriteLine("\nThe return type of the method {0} is :\n",
                              myLogicalMethodInfo.Name);
      Console.WriteLine("\t" + myLogicalMethodInfo.ReturnType);

      MyService service = new MyService();
      Console.WriteLine("\nInvoking the method {0}\n",
                              myLogicalMethodInfo.Name);
      Console.WriteLine("\tThe sum of 10 and 10 is : {0}",
                              myLogicalMethodInfo.Invoke(service, 
                                                   new object[] {10, 10}));

   }
   
   static void Main()
   {
      Run();
   }  
}