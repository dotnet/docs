         ' Create an InputBinding for the Add operation.
         Dim myInputBinding As New InputBinding()
         Dim mySoapBodyBinding As New SoapBodyBinding()
         mySoapBodyBinding.Use = SoapBindingUse.Literal
         myInputBinding.Extensions.Add(mySoapBodyBinding)

         ' Add the InputBinding to the OperationBinding.
         addOperationBinding.Input = myInputBinding