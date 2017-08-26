using System.Activities;
using System.Activities.DurableInstancing;
using System.Configuration;
using System.Diagnostics;
using System.Net;
using System.Threading;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace WFWorkerRole
{
	public class WorkerRole : RoleEntryPoint
	{
		public override void Run()
		{
			Trace.WriteLine("WFWorkerRole entry point called", "Information");

			AutoResetEvent waitHandle = new AutoResetEvent(false);
			UpdateFilesList activity = new UpdateFilesList();
			WorkflowApplication workflow = new WorkflowApplication(activity);
			workflow.InstanceStore = new SqlWorkflowInstanceStore(ConfigurationManager.ConnectionStrings["WorkflowInstanceStore"].ConnectionString);
			workflow.PersistableIdle = (e) =>
			{
				return PersistableIdleAction.Persist;
			};
			workflow.Completed += (e) =>
			{
				waitHandle.Set();
			};
			workflow.Run();
			waitHandle.WaitOne();
		}

		public override bool OnStart()
		{
			// Set the maximum number of concurrent connections 
			ServicePointManager.DefaultConnectionLimit = 12;

			// For information on handling configuration changes
			// see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

			return base.OnStart();
		}
	}
}