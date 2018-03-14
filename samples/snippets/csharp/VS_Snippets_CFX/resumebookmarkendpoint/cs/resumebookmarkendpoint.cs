//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Activities;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activities;
using System.ServiceModel.Channels;

namespace Microsoft.Samples.WF.ResumeBookmarkEndpoint
{

    public class ResumeBookmarkEndpoint : WorkflowHostingEndpoint
    {

        public ResumeBookmarkEndpoint(Binding binding, EndpointAddress address)
            : base(typeof(IWorkflowCreation), binding, address)
        {
        }

        protected override Guid OnGetInstanceId(object[] inputs, OperationContext operationContext)
        {
            //Create called
            if (operationContext.IncomingMessageHeaders.Action.EndsWith("Create"))
            {
                return Guid.Empty;
            }
            //CreateWithInstanceId or ResumeBookmark called. InstanceId is specified by client
            else if (operationContext.IncomingMessageHeaders.Action.EndsWith("CreateWithInstanceId")||
                    operationContext.IncomingMessageHeaders.Action.EndsWith("ResumeBookmark"))
            {
                return (Guid)inputs[0];
            }
            else
            {
                throw new InvalidOperationException("Invalid Action: " + operationContext.IncomingMessageHeaders.Action);
            }
        }


        protected override WorkflowCreationContext OnGetCreationContext(object[] inputs, OperationContext operationContext, Guid instanceId, WorkflowHostingResponseContext responseContext)
        {
            WorkflowCreationContext creationContext = new WorkflowCreationContext();
            if (operationContext.IncomingMessageHeaders.Action.EndsWith("Create"))
            {
                Dictionary<string, object> arguments = (Dictionary<string, object>)inputs[0];
                if (arguments != null && arguments.Count > 0)
                {
                    foreach (KeyValuePair<string, object> pair in arguments)
                    {
                        //arguments for the workflow
                        creationContext.WorkflowArguments.Add(pair.Key, pair.Value);
                    }
                }
                //reply to client with the InstanceId
                responseContext.SendResponse(instanceId, null);
            }
            else if (operationContext.IncomingMessageHeaders.Action.EndsWith("CreateWithInstanceId"))
            {
                Dictionary<string, object> arguments = (Dictionary<string, object>)inputs[0];
                if (arguments != null && arguments.Count > 0)
                {
                    foreach (KeyValuePair<string, object> pair in arguments)
                    {
                        //arguments for the workflow
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

        // <Snippet0>
        protected override Bookmark OnResolveBookmark(object[] inputs, OperationContext operationContext, WorkflowHostingResponseContext responseContext, out object value)
        {
            Bookmark bookmark = null;
            value = null;
            if (operationContext.IncomingMessageHeaders.Action.EndsWith("ResumeBookmark"))
            {
                //bookmark name supplied by client as input to IWorkflowCreation.ResumeBookmark
                bookmark = new Bookmark((string)inputs[1]);
                //value supplied by client as argument to IWorkflowCreation.ResumezBookmark
                value = (string) inputs[2];
            }
            else
            {
                throw new NotImplementedException(operationContext.IncomingMessageHeaders.Action);
            }
            return bookmark;
        }
        // </Snippet0>
    }

    //ServiceContract exposed on the endpoint
    [ServiceContract(Name = "IWorkflowCreation")]
    public interface IWorkflowCreation
    {
        [OperationContract(Name = "Create")]
        Guid Create(IDictionary<string, object> inputs);

        [OperationContract(Name = "CreateWithInstanceId", IsOneWay=true)]
        void CreateWithInstanceId(Guid instanceId, IDictionary<string, object> inputs);

        [OperationContract(Name = "ResumeBookmark", IsOneWay = true)]
        void ResumeBookmark(Guid instanceId, string bookmarkName, string message);

    }

}

