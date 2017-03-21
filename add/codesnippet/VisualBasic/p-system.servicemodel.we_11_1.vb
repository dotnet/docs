        <OperationContract()> _
        <WebInvoke(UriTemplate:="Sub?x={x}&y={y}")> _
        Function Subtract(ByVal x As Long, ByVal y As Long) As Long