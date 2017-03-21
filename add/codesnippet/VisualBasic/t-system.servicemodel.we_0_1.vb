    <ServiceContract()> _
    Public Interface ICalculator
        <OperationContract()> _
        <WebInvoke(UriTemplate:="add?x={x}&y={y}")> _
        Function Add(ByVal x As Long, ByVal y As Long) As Long

        <OperationContract()> _
        <WebInvoke(UriTemplate:="sub?x={x}&y={y}")> _
        Function Subtract(ByVal x As Long, ByVal y As Long) As Long

        <OperationContract()> _
        <WebInvoke(UriTemplate:="mult?x={x}&y={y}")> _
        Function Multiply(ByVal x As Long, ByVal y As Long) As Long

        <OperationContract()> _
        <WebInvoke(UriTemplate:="div?x={x}&y={y}")> _
        Function Divide(ByVal x As Long, ByVal y As Long) As Long

        <OperationContract()> _
        <WebGet(UriTemplate:="hello?name={name}")> _
        Function SayHello(ByVal name As String) As String
    End Interface

    Public Class CalcService
        Implements ICalculator
        Public Function Add(ByVal x As Long, ByVal y As Long) As Long Implements ICalculator.Add
            Return x + y
        End Function

        Public Function Subtract(ByVal x As Long, ByVal y As Long) As Long Implements ICalculator.Subtract
            Return x - y
        End Function

        Public Function Multiply(ByVal x As Long, ByVal y As Long) As Long Implements ICalculator.Multiply
            Return x * y
        End Function

        Public Function Divide(ByVal x As Long, ByVal y As Long) As Long Implements ICalculator.Divide
            Return x / y
        End Function

        Public Function SayHello(ByVal name As String) As String Implements ICalculator.SayHello
            Return "Hello " + name
        End Function
    End Class

