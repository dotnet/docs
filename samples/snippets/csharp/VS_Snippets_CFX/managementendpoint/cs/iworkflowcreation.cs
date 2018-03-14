//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Microsoft.Samples.WF.ManagementEndpoint
{

    [ServiceContract(Name = "IWorkflowCreation")]
    public interface IWorkflowCreation
    {
        [OperationContract(Name = "Create")]
        Guid CreateSuspended(IDictionary<string, object> inputs);

        [OperationContract(Name = "CreateWithInstanceId", IsOneWay=true)]
        void CreateSuspendedWithInstanceId(IDictionary<string, object> inputs, Guid instanceId);
    }

}

