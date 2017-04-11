//<SnippetLocBamlChangeCultureCODEBEHIND>
using System.Windows; // Application
using System.Globalization; // CultureInfo
using System.Threading; // Thread

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