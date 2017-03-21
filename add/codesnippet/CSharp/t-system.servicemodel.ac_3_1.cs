    [ServiceContract(Namespace="http://Microsoft.ServiceModel.Samples")]
    public interface ICalculatorSession
    {
        [OperationContract]
        void Clear();
        [OperationContract]
        void AddTo(double n);
        [OperationContract]
        void SubtractFrom(double n);
        [OperationContract]
        void MultiplyBy(double n);
        [OperationContract]
        void DivideBy(double n);
        [OperationContract]
        double Equals();
    }