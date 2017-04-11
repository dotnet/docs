using System;
using System.ServiceModel;

namespace UE.Samples
{
    // <Snippet2>
    [ServiceContract()]
    public interface ISayHello
    {
        [OperationContract()]
        string SayHello();
    }

    public class HelloService : ISayHello
    {
        public string SayHello()
        {
            return "Hello, WCF!";
        }
    }
    // </Snippet2>
}
