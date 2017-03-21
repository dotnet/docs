int main()
{
   try
   {
      // Create the file stream.
      FileStream^ wsdlStream = gcnew FileStream( "MyService1_cpp.wsdl",FileMode::Open );
      ContractReference^ myContractReference = gcnew ContractReference;
      
      // Read the service description from the passed stream.
      ServiceDescription^ myServiceDescription = dynamic_cast<ServiceDescription^>(myContractReference->ReadDocument( wsdlStream ));
      Console::Write( "Target Namespace for the service description is: {0}", myServiceDescription->TargetNamespace );
      wsdlStream->Close();
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception: {0}", e->Message );
   }
}