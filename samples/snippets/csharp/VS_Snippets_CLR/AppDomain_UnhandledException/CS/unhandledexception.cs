// <Snippet1>
using System;
using System.Security.Permissions;

public class Example 
{
   [SecurityPermission(SecurityAction.Demand, Flags=SecurityPermissionFlag.ControlAppDomain)]
   public static void Main()
   {
      AppDomain currentDomain = AppDomain.CurrentDomain;
      currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);
      
      try {
         throw new Exception("1");
      } catch (Exception e) {
         Console.WriteLine("Catch clause caught : {0} \n", e.Message);
      }

      throw new Exception("2");
   }
   
   static void MyHandler(object sender, UnhandledExceptionEventArgs args) 
   {
      Exception e = (Exception) args.ExceptionObject;
      Console.WriteLine("MyHandler caught : " + e.Message);
      Console.WriteLine("Runtime terminating: {0}", args.IsTerminating);
   }
}
// The example displays the following output:
//       Catch clause caught : 1
//       
//       MyHandler caught : 2
//       Runtime terminating: True
//       
//       Unhandled Exception: System.Exception: 2
//          at Example.Main()  
// </Snippet1>
