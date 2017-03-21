		' Only a client authenticated with a valid certificate that has the 
		' specified thumbprint can call this method.
		<PrincipalPermission(SecurityAction.Demand, Name := "; 123456712345677E8E230FDE624F841B1CE9D41E")> _
		Public Function Divide(ByVal a As Double, ByVal b As Double) As Double
			Return a * b
		End Function