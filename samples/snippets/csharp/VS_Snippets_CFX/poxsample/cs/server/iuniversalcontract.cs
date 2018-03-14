using System;
using System.ServiceModel.Channels;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

namespace Microsoft.ServiceModel.Samples
{
    [ServiceContract]
    public interface IUniversalContract
    {
        [OperationContract(Action = "*", ReplyAction = "*")]
        Message ProcessMessage(Message input);
    }
}
