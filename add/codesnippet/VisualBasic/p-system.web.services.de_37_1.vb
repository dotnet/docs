      ' Create SOAP Extensibility element.
      Dim mySoapBinding As New SoapBinding()
      ' SOAP over Http.

      mySoapBinding.Transport = "http://schemas.xmlsoap.org/soap/http"
      mySoapBinding.Style = SoapBindingStyle.Document
      ' Add tag soap:binding as an extensibility element.
      myBinding.Extensions.Add(mySoapBinding)