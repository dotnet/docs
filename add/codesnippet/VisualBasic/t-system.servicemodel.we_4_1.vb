    <ServiceContract()> _
    Public Interface ICalculator2
        <OperationContract()> _
        <WebInvoke()> _
        Function Add(ByVal x As Long, ByVal y As Long) As Long

        <OperationContract()> _
        <WebInvoke(UriTemplate:="Sub?x={x}&y={y}")> _
        Function Subtract(ByVal x As Long, ByVal y As Long) As Long

        <OperationContract()> _
        <WebInvoke(UriTemplate:="Mult?x={x}&y={y}", BodyStyle:=WebMessageBodyStyle.Bare)> _
        Function Multiply(ByVal x As Long, ByVal y As Long) As Long

        <OperationContract()> _
        <WebInvoke(UriTemplate:="Div?x={x}&y={y}", BodyStyle:=WebMessageBodyStyle.Bare, RequestFormat:=WebMessageFormat.Xml, ResponseFormat:=WebMessageFormat.Xml)> _
        Function Divide(ByVal x As Long, ByVal y As Long) As Long

        <OperationContract()> _
       <WebInvoke(Method:="POST", UriTemplate:="Mod?x={x}&y={y}")> _
       Function Modulo(ByVal x As Long, ByVal y As Long) As Long
    End Interface