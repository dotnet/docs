using System;
using System.Workflow.ComponentModel;

namespace WF3Activities
{
    public class Write : Activity
    {
        public static readonly DependencyProperty InputProperty
            = DependencyProperty.Register("Input", typeof(string), typeof(Write));

        public string Input
        {
            get { return (string)base.GetValue(InputProperty); }
            set { base.SetValue(InputProperty, value); }
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext context)
        {
            Console.WriteLine(this.Input);
            return ActivityExecutionStatus.Closed;
        }
    }
}