//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System.Activities;

namespace Microsoft.Samples.PersistenceParticipants
{

    public sealed class IncrementStepCount : CodeActivity
    {
        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);
            metadata.AddDefaultExtensionProvider(() => new StepCountExtension());
        }

        protected override void Execute(CodeActivityContext context)
        {
            StepCountExtension stepCountExtension = context.GetExtension<StepCountExtension>();
            stepCountExtension.IncrementStepCount();
        }
    }
}
