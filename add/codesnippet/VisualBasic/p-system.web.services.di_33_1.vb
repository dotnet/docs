      ' Call the Constructor of ContractReference.
      Dim myContractReference As New ContractReference()
      Dim myXmlDocument As New XmlDocument()
      
      ' Read the discovery document for the 'contractRef' tag.
      myXmlDocument.Load("http://localhost/Discoverydoc.disco")
      
      Dim myXmlRoot As XmlNode = myXmlDocument.FirstChild
      Dim myXmlNode As XmlNode = myXmlRoot("scl:contractRef")
      Dim myAttributeCollection As XmlAttributeCollection = myXmlNode.Attributes
      
      myContractReference.Ref = myAttributeCollection(0).Value
      Console.WriteLine("The URL to the referenced service description is : {0}", myContractReference.Ref)
      myContractReference.DocRef = myAttributeCollection(1).Value
      Console.WriteLine("The URL implementing the referenced service description is : {0}", myContractReference.DocRef)