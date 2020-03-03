using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace wf_activities_project
{
    //<snippet2>
    [ActivityValidator(typeof(ConsoleWriteLineActivityValidator))]
    public partial class ConsoleWriteLineActivity : System.Workflow.ComponentModel.Activity
    {
        public ConsoleWriteLineActivity()
        {
            InitializeComponent();
        }

        public static DependencyProperty MsgProperty = System.Workflow.ComponentModel.DependencyProperty.Register("Msg", typeof(string), typeof(ConsoleWriteLineActivity));

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Msg
        {
            get
            {
                return ((string)(base.GetValue(ConsoleWriteLineActivity.MsgProperty)));
            }
            set
            {
                base.SetValue(ConsoleWriteLineActivity.MsgProperty, value);
            }
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            Console.WriteLine(Msg);
            return ActivityExecutionStatus.Closed;
        }
    }
    //</snippet2>

    //<snippet1>
    class ConsoleWriteLineActivityValidator : ActivityValidator
    {
        //<snippet3>
        public override ValidationErrorCollection Validate(ValidationManager manager, object obj)
        {
            // Invoke the base class method implementation to
            // perform default validation.
            ValidationErrorCollection errors = base.Validate(manager, obj);

            // Make sure there is an activity instance.
            ConsoleWriteLineActivity crw = obj as ConsoleWriteLineActivity;
            if (crw == null)
            {
                throw new InvalidOperationException();
            }

            // If the activity has no parent then this validation
            // is occurring during the compilation of the activity
            // and not during the hosting or creation of an
            // activity instance.
            if (crw.Parent == null)
            {
                // Can skip the rest of the validation because
                // it deals with the hosting and the creation
                // of the activity.
                return errors;
            }

            // Msg is required. Add a validation error if there is no
            // Msg specified or Msg is not bound to another property.
            if (string.IsNullOrEmpty(crw.Msg) &&
                crw.GetBinding(ConsoleWriteLineActivity.MsgProperty) == null)
            {
                //<snippet4>
                errors.Add(new ValidationError("Msg is required", 100, false, "Msg"));
                //</snippet4>
            }

            return errors;
        }
        //</snippet3>
    }
    //</snippet1>
}
