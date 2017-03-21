    // Define a service contract. 
    [ServiceContract(Namespace="http://Microsoft.ServiceModel.Samples")]
    public interface IQueueCalculator
    {
        [OperationContract(IsOneWay=true)]
        void Add(double n1, double n2);
        [OperationContract(IsOneWay = true)]
        void Subtract(double n1, double n2);
        [OperationContract(IsOneWay = true)]
        void Multiply(double n1, double n2);
        [OperationContract(IsOneWay = true)]
        void Divide(double n1, double n2);
    }