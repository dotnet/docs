// <Snippet1>
using System;

public class Example2
{
    public static void Main()
    {
        AppDomainSetup appSetup = new AppDomainSetup();
        appSetup.SetCompatibilitySwitches(new string[] { "NetFx40_TimeSpanLegacyFormatMode" });
        AppDomain legacyDomain = AppDomain.CreateDomain("legacyDomain",
                                                        null, appSetup);
        legacyDomain.ExecuteAssembly("ShowTimeSpan.exe");
    }
}
// </Snippet1>
