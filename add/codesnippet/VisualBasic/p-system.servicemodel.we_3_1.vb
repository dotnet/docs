        <OperationContract()> _
        <WebGet(UriTemplate:="Mult?x={x}&y={y}", BodyStyle:=WebMessageBodyStyle.Bare)> _
        Function Multiply(ByVal x As Long, ByVal y As Long) As Long