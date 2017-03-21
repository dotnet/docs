   // Call the Constructor of ContractReference.
   ContractReference^ myContractReference = gcnew ContractReference;
   XmlDocument^ myXmlDocument = gcnew XmlDocument;
   
   // Read the discovery document for the 'contractRef' tag.
   myXmlDocument->Load( "http://localhost/Discoverydoc.disco" );
   XmlNode^ myXmlRoot = myXmlDocument->FirstChild;
   XmlNode^ myXmlNode = myXmlRoot[ "scl:contractRef" ];
   XmlAttributeCollection^ myAttributeCollection = myXmlNode->Attributes;
   myContractReference->Ref = myAttributeCollection[ 0 ]->Value;
   Console::WriteLine( "The URL to the referenced service description is : {0}", myContractReference->Ref );
   myContractReference->DocRef = myAttributeCollection[ 1 ]->Value;
   Console::WriteLine( "The URL implementing the referenced service description is : {0}", myContractReference->DocRef );
   Console::WriteLine( "Namespace for the referenced service description is : {0}", ContractReference::Namespace );