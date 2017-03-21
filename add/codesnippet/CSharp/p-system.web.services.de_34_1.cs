      // Create a new XmlTextWriter with specified URL.
      XmlTextReader myXmlReader = new XmlTextReader("All_CS.wsdl");
      ServiceDescription myServiceDescription = 
         ServiceDescription.Read(myXmlReader);
      myServiceDescription.TargetNamespace = "http://tempuri.org/";

      // Remove the service named MathService.
      ServiceCollection myServiceDescriptionCollection =
         myServiceDescription.Services;
      myServiceDescriptionCollection.Remove(
         myServiceDescription.Services["MathService"]);