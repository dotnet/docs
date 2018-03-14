// <Snippet11>
using System;
using System.Globalization;
using System.Threading;

public class Info : MarshalByRefObject
{
   public void ShowCurrentCulture()
   {
      Console.WriteLine("Culture of {0} in application domain {1}: {2}",
                        Thread.CurrentThread.Name,
                        AppDomain.CurrentDomain.FriendlyName,
                        CultureInfo.CurrentCulture.Name);
   }
}

public class Example
{
   public static void Main()
   {
      Info inf = new Info();
      // Set the current culture to Dutch (Netherlands).
      Thread.CurrentThread.Name = "MainThread";
      CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("nl-NL");
      inf.ShowCurrentCulture();
      
      // Create a new application domain.
       AppDomain ad = AppDomain.CreateDomain("Domain2");
       Info inf2 = (Info) ad.CreateInstanceAndUnwrap(typeof(Info).Assembly.FullName, "Info");
       inf2.ShowCurrentCulture();                       
   }
}
// The example displays the following output:
//       Culture of MainThread in application domain ChangeCulture1.exe: nl-NL
//       Culture of MainThread in application domain Domain2: nl-NL
// </Snippet11>
