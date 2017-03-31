Imports System.ServiceModel

'<snippet0>
<ServiceContract(Namespace:="http://Microsoft.ServiceModel.Samples"), _
XmlSerializerFormat(Style:=OperationFormatStyle.Rpc, _
                    Use:=OperationFormatUse.Encoded)> _
Public Interface IUseAndStyleCalculator

    <OperationContract()> _
    Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double

    <OperationContract()> _
    Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double

    <OperationContract()> _
    Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double

    <OperationContract()> _
    Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double

End Interface
'</snippet0>