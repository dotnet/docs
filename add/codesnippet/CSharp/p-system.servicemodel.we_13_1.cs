        [OperationContract]
        [WebInvoke(UriTemplate = "Mult?x={x}&y={y}", BodyStyle = WebMessageBodyStyle.Bare)]
        long Multiply(long x, long y);