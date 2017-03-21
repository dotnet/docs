         ' Create the 'InputBinding' object for the 'SOAP' protocol.
         Dim myInput As New InputBinding()
         Dim mySoapBinding1 As New SoapBodyBinding()
         mySoapBinding1.PartsString = "parameters"
         mySoapBinding1.Use = SoapBindingUse.Literal
         myInput.Extensions.Add(mySoapBinding1)
         ' Assign the 'InputBinding' to 'OperationBinding'.
         myOperationBinding.Input = myInput
         ' Create the 'OutputBinding' object' for the 'SOAP' protocol..
         Dim myOutput As New OutputBinding()
         myOutput.Extensions.Add(mySoapBinding1)
         ' Assign the 'OutPutBinding' to 'OperationBinding'.
         myOperationBinding.Output = myOutput