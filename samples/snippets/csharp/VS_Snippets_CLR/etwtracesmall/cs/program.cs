//<Snippet1>
using System.Diagnostics.Tracing;
using System.Collections.Generic;

namespace Demo1
{
    //<Snippet2>
    class MyCompanyEventSource : EventSource
    {
        public static MyCompanyEventSource Log = new MyCompanyEventSource();

        public void Startup() { WriteEvent(1); }
        public void OpenFileStart(string fileName) { WriteEvent(2, fileName); }
        public void OpenFileStop() { WriteEvent(3); }
    }
    //</Snippet2>

    //<Snippet3>
    class Program
    {
        static void Main(string[] args)
        {
            string name = MyCompanyEventSource.GetName(typeof(MyCompanyEventSource));
            IEnumerable<EventSource> eventSources = MyCompanyEventSource.GetSources();
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
