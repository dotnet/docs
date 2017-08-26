using System;
using System.Workflow.ComponentModel;

namespace WF3Activities
{
    public class GetDuration : Activity
    {
        public static readonly DependencyProperty ResultProperty
            = DependencyProperty.Register("Result", typeof(TimeSpan), typeof(GetDuration));

        public TimeSpan Result
        {
            get { return (TimeSpan)base.GetValue(ResultProperty); }
            set { base.SetValue(ResultProperty, value); }
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext context)
        {
            this.Result = TimeSpan.FromSeconds(3);
            return ActivityExecutionStatus.Closed;
        }
    }
}