            ' Obtain the ServiceDescription of existing Wsdl.
            Dim myDescription As ServiceDescription = ServiceDescription.Read("MyWsdl_VB.wsdl")
            ' Remove the Binding from the Binding Collection of ServiceDescription.
            Dim myBindingCollection As BindingCollection = myDescription.Bindings
            myBindingCollection.Remove(myBindingCollection(0))

            ' Form a new Binding.
            Dim myBinding As New Binding()
            myBinding.Name = "Service1Soap"
            Dim myXmlQualifiedName As New XmlQualifiedName("s0:Service1Soap")
            myBinding.Type = myXmlQualifiedName

            Dim mySoapBinding As New SoapBinding()
            mySoapBinding.Transport = "http://schemas.xmlsoap.org/soap/http"
            mySoapBinding.Style = SoapBindingStyle.Document

            Dim addOperationBinding As OperationBinding = CreateOperationBinding("Add", _
                                                         myDescription.TargetNamespace)
            myBinding.Operations.Add(addOperationBinding)
            myBinding.Extensions.Add(mySoapBinding)

            ' Add the Binding to the ServiceDescription.
            myDescription.Bindings.Add(myBinding)
            myDescription.Write("MyOutWsdl.wsdl")