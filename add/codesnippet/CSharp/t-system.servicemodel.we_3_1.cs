    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        [WebGet]
        long Add(long x, long y);

        [OperationContract]
        [WebGet(UriTemplate = "Sub?x={x}&y={y}")]
        long Subtract(long x, long y);

        [OperationContract]
        [WebGet(UriTemplate = "Mult?x={x}&y={y}", BodyStyle = WebMessageBodyStyle.Bare)]
        long Multiply(long x, long y);

        [OperationContract]
        [WebGet(UriTemplate = "Div?x={x}&y={y}", RequestFormat = WebMessageFormat.Xml)]
        long Divide(long x, long y);

        [OperationContract]
        [WebGet(ResponseFormat= WebMessageFormat.Json)]
        long Mod(long x, long y);
    }