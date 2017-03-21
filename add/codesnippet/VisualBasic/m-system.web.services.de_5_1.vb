         ' Create a new XmlTextWriter with specified URL.
         Dim myXmlReader As New XmlTextReader("All_VB.wsdl")
         Dim myServiceDescription As ServiceDescription = _
            ServiceDescription.Read(myXmlReader)
         myServiceDescription.TargetNamespace = "http://tempuri.org/"
         
         ' Remove the service named MathService.
         Dim myServiceDescriptionCollection As ServiceCollection = _
            myServiceDescription.Services
         myServiceDescriptionCollection.Remove( _
            myServiceDescription.Services("MathService"))