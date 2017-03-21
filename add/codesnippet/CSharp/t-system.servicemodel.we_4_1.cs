    [ServiceContract]
    public interface ICalculator2
    {
        [OperationContract]
        [WebInvoke]
        long Add(long x, long y);

        [OperationContract]
        [WebInvoke(UriTemplate = "Sub?x={x}&y={y}")]
        long Subtract(long x, long y);

        [OperationContract]
        [WebInvoke(UriTemplate = "Mult?x={x}&y={y}", BodyStyle = WebMessageBodyStyle.Bare)]
        long Multiply(long x, long y);

        [OperationContract]
        [WebInvoke(UriTemplate = "Div?x={x}&y={y}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Xml, ResponseFormat=WebMessageFormat.Xml)]
        long Divide(long x, long y);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Mod?x={x}&y={y}")]
        long Mod(long x, long y);
    }