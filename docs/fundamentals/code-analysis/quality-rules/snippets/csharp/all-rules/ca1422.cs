
using System.Runtime.Versioning;

public class Violation
{
    // <Snippet1>
    [SupportedOSPlatform("Windows")]
    public void M1()
    {
        // Violates rule CA1422.
        // This call site is reachable on 'Windows',
        // but 'ObsoletedOnWindows62()'
        // is obsoleted on 'Windows 6.2' and later.
        ObsoletedOnWindows62();
    }

    [ObsoletedOSPlatform("Windows6.2")]
    public void ObsoletedOnWindows62()
    { }
    // </Snippet1>
}

public class Fix
{
    // <Snippet2>
    [SupportedOSPlatform("Windows")]
    [ObsoletedOSPlatform("Windows6.2")]
    public void M1()
    {
        ObsoletedOnWindows62();
    }

    [ObsoletedOSPlatform("Windows6.2")]
    public void ObsoletedOnWindows62()
    { }
    // </Snippet2>
}

