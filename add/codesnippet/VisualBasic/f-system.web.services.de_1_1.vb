      Dim mySoapBinding As New SoapBinding()
      mySoapBinding.Transport = "http://schemas.xmlsoap.org/soap/http"
      mySoapBinding.Style = SoapBindingStyle.Document
      ' Get the URI for XML namespace of the SoapBinding class.
      Dim myNameSpace As String = SoapBinding.Namespace
      Console.WriteLine("The URI of the XML Namespace is :" + myNameSpace)