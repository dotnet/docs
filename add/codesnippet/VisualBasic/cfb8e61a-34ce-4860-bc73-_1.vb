      ' Read a ServiceDescription from existing WSDL.
      Dim myServiceDescription As ServiceDescription = _
         ServiceDescription.Read("Input.vb.wsdl")
      myServiceDescription.TargetNamespace = "http://tempuri.org/"

      ' Get the ServiceCollection of the ServiceDescription.
      Dim myServiceCollection As ServiceCollection = _
         myServiceDescription.Services

      ' Remove the Service at index 0 of the collection.
      myServiceCollection.Remove(myServiceDescription.Services.Item(0))