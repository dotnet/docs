         ' Create an extensibility element for a SoapOperationBinding.
         Dim mySoapOperationBinding As New SoapOperationBinding()
         mySoapOperationBinding.Style = SoapBindingStyle.Document
         mySoapOperationBinding.SoapAction = myTargetNamespace & addOperation

         ' Add the extensibility element SoapOperationBinding to 
         ' the OperationBinding.
         addOperationBinding.Extensions.Add(mySoapOperationBinding)