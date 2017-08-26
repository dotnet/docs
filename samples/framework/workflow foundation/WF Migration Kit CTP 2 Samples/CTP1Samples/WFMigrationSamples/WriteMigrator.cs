using System;
using System.Activities;
using System.Activities.Statements;
using System.ComponentModel.Composition;
using Microsoft.Workflow.Migration;
using WF3Activities;

namespace WF3ActivityMigrators
{
    public class WriteMigrator : ActivityMigrator<Write>
    {
        // Notify MEF that this migrator exists
        [Export(typeof(ActivityMigrator))]
        Type MigratorType { get { return this.GetType(); } }

        public override Activity Migrate(ActivityMigratorContext context, Write source)
        {
            return new WriteLine
            {
                DisplayName = source.Name,
                Text = context.CreateInArgument<string>(source, Write.InputProperty)
            };
        }
    }
}