            string address = "http://localhost:8001/CalculatorService";

            ServiceEndpoint endpoint = new ServiceEndpoint(
                ContractDescription.GetContract(
                    typeof(ICalculator), 
                    typeof(CalculatorService)), 
                    new WSHttpBinding(), 
                    new EndpointAddress(address));