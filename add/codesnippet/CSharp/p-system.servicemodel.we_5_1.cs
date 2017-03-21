        [OperationContract]
        [WebInvoke(UriTemplate = "Div?x={x}&y={y}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Xml, ResponseFormat=WebMessageFormat.Xml)]
        long Divide(long x, long y);