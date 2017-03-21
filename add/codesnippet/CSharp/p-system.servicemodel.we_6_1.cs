        [OperationContract]
        [WebGet(UriTemplate = "Div?x={x}&y={y}", RequestFormat = WebMessageFormat.Xml)]
        long Divide(long x, long y);