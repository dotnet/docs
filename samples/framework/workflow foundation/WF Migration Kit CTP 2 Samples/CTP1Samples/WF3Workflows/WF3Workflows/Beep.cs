using System.Media;
using System.Workflow.ComponentModel;

namespace WF3Activities
{
    public class Beep : Activity
    {
        protected override ActivityExecutionStatus Execute(ActivityExecutionContext context)
        {
            SystemSounds.Beep.Play();
            return ActivityExecutionStatus.Closed;
        }
    }
}
