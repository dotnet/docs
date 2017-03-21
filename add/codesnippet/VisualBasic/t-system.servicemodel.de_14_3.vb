		' Only members of the CalculatorClients group can call this method.
		<PrincipalPermission(SecurityAction.Demand, Role := "Users")> _
		Public Function Add(ByVal a As Double, ByVal b As Double) As Double
			Return a + b
		End Function