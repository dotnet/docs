      // Call the Constructor of ContractReference.
      ContractReference myContractReference = new ContractReference();
      XmlDocument myXmlDocument = new XmlDocument();
      
      // Read the discovery document for the 'contractRef' tag.
      myXmlDocument.Load("http://localhost/Discoverydoc.disco");
         
      XmlNode myXmlRoot = myXmlDocument.FirstChild;
      XmlNode myXmlNode = myXmlRoot["scl:contractRef"]; 
      XmlAttributeCollection myAttributeCollection = myXmlNode.Attributes;

      myContractReference.Ref = myAttributeCollection[0].Value;
      Console.WriteLine("The URL to the referenced service description is : {0}",myContractReference.Ref);