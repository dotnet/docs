//<SnippetApplicationCODE>
using System; // STAThread
using System.Windows; // Application

namespace SDKSample
{
    public class AppCode : Application
    {
        // Entry point method
        [STAThread]
        public static void Main()
        {
            AppCode app = new AppCode();
            app.Run();
        }
    }
}
//</SnippetApplicationCODE>