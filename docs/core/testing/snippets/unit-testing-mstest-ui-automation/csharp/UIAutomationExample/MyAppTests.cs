// <WindowTestClass>
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Windows.UIAutomation;

[STATestClass]
public sealed class MyAppTests : WindowTest
{
    protected override ProcessStartInfo CreateProcessStartInfo()
        => new(@"C:\MyApp\MyApp.exe");
}
// </WindowTestClass>
