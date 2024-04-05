//<Snippet1>
using System;
using System.Diagnostics.Tracing;

namespace Demo2
{
    enum MyColor { Red, Yellow, Blue };

    [EventSource(Name = "MyCompany")]
    sealed class MyCompanyEventSource : EventSource
    {
        //<Snippet2>
        //<Snippet3>
        public static class Keywords
        {
            public const EventKeywords Page = (EventKeywords)1;
            public const EventKeywords DataBase = (EventKeywords)2;
            public const EventKeywords Diagnostic = (EventKeywords)4;
            public const EventKeywords Perf = (EventKeywords)8;
        }
        //</Snippet3>

        //<Snippet4>
        public static class Tasks
        {
            public const EventTask Page = (EventTask)1;
            public const EventTask DBQuery = (EventTask)2;
        }
        //</Snippet2>
        //</Snippet4>

        //<Snippet5>
        [Event(1, Message = "Application Failure: {0}", Level = EventLevel.Error, Keywords = Keywords.Diagnostic)]
        public void Failure(string message) { WriteEvent(1, message); }
        //</Snippet5>

        //<Snippet6>
        [Event(2, Message = "Starting up.", Keywords = Keywords.Perf, Level = EventLevel.Informational)]
        public void Startup() { WriteEvent(2); }
        //</Snippet6>

        //<Snippet7>
        [Event(3, Message = "loading page {1} activityID={0}", Opcode = EventOpcode.Start,
            Task = Tasks.Page, Keywords = Keywords.Page, Level = EventLevel.Informational)]
        public void PageStart(int ID, string url) { if (IsEnabled()) WriteEvent(3, ID, url); }
        //</Snippet7>

        //<Snippet8>
        [Event(4, Opcode = EventOpcode.Stop, Task = Tasks.Page, Keywords = Keywords.Page, Level = EventLevel.Informational)]
        public void PageStop(int ID) { if (IsEnabled()) WriteEvent(4, ID); }
        //</Snippet8>

        //<Snippet9>
        [Event(5, Opcode = EventOpcode.Start, Task = Tasks.DBQuery, Keywords = Keywords.DataBase, Level = EventLevel.Informational)]
        public void DBQueryStart(string sqlQuery) { WriteEvent(5, sqlQuery); }
        //</Snippet9>

        //<Snippet10>
        [Event(6, Opcode = EventOpcode.Stop, Task = Tasks.DBQuery, Keywords = Keywords.DataBase, Level = EventLevel.Informational)]
        public void DBQueryStop() { WriteEvent(6); }
        //</Snippet10>

        //<Snippet11>
        [Event(7, Level = EventLevel.Verbose, Keywords = Keywords.DataBase)]
        public void Mark(int ID) { if (IsEnabled()) WriteEvent(7, ID); }
        //</Snippet11>

        //<Snippet12>
        [Event(8)]
        public void LogColor(MyColor color) { WriteEvent(8, (int)color); }
        //</Snippet12>

        public static MyCompanyEventSource Log = new MyCompanyEventSource();
    }

    class Program
    {
        static void Main(string[] args)
        {
            //<Snippet13>
            MyCompanyEventSource.Log.Startup();
            Console.WriteLine("Starting up");

            MyCompanyEventSource.Log.DBQueryStart("Select * from MYTable");
            var url = "http://localhost";
            for (int i = 0; i < 10; i++)
            {
                MyCompanyEventSource.Log.PageStart(i, url);
                MyCompanyEventSource.Log.Mark(i);
                MyCompanyEventSource.Log.PageStop(i);
            }
            MyCompanyEventSource.Log.DBQueryStop();
            MyCompanyEventSource.Log.LogColor(MyColor.Blue);

            MyCompanyEventSource.Log.Failure("This is a failure 1");
            MyCompanyEventSource.Log.Failure("This is a failure 2");
            MyCompanyEventSource.Log.Failure("This is a failure 3");
            //</Snippet13>
        }
    }
}
//</Snippet1>
