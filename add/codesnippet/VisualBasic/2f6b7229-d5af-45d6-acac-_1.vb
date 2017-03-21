			Dim calcSvc As New CalculatorService()
			Dim cd3 As ContractDescription = ContractDescription.GetContract(GetType(ICalculator), calcSvc)