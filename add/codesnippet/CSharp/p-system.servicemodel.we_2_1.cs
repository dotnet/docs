        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Mod?x={x}&y={y}")]
        long Mod(long x, long y);