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