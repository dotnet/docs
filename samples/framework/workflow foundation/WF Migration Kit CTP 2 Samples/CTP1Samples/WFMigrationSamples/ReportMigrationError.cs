using System;
using System.Activities;

namespace WF3ActivityMigrators
{
    // WF4 activity that is configured to always raise a validation error
    public class ReportMigrationError : CodeActivity
    {
        public ReportMigrationError()
            : base() { }

        public string Error { get; set; }

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            metadata.AddValidationError(this.Error);
        }

        protected override void Execute(CodeActivityContext context)
        {
            throw new NotImplementedException();
        }
    }
}