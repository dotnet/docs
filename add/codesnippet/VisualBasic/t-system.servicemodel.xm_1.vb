<ServiceContract(), XmlSerializerFormat(Style := OperationFormatStyle.Rpc, _
   Use := OperationFormatUse.Encoded)>  _
Public Interface ICalculator
    <OperationContract(), XmlSerializerFormat(Style := OperationFormatStyle.Rpc, _
        Use := OperationFormatUse.Encoded)>  _
    Function Add(ByVal a As Double, ByVal b As Double) As Double 
End Interface 