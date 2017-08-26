using System.Activities;

namespace DelayStateMachine4
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkflowInvoker.Invoke(new MigratedWorkflow());
        }
    }
}
