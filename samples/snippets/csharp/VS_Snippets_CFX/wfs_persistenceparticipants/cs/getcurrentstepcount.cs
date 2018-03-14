//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------


using System.Activities;

namespace Microsoft.Samples.PersistenceParticipants
{

    public sealed class GetCurrentStepCount : CodeActivity<int>
    {
        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);
            metadata.AddDefaultExtensionProvider(() => new StepCountExtension());
        }

        protected override int Execute(CodeActivityContext context)
        {
            StepCountExtension stepCountExtension = context.GetExtension<StepCountExtension>();
            return stepCountExtension.CurrentCount;
        }
    }
}
