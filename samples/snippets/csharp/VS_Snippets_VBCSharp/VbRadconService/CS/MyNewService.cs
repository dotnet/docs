//*******************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceProcess;

public class Service1: System.ServiceProcess.ServiceBase
{
	void MainOriginal()
	{
		//<Snippet6>
		System.ServiceProcess.ServiceBase[] ServicesToRun;
		ServicesToRun = new System.ServiceProcess.ServiceBase[]
			{ new Service1() };
		System.ServiceProcess.ServiceBase.Run(ServicesToRun);
		//</Snippet6>
	}
}

public class MyNewService: System.ServiceProcess.ServiceBase
{
	//<Snippet1>
	static void Main()
	{
		System.ServiceProcess.ServiceBase[] ServicesToRun;
		// Change the following line to match.
		ServicesToRun = new System.ServiceProcess.ServiceBase[]
			{ new MyNewService() };
		System.ServiceProcess.ServiceBase.Run(ServicesToRun);
	}
	//</Snippet1>

	//<Snippet16>
	private System.ComponentModel.IContainer components;
	private System.Diagnostics.EventLog eventLog1;
	//</Snippet16>

	[System.Diagnostics.DebuggerStepThrough()]
	void InitializeComponent()
	{
		components = new System.ComponentModel.Container();
		this.ServiceName = "MyNewService";
	}

	//<Snippet2>
	public MyNewService()
	{
		InitializeComponent();
		eventLog1 = new System.Diagnostics.EventLog();
		if (!System.Diagnostics.EventLog.SourceExists("MySource"))
		{
			System.Diagnostics.EventLog.CreateEventSource(
				"MySource","MyNewLog");
		}
		eventLog1.Source = "MySource";
		eventLog1.Log = "MyNewLog";
	}
	//</Snippet2>

	//<Snippet3>
	protected override void OnStart(string[] args)
	{
		eventLog1.WriteEntry("In OnStart.");
	}
	//</Snippet3>

	//<Snippet4>
	protected override void OnStop()
	{
		eventLog1.WriteEntry("In OnStop.");
	}
	//</Snippet4>

	//<Snippet5>
	protected override void OnContinue()
	{
		eventLog1.WriteEntry("In OnContinue.");
	}
	//</Snippet5>
}

//*******************************************************************
//<Snippet7>
public class UserService1 : System.ServiceProcess.ServiceBase
{
}
//</Snippet7>

//*******************************************************************
namespace WrapUserService1
{
	public class UserService1:System.ServiceProcess.ServiceBase
	{
		//<Snippet8>
		public UserService1()
		{
			this.ServiceName = "MyService2";
			this.CanStop = true;
			this.CanPauseAndContinue = true;
			this.AutoLog = true;
		}
		//</Snippet8>

		//<Snippet9>
		public static void Main()
		{
			System.ServiceProcess.ServiceBase.Run(new UserService1());
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
class UserService2:System.ServiceProcess.ServiceBase
{
	System.Diagnostics.EventLog eventLog1;

	//<Snippet14>
	public UserService2()
	{
		eventLog1 = new System.Diagnostics.EventLog();
		// Turn off autologging

		//<Snippet17>
		this.AutoLog = false;
		//</Snippet17>
		// create an event source, specifying the name of a log that
		// does not currently exist to create a new, custom log
		if (!System.Diagnostics.EventLog.SourceExists("MySource"))
		{
			System.Diagnostics.EventLog.CreateEventSource(
				"MySource","MyLog");
		}
		// configure the event log instance to use this source name
		eventLog1.Source = "MySource";
		eventLog1.Log = "MyLog";
	}
	//</Snippet14>

	//<Snippet15>
	protected override void OnStart(string[] args)
	{
		// write an entry to the log
		eventLog1.WriteEntry("In OnStart.");
	}
	//</Snippet15>
}