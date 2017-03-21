        <OperationContract()> _
        <WebInvoke(UriTemplate:="Div?x={x}&y={y}", BodyStyle:=WebMessageBodyStyle.Bare, RequestFormat:=WebMessageFormat.Xml, ResponseFormat:=WebMessageFormat.Xml)> _
        Function Divide(ByVal x As Long, ByVal y As Long) As Long