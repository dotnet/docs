        <OperationContract()> _
        <WebGet(UriTemplate:="Div?x={x}&y={y}", RequestFormat:=WebMessageFormat.Xml)> _
        Function Divide(ByVal x As Long, ByVal y As Long) As Long