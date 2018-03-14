using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WebAttributeSnippets
{
    // <Snippet0>
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        [WebGet]
        long Add(long x, long y);

        // <Snippet4>
        [OperationContract]
        [WebGet(UriTemplate = "Sub?x={x}&y={y}")]
        long Subtract(long x, long y);
        // </Snippet4>

        // <Snippet1>
        [OperationContract]
        [WebGet(UriTemplate = "Mult?x={x}&y={y}", BodyStyle = WebMessageBodyStyle.Bare)]
        long Multiply(long x, long y);
        // </Snippet1>

        // <Snippet2>
        [OperationContract]
        [WebGet(UriTemplate = "Div?x={x}&y={y}", RequestFormat = WebMessageFormat.Xml)]
        long Divide(long x, long y);
        // </Snippet2>

        // <Snippet3>
        [OperationContract]
        [WebGet(ResponseFormat= WebMessageFormat.Json)]
        long Mod(long x, long y);
        // </Snippet3>
    }
    // </Snippet0>

    // <Snippet5>
    [ServiceContract]
    public interface ICalculator2
    {
        [OperationContract]
        [WebInvoke]
        long Add(long x, long y);

        // <Snippet9>
        [OperationContract]
        [WebInvoke(UriTemplate = "Sub?x={x}&y={y}")]
        long Subtract(long x, long y);
        // </Snippet9>

        // <Snippet6>
        [OperationContract]
        [WebInvoke(UriTemplate = "Mult?x={x}&y={y}", BodyStyle = WebMessageBodyStyle.Bare)]
        long Multiply(long x, long y);
        // </Snippet6>

        // <Snippet8>
        [OperationContract]
        [WebInvoke(UriTemplate = "Div?x={x}&y={y}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Xml, ResponseFormat=WebMessageFormat.Xml)]
        long Divide(long x, long y);
        // </Snippet8>

        // <Snippet7>
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Mod?x={x}&y={y}")]
        long Mod(long x, long y);
        // </Snippet7>
    }
    // </Snippet5>

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
