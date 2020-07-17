using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Activities.Description;
using System.ServiceModel;
using System.ServiceModel.Activities;
using System.Activities.Statements;
using System.Activities.DurableInstancing;
namespace ConsoleX
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString =
            "Server=.\\SQLEXPRESS;Initial Catalog=Persistence;Integrated Security=SSPI";
            // The Throw class derives from the Activity class, needed to construct a WorkflowServiceHost.
            Throw throwError = new Throw();

            WorkflowServiceHost host = new WorkflowServiceHost(throwError,
            new Uri(@"http://microsoft/services/"));
            //<snippet1>
            // Code to create a WorkFlowServiceHost is not shown here.
            // Note that SqlWorkflowInstanceStore is in the System.Activities.DurableInstancing.dll
            host.DurableInstancingOptions.InstanceStore = new SqlWorkflowInstanceStore(connectionString );
            WorkflowIdleBehavior alteredBehavior =  new WorkflowIdleBehavior();
            // Alter the time to persist and unload.
            alteredBehavior.TimeToPersist = new TimeSpan(0, 4, 0);
            alteredBehavior.TimeToUnload = new TimeSpan(0, 5, 0);
            //Remove the existing behavior and replace it with the new one.
            host.Description.Behaviors.Remove<WorkflowIdleBehavior>();
            host.Description.Behaviors.Add(alteredBehavior);
            //</snippet1>
            Console.WriteLine(alteredBehavior.TimeToUnload.Minutes.ToString());
            //wfsh.Open();
            Console.WriteLine("closed");
            Console.ReadLine();
        }
    }

    [ServiceContract]
    interface ICalculator
    {
        [OperationContract]
        Int32 Add(int a, int b);
    }

    public class Calculator : ICalculator
    {
        public Int32 Add(int a, int b)
        {
            return a + b;
        }
    }
}