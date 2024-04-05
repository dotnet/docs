//<Snippet1>
using System.Diagnostics.Tracing;

namespace Demo1
{
    //<Snippet2>
    sealed class MyCompanyEventSource : EventSource
    {
        public static MyCompanyEventSource Log = new MyCompanyEventSource();

        public void Startup() { WriteEvent(1); }
        public void OpenFileStart(string fileName) { WriteEvent(2, fileName); }
        public void OpenFileStop() { WriteEvent(3); }
    }
    //</Snippet2>

    //<Snippet3>
    class Program1
    {
        static void Main(string[] args)
        {
            MyCompanyEventSource.Log.Startup();
            // ...
            MyCompanyEventSource.Log.OpenFileStart("SomeFile");
            // ...
            MyCompanyEventSource.Log.OpenFileStop();
        }
    }
    //</Snippet3>
}
//</Snippet1>
