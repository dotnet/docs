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