'<snippet10>
Imports System
' Step 5: Add the Imports statement for the System.ServiceModel namespace
'<snippet100>
Imports System.ServiceModel
'</snippet100>

Namespace Microsoft.ServiceModel.Samples
    ' Step 6: Define a service contract.
'<snippet101>
    <ServiceContract(Namespace:="http://Microsoft.ServiceModel.Samples")> _
    Public Interface ICalculator
'</snippet101>
'<snippet102>
        <OperationContract()> _
    Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double
        <OperationContract()> _
        Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double
        <OperationContract()> _
        Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double
        <OperationContract()> _
        Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double
'</snippet102>
    End Interface
End Namespace
'</snippet10>
