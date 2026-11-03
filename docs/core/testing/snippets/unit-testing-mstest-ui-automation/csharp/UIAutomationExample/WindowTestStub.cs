using System.Diagnostics;

namespace Microsoft.VisualStudio.TestTools.UnitTesting.Windows.UIAutomation;

// Build-only fallback until the MSTest 4.5 preview packages are publicly available.
public abstract class WindowTest
{
    protected abstract ProcessStartInfo CreateProcessStartInfo();
}
