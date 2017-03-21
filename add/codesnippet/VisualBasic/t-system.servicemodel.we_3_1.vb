    <ServiceContract()> _
    Public Interface ICalculator
        <OperationContract()> _
        <WebGet()> _
        Function Add(ByVal x As Long, ByVal y As Long) As Long

        <OperationContract()> _
        <WebGet(UriTemplate:="Sub?x={x}&y={y}")> _
        Function Subtract(ByVal x As Long, ByVal y As Long) As Long

        <OperationContract()> _
        <WebGet(UriTemplate:="Mult?x={x}&y={y}", BodyStyle:=WebMessageBodyStyle.Bare)> _
        Function Multiply(ByVal x As Long, ByVal y As Long) As Long

        <OperationContract()> _
        <WebGet(UriTemplate:="Div?x={x}&y={y}", RequestFormat:=WebMessageFormat.Xml)> _
        Function Divide(ByVal x As Long, ByVal y As Long) As Long

        <OperationContract()> _
        <WebGet(ResponseFormat:=WebMessageFormat.Json)> _
        Function Modulo(ByVal x As Long, ByVal y As Long) As Long
    End Interface