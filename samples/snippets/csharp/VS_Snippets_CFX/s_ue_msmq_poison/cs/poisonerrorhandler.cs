using System;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;

namespace Microsoft.ServiceModel.Samples
{
    // <Snippet2>
    class PoisonErrorHandler : IErrorHandler
    {
        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            // No-op -We are not interested in this. This is only useful if you want to send back a fault on the wire…not applicable for queues [one-way].
        }

        public bool HandleError(Exception error)
        {
            if (error != null && error.GetType() == typeof(MsmqPoisonMessageException))
            {
                Console.WriteLine($" Poisoned message -message look up id = {((MsmqPoisonMessageException)error).MessageLookupId}");
                return true;
            }

            return false;
        }
    }
    // </Snippet2>
}
