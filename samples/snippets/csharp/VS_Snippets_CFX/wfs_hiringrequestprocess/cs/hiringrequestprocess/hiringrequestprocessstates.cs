//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.HiringRequest
{
    // Name of the valid states in the Hiring Process Request
    public class HiringRequestProcessStates
    {
        public const string WaitingForManagerApproval = "Waiting for Manager Approval";

        public const string WaitingForDepartmentOwnerApproval = "Waiting for Department Owner Approval";

        public const string WaitingForHrManagersOrCeoApproval = "Waiting for HR Managers Approval";

        public const string InReview = "In Review";
    }
}
