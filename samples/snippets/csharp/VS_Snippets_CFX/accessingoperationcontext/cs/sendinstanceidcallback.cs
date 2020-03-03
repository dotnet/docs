//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.ServiceModel.Activities;
using System.ServiceModel.Channels;

namespace Microsoft.Samples.AccessingOperationContext.Client
{
    // <Snippet0>
    class SendInstanceIdCallback : ISendMessageCallback
    {
        public const string HeaderName = "InstanceIdHeader";
        public const string HeaderNS = "http://Microsoft.Samples.AccessingOperationContext";

        public Guid InstanceId { get; set; }

        public void OnSendMessage(System.ServiceModel.OperationContext operationContext)
        {
            operationContext.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader(HeaderName, HeaderNS, this.InstanceId));
        }
    }
    // </Snippet0>
}
