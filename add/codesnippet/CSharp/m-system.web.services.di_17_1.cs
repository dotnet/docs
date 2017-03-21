   class MyClass1
   {
      static void Main()
      {
         try
         {
            // Create the file stream.
            FileStream wsdlStream = new FileStream("MyService1_cs.wsdl",
                FileMode.Open);
            ContractReference myContractReference=new ContractReference();

            // Read the service description from the passed stream.
            ServiceDescription myServiceDescription=
                (ServiceDescription)myContractReference.ReadDocument(wsdlStream);
            Console.Write("Target Namespace for the service description is: "
                + myServiceDescription.TargetNamespace);
            wsdlStream.Close();
         }
         catch(Exception e)
         {
            Console.WriteLine("Exception: "+e.Message);
         }
      }
   }