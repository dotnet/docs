//<SnippetLocBamlChangeCultureCODEBEHIND>
using System.Globalization;
using System.Threading;
using System.Windows;

namespace SDKSample
{
    public partial class App : Application
    {
        public App()
        {
            // Change culture under which this application runs
            CultureInfo ci = new CultureInfo("fr-CA");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }
    }
}
//</SnippetLocBamlChangeCultureCODEBEHIND>
