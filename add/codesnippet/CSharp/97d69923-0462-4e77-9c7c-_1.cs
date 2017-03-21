    public class myService_M_AuthorizationManager : ServiceAuthorizationManager 
    {
        // set max size for message
        int someMaxSize = 16000;
        protected override bool CheckAccessCore(OperationContext operationContext, ref Message message)
        {
            bool accessAllowed = false;
            MessageBuffer requestBuffer = message.CreateBufferedCopy(someMaxSize);

            // do access checks using the message parameter value and set accessAllowed appropriately
            if (accessAllowed)
            {
                // replace incoming message with fresh copy since accessing the message consumes it
                message = requestBuffer.CreateMessage();
            }
            return accessAllowed;
        }
    }