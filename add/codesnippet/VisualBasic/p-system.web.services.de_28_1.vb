      ' Read from an existing wsdl file.
      Dim myServiceDescription As ServiceDescription = ServiceDescription.Read( _
                                                            "MapToProperty_vb.wsdl")
      ' Get the existing binding 
      Dim myBinding As Binding = myServiceDescription.Bindings("MyWebServiceSoap")
      Dim myOperationBinding As OperationBinding = CType(myBinding.Operations(0), _
                                                                    OperationBinding)
      Dim myInputBinding As InputBinding = myOperationBinding.Input
      ' Get the 'SoapHeaderBinding' instance from 'myInputBinding'.
      Dim mySoapHeaderBinding As SoapHeaderBinding = CType(myInputBinding.Extensions(1), _
                                                                     SoapHeaderBinding)
      If mySoapHeaderBinding.MapToProperty Then
         Console.WriteLine("'SoapHeaderBinding' instance is mapped to a " & _
                                          "specific property in proxy generated class")
      Else
         Console.WriteLine("'SoapHeaderBinding' instance is not mapped to " & _
                                          "a specific property in proxy generated class")
      End If