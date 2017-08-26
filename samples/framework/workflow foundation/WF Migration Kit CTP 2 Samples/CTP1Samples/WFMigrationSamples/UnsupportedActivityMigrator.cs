using System;
using System.Activities;
using System.ComponentModel.Composition;
using Microsoft.Workflow.Migration;

namespace WF3ActivityMigrators
{
    // This is a generalized migrator for unsupported WF3 activities
    public class UnsupportedActivityMigrator : ActivityMigrator<System.Workflow.ComponentModel.Activity>
    {
        // Notify MEF that this migrator exists
        [Export(typeof(ActivityMigrator))]
        Type MigratorType { get { return this.GetType(); } }

        public override bool CanMigrate(System.Workflow.ComponentModel.Activity source)
        {
            // return true for other types as needed
            return source.GetType().Equals(typeof(System.Workflow.Activities.CodeActivity));
        }

        public override Activity Migrate(ActivityMigratorContext context, 
            System.Workflow.ComponentModel.Activity source)
        {
            string error = "Cannot migrate source activity '" + source.Name + "' of type " +
                (context.Verbose ? source.GetType().FullName : source.GetType().Name);

            context.LogError(error);
            return new ReportMigrationError { Error = error };
        }
    }
}