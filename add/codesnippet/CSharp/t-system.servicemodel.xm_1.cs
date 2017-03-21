    [ServiceContract, XmlSerializerFormat(Style = OperationFormatStyle.Rpc, 
        Use = OperationFormatUse.Encoded)]
    public interface ICalculator
    {
        [OperationContract, XmlSerializerFormat(Style = OperationFormatStyle.Rpc, 
            Use = OperationFormatUse.Encoded)]
        double Add(double a, double b);
    }