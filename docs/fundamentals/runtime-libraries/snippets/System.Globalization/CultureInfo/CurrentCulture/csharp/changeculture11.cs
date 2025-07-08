// <Snippet11>
using System;
using System.Globalization;
using System.Threading;

public class Info11 : MarshalByRefObject
{
    public void ShowCurrentCulture()
    {
        Console.WriteLine($"Culture of {Thread.CurrentThread.Name} in application domain {AppDomain.CurrentDomain.FriendlyName}: {CultureInfo.CurrentCulture.Name}");
    }
}

public class Example11
{
    public static void Main()
    {
        Info11 inf = new Info11();
        // Set the current culture to Dutch (Netherlands).
        Thread.CurrentThread.Name = "MainThread";
        CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("nl-NL");
        inf.ShowCurrentCulture();

        // Create a new application domain.
        AppDomain ad = AppDomain.CreateDomain("Domain2");
        Info11 inf2 = (Info11)ad.CreateInstanceAndUnwrap(typeof(Info11).Assembly.FullName, "Info11");
        inf2.ShowCurrentCulture();
    }
}
// The example displays the following output:
//       Culture of MainThread in application domain ChangeCulture1.exe: nl-NL
//       Culture of MainThread in application domain Domain2: nl-NL
// </Snippet11>
