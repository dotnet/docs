         ' Create an OutputBinding for the Add operation.
         Dim myOutputBinding As New OutputBinding()
         myOutputBinding.Extensions.Add(mySoapBodyBinding)

         ' Add the OutputBinding to the OperationBinding.
         addOperationBinding.Output = myOutputBinding