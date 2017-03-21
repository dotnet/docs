    [ServiceContract, DataContractFormat(Style = OperationFormatStyle.Rpc)]
    interface ICalculator
    {
        [OperationContract, DataContractFormat(Style = OperationFormatStyle.Rpc)]
        double Add(double a, double b);

        [OperationContract, DataContractFormat(Style = OperationFormatStyle.Document)]            
        double Subtract(double a, double b);
    }