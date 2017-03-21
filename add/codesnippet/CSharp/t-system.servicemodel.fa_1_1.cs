  [OperationContractAttribute]
  [FaultContractAttribute(typeof(int))]
  int Divide(int arg1, int arg2);