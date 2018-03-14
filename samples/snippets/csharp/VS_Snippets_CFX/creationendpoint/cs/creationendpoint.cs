//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.ServiceModel;
using System.ServiceModel.Activities;
using System.ServiceModel.Channels;

namespace Microsoft.Samples.WF.CreationEndpoint
{

    public class CreationEndpoint : WorkflowHostingEndpoint
    {
        static Uri defaultBaseUri;

        public CreationEndpoint(Binding binding, EndpointAddress address)
            : base(typeof(IWorkflowCreation), binding, address)
        {
        }

        public CreationEndpoint():this (GetDefaultBinding(), 
                                        new EndpointAddress(new Uri(DefaultBaseUri, new Uri(Guid.NewGuid().ToString(), UriKind.Relative))))
        {
        }

        static Uri DefaultBaseUri
        {
            get
            {
                if (defaultBaseUri == null)
                {                    
                    defaultBaseUri = new Uri(string.Format(CultureInfo.InvariantCulture, "net.pipe://localhost/workflowCreationEndpoint/{0}/{1}",
                        Process.GetCurrentProcess().Id,
                        AppDomain.CurrentDomain.Id));
                }
                return defaultBaseUri;
            }
        }

        //defaults to NetNamedPipeBinding
        public static Binding GetDefaultBinding()
        {
            return new NetNamedPipeBinding(NetNamedPipeSecurityMode.None) { TransactionFlow = true };
        }

// <Snippet0>
        protected override Guid OnGetInstanceId(object[] inputs, OperationContext operationContext)
        {
            //Create was called by client
            if (operationContext.IncomingMessageHeaders.Action.EndsWith("Create"))
            {
                return Guid.Empty;
            }
            //CreateWithInstanceId was called by client
            else if (operationContext.IncomingMessageHeaders.Action.EndsWith("CreateWithInstanceId"))
            {
                return (Guid)inputs[1];
            }
            else
            {
                throw new InvalidOperationException("Invalid Action: " + operationContext.IncomingMessageHeaders.Action);
            }
        }
// </Snippet0>

// <Snippet1>
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
                        //arguments to pass to the workflow
                        creationContext.WorkflowArguments.Add(pair.Key, pair.Value);
                    }
                }
                //reply to client with instanceId
                responseContext.SendResponse(instanceId, null);
            }
            else if (operationContext.IncomingMessageHeaders.Action.EndsWith("CreateWithInstanceId"))
            {
                Dictionary<string, object> arguments = (Dictionary<string, object>)inputs[0];
                if (arguments != null && arguments.Count > 0)
                {
                    foreach (KeyValuePair<string, object> pair in arguments)
                    {
                        //arguments to pass to workflow
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
// </Snippet1>
    }


    //service contract exposed from the endpoint
    [ServiceContract(Name = "IWorkflowCreation")]
    public interface IWorkflowCreation
    {
        [OperationContract(Name = "Create")]
        Guid Create(IDictionary<string, object> inputs);

        [OperationContract(Name = "CreateWithInstanceId", IsOneWay=true)]
        void CreateWithInstanceId(IDictionary<string, object> inputs, Guid instanceId);
    }

}

