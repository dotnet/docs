using System;
using System.Activities.DurableInstancing;
using System.Activities.Statements;
using System.ServiceModel;
using System.ServiceModel.Activities;
using System.ServiceModel.Activities.Description;

namespace ConsoleX
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "...";
            // The Throw class derives from the Activity class, needed to construct a WorkflowServiceHost.
            Throw throwError = new Throw();

            WorkflowServiceHost host = new WorkflowServiceHost(throwError, new Uri(@"http://microsoft/services/"));
            //<snippet1>
            // Code to create a WorkFlowServiceHost is not shown here.
            // Note that SqlWorkflowInstanceStore is in the System.Activities.DurableInstancing.dll.
            host.DurableInstancingOptions.InstanceStore = new SqlWorkflowInstanceStore(connectionString);
            WorkflowIdleBehavior alteredBehavior = new WorkflowIdleBehavior
            {
                // Alter the time to persist and unload.
                TimeToPersist = new TimeSpan(0, 4, 0),
                TimeToUnload = new TimeSpan(0, 5, 0)
            };
            //Remove the existing behavior and replace it with the new one.
            host.Description.Behaviors.Remove<WorkflowIdleBehavior>();
            host.Description.Behaviors.Add(alteredBehavior);
            //</snippet1>
            Console.WriteLine(alteredBehavior.TimeToUnload.Minutes.ToString());
            Console.WriteLine("closed");
            Console.ReadLine();
        }
    }

    [ServiceContract]
    interface ICalculator
    {
        [OperationContract]
        int Add(int a, int b);
    }

    public class Calculator : ICalculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}
