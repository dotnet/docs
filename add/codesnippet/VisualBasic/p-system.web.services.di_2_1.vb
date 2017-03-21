
         ' 'dataservice.disco' is a sample discovery document.
         Dim myStringUrl As String = "http://localhost/dataservice.disco"

         ' Call the Discover method to populate the Documents property.
         Dim myDiscoveryClientProtocol As DiscoveryClientProtocol = _
             New DiscoveryClientProtocol()
         myDiscoveryClientProtocol.Credentials = _
             CredentialCache.DefaultCredentials
         Dim myDiscoveryDocument As DiscoveryDocument = _
             myDiscoveryClientProtocol.Discover(myStringUrl)

         Console.WriteLine("Demonstrating the Discovery.SoapBinding class.")

         ' Create a SOAP binding.
         Dim mySoapBinding As SoapBinding = New SoapBinding()

         ' Assign the address to the SOAP binding.
         mySoapBinding.Address = "http://schemas.xmlsoap.org/disco/scl/"

         ' Bind the created SOAP binding with a new XmlQualifiedName.
         mySoapBinding.Binding = New XmlQualifiedName("string", _
             "http://www.w3.org/2001/XMLSchema")

         ' Add the created SOAP binding to the DiscoveryClientProtocol.
         myDiscoveryClientProtocol.AdditionalInformation.Add(mySoapBinding)

         ' Display the namespace associated with the SOAP binding.
         Console.WriteLine("Namespace associated with Soap Binding is: " _
             + SoapBinding.Namespace)

         ' Write all the information of the DiscoveryClientProtocol. 
         myDiscoveryClientProtocol.WriteAll(".","results.discomap")
