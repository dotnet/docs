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