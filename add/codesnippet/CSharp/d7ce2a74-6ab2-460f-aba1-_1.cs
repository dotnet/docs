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