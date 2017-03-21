	' Define a service contract. 
	<ServiceContract(Namespace:="http://Microsoft.ServiceModel.Samples")> _
	Public Interface IQueueCalculator
		<OperationContract(IsOneWay:=True)> _
		Sub Add(ByVal n1 As Double, ByVal n2 As Double)
		<OperationContract(IsOneWay := True)> _
		Sub Subtract(ByVal n1 As Double, ByVal n2 As Double)
		<OperationContract(IsOneWay := True)> _
		Sub Multiply(ByVal n1 As Double, ByVal n2 As Double)
		<OperationContract(IsOneWay := True)> _
		Sub Divide(ByVal n1 As Double, ByVal n2 As Double)
	End Interface