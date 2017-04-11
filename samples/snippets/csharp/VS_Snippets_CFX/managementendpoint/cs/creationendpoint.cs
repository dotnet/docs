//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activities;
using System.ServiceModel.Channels;

namespace Microsoft.Samples.WF.ManagementEndpoint
{

    public class CreationEndpoint : WorkflowHostingEndpoint
    {

        public CreationEndpoint(Binding binding, EndpointAddress address)
            : base(typeof(IWorkflowCreation), binding, address)
        {
            this.IsSystemEndpoint = true;
        }

        protected override WorkflowCreationContext OnGetCreationContext(object[] inputs, OperationContext operationContext, Guid instanceId, WorkflowHostingResponseContext responseContext)
        {
            WorkflowCreationContext creationContext = new WorkflowCreationContext();
            creationContext.CreateOnly = true;
            if (operationContext.IncomingMessageHeaders.Action.EndsWith("Create"))
            {
                Dictionary<string, object> arguments = (Dictionary<string, object>)inputs[0];
                if (arguments != null && arguments.Count > 0)
                {
                    foreach (KeyValuePair<string, object> pair in arguments)
                    {
                        creationContext.WorkflowArguments.Add(pair.Key, pair.Value);
                    }
                }
                responseContext.SendResponse(instanceId, null);
            }
            else if (operationContext.IncomingMessageHeaders.Action.EndsWith("CreateWithInstanceId"))
            {
                Dictionary<string, object> arguments = (Dictionary<string, object>)inputs[0];
                if (arguments != null && arguments.Count > 0)
                {
                    foreach (KeyValuePair<string, object> pair in arguments)
                    {
                        creationContext.WorkflowArguments.Add(pair.Key, pair.Value);
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("Invalid Action: " + operationContext.IncomingMessageHeaders.Action);
            }
            return creationContext;
        }
    }
}

