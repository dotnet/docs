    <ServiceContract(Namespace:="http://Microsoft.ServiceModel.Samples")> _
    Public Interface ICalculatorSession

        <OperationContract()> _
        Sub Clear()
        <OperationContract()> _
        Sub AddTo(ByVal n As Double)
        <OperationContract()> _
        Sub SubtractFrom(ByVal n As Double)
        <OperationContract()> _
        Sub MultiplyBy(ByVal n As Double)
        <OperationContract()> _
        Sub DivideBy(ByVal n As Double)
        <OperationContract()> _
        Function Equal() As Double
    End Interface