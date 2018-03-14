//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.ServiceModel;
using System.ServiceModel.Activities;

namespace Microsoft.Samples.AccessingOperationContext.Service
{
    // <Snippet1>
    class ReceiveInstanceIdCallback : IReceiveMessageCallback
    {
        public const string HeaderName = "InstanceIdHeader";
        public const string HeaderNS = "http://Microsoft.Samples.AccessingOperationContext";

        public void OnReceiveMessage(System.ServiceModel.OperationContext operationContext, System.Activities.ExecutionProperties activityExecutionProperties)
        {            
            try
            {
                Guid instanceId = operationContext.IncomingMessageHeaders.GetHeader<Guid>(HeaderName, HeaderNS);
                Console.WriteLine("Received a message from a workflow with instanceId = {0}", instanceId);
            }
            catch (MessageHeaderException)
            {
                Console.WriteLine("This message must not be from a workflow.");
            }
        }
    }
    // </Snippet1>
}
