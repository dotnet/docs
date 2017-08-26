using System;
using System.Workflow.Activities;

namespace WF3Workflows
{
    public partial class Sequence2 : SequentialWorkflowActivity
    {
        //public TimeSpan duration;

        void MyCode(object sender, EventArgs e)
        {
            Console.WriteLine("hello from the MyCode method");
        }
    }
}
