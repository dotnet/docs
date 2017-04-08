// <Snippet1>
using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;

[assembly:NeutralResourcesLanguageAttribute("en-US")]

public class Example
{
   private static int nGreetings = 0;
   private static ResourceManager rm;

   public static void Main()
   {
      AppDomain domain = AppDomain.CurrentDomain;
      rm = new ResourceManager("GreetingStrings", 
                               typeof(Example).Assembly);
                  
      CultureInfo culture = null;
      if (Thread.CurrentThread.CurrentUICulture.Name == "ru-RU")
         culture = CultureInfo.CreateSpecificCulture("en-US");
      else
         culture = CultureInfo.CreateSpecificCulture("ru-RU");

      Thread.CurrentThread.CurrentCulture = culture;
      Thread.CurrentThread.CurrentUICulture = culture;

      ShowGreeting();
      Thread.Sleep(1000);

      Thread workerThread = new Thread(Example.ShowGreeting);
      workerThread.Start();
   }

   private static void ShowGreeting()
   {
      string greeting = nGreetings == 0 ? rm.GetString("newGreeting") :
                                          rm.GetString("greeting");
      nGreetings++;
      Console.WriteLine("{0}", greeting);   
   }
}
// The example displays the following output:
//       Привет!
//       Hello again!
// </Snippet1>