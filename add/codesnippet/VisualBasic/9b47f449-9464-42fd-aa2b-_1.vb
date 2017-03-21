      ' Create a new Binding for SOAP Protocol.
      Dim myBinding As New Binding()
      myBinding.Name = myServiceDescription.Services(0).Name + "Soap"
      ' Pass the name of the existing porttype 'MathServiceSoap' and the Xml targetNamespace attribute of the Descriptions tag.
      myBinding.Type = New XmlQualifiedName("MathServiceSoap", myServiceDescription.TargetNamespace)
      ' Create SOAP Extensibility element.
      Dim mySoapBinding As New SoapBinding()
      ' SOAP over Http.

      mySoapBinding.Transport = "http://schemas.xmlsoap.org/soap/http"
      mySoapBinding.Style = SoapBindingStyle.Document
      ' Add tag soap:binding as an extensibility element.
      myBinding.Extensions.Add(mySoapBinding)
      ' Create OperationBindings for each of the operations defined in asmx file.
      Dim addOperationBinding As OperationBinding = CreateOperationBinding("Add", myServiceDescription.TargetNamespace)
      myBinding.Operations.Add(addOperationBinding)
      Dim subtractOperationBinding As OperationBinding = CreateOperationBinding("Subtract", myServiceDescription.TargetNamespace)
      myBinding.Operations.Add(subtractOperationBinding)
      Dim multiplyOperationBinding As OperationBinding = CreateOperationBinding("Multiply", myServiceDescription.TargetNamespace)
      myBinding.Operations.Add(multiplyOperationBinding)
      Dim divideOperationBinding As OperationBinding = CreateOperationBinding("Divide", myServiceDescription.TargetNamespace)
      myBinding.Operations.Add(divideOperationBinding)
      myServiceDescription.Bindings.Insert(0, myBinding)