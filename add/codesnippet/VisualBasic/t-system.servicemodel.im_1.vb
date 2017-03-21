		<OperationBehavior(Impersonation := ImpersonationOption.Required)> _
		Public Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Add
            Dim result = n1 + n2
			Console.WriteLine("Received Add({0},{1})", n1, n2)
			Console.WriteLine("Return: {0}", result)
			DisplayIdentityInformation()
			Return result
		End Function