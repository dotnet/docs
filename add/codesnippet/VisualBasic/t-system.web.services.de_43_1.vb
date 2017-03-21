   ' Used to create OperationBinding instances within 'Binding'.
   Public Shared Function CreateOperationBinding(operation As String, _
      targetNamespace As String) As OperationBinding

      ' Create OperationBinding for operation.
      Dim myOperationBinding As New OperationBinding()
      myOperationBinding.Name = operation

      ' Create InputBinding for operation.
      Dim myInputBinding As New InputBinding()
      Dim mySoapBodyBinding As New SoapBodyBinding()
      mySoapBodyBinding.Use = SoapBindingUse.Literal
      myInputBinding.Extensions.Add(mySoapBodyBinding)
      ' Create OutputBinding for operation.
      Dim myOutputBinding As New OutputBinding()
      myOutputBinding.Extensions.Add(mySoapBodyBinding)

      ' Add InputBinding and OutputBinding to OperationBinding. 
      myOperationBinding.Input = myInputBinding
      myOperationBinding.Output = myOutputBinding

      ' Create an extensibility element for SoapOperationBinding.
      Dim mySoapOperationBinding As New SoapOperationBinding()
      mySoapOperationBinding.Style = SoapBindingStyle.Document
      mySoapOperationBinding.SoapAction = targetNamespace & operation

      ' Add the extensibility element SoapOperationBinding to OperationBinding.
      myOperationBinding.Extensions.Add(mySoapOperationBinding)
      Return myOperationBinding
   End Function 'CreateOperationBinding
   