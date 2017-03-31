using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WebServiceHostSnippets
{
    // <Snippet0>
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "add?x={x}&y={y}")]
        long Add(long x, long y);

        [OperationContract]
        [WebInvoke(UriTemplate = "sub?x={x}&y={y}")]
        long Subtract(long x, long y);

        [OperationContract]
        [WebInvoke(UriTemplate = "mult?x={x}&y={y}")]
        long Multiply(long x, long y);

        [OperationContract]
        [WebInvoke(UriTemplate = "div?x={x}&y={y}")]
        long Divide(long x, long y);

        [OperationContract]
        [WebGet(UriTemplate = "hello?name={name}")]
        string SayHello(string name);
    }

    public class CalcService : ICalculator
    {
        public long Add(long x, long y)
        {
            return x + y;
        }

        public long Subtract(long x, long y)
        {
            return x - y;
        }

        public long Multiply(long x, long y)
        {
            return x * y;
        }

        public long Divide(long x, long y)
        {
            return x / y;
        }

        public string SayHello(string name)
        {
            return "Hello " + name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8000/");

            WebServiceHost svcHost = new WebServiceHost(typeof(CalcService), baseAddress);

            try
            {
                svcHost.Open();

                Console.WriteLine("Service is running");
                Console.WriteLine("Press enter to quit...");
                Console.ReadLine();

                svcHost.Close();
            }
            catch (CommunicationException cex)
            {
                Console.WriteLine("An exception occurred: {0}", cex.Message);
                svcHost.Abort();
            }
        }
    }
    // </Snippet0>
}
