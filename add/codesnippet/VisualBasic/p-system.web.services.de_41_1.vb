      ' Read a ServiceDescription from existing WSDL.
      Dim myServiceDescription As ServiceDescription = _
         ServiceDescription.Read("Input.vb.wsdl")
      myServiceDescription.TargetNamespace = "http://tempuri.org/"