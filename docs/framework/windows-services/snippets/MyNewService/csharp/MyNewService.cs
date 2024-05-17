//*******************************************************************
using System.Diagnostics;
using System.ServiceProcess;

public class Service1 : ServiceBase
{
    static void MainOriginal()
    {
        //<Snippet6>
        ServiceBase[] ServicesToRun;
        ServicesToRun = new ServiceBase[]
            { new Service1() };
        Run(ServicesToRun);
        //</Snippet6>
    }
}

public class MyNewService : ServiceBase
{
    //<Snippet1>
    static void Main()
    {
        ServiceBase[] ServicesToRun;
        // Change the following line to match.
        ServicesToRun = new ServiceBase[]
            { new MyNewService() };
        ServiceBase.Run(ServicesToRun);
    }
    //</Snippet1>

    //<Snippet16>
    private System.ComponentModel.IContainer _components;
    private readonly EventLog _eventLog1;
    //</Snippet16>

    [DebuggerStepThrough()]
    void InitializeComponent()
    {
        _components = new System.ComponentModel.Container();
        ServiceName = "MyNewService";
    }

    //<Snippet2>
    public MyNewService()
    {
        InitializeComponent();
        _eventLog1 = new EventLog();
        if (!EventLog.SourceExists("MySource"))
        {
            EventLog.CreateEventSource("MySource", "MyNewLog");
        }
        _eventLog1.Source = "MySource";
        _eventLog1.Log = "MyNewLog";
    }
    //</Snippet2>

    // <SnippetContructorWithArgs>
    public MyNewService(string[] args)
    {
        InitializeComponent();

        string eventSourceName = "MySource";
        string logName = "MyNewLog";

        if (args.Length > 0)
        {
            eventSourceName = args[0];
        }

        if (args.Length > 1)
        {
            logName = args[1];
        }

        _eventLog1 = new EventLog();

        if (!EventLog.SourceExists(eventSourceName))
        {
            EventLog.CreateEventSource(eventSourceName, logName);
        }

        _eventLog1.Source = eventSourceName;
        _eventLog1.Log = logName;
    }
    // </SnippetContructorWithArgs>

    //<Snippet3>
    protected override void OnStart(string[] args)
    {
        _eventLog1.WriteEntry("In OnStart.");
    }
    //</Snippet3>

    //<Snippet4>
    protected override void OnStop()
    {
        _eventLog1.WriteEntry("In OnStop.");
    }
    //</Snippet4>

    //<Snippet5>
    protected override void OnContinue()
    {
        _eventLog1.WriteEntry("In OnContinue.");
    }
    //</Snippet5>
}

//*******************************************************************
//<Snippet7>
public class UserService1 : ServiceBase
{
}
//</Snippet7>

//*******************************************************************
namespace WrapUserService1
{
    public class UserService1 : ServiceBase
    {
        //<Snippet8>
        public UserService1()
        {
            ServiceName = "MyService2";
            CanStop = true;
            CanPauseAndContinue = true;
            AutoLog = true;
        }
        //</Snippet8>

        //<Snippet9>
        public static void Main()
        {
            ServiceBase.Run(new UserService1());
        }
        //</Snippet9>

        //<Snippet10>
        protected override void OnStart(string[] args)
        {
            // Insert code here to define processing.
        }
        //</Snippet10>
    }
}

//*******************************************************************
class UserService2 : ServiceBase
{
    readonly EventLog _eventLog1;

    //<Snippet14>
    public UserService2()
    {
        _eventLog1 = new EventLog();
        // Turn off autologging

        //<Snippet17>
        AutoLog = false;
        //</Snippet17>
        // create an event source, specifying the name of a log that
        // does not currently exist to create a new, custom log
        if (!EventLog.SourceExists("MySource"))
        {
            EventLog.CreateEventSource(
                "MySource", "MyLog");
        }
        // configure the event log instance to use this source name
        _eventLog1.Source = "MySource";
        _eventLog1.Log = "MyLog";
    }
    //</Snippet14>

    //<Snippet15>
    protected override void OnStart(string[] args)
    {
        // write an entry to the log
        _eventLog1.WriteEntry("In OnStart.");
    }
    //</Snippet15>
}
