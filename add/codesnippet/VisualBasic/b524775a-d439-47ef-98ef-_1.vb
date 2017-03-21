			Dim address As String = "http://localhost:8001/CalculatorService"

			Dim endpoint As New ServiceEndpoint(ContractDescription.GetContract(GetType(ICalculator), GetType(CalculatorService)), New WSHttpBinding(), New EndpointAddress(address))