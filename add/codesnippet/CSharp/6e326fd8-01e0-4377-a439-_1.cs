        ContractReference myContractReference = new ContractReference();
        FileStream myFileStream = new FileStream( "TestOutput_cs.wsdl", 
            FileMode.OpenOrCreate, FileAccess.Write );

        // Get the ServiceDescription for the test .wsdl file.
        ServiceDescription myServiceDescription  =
            ServiceDescription.Read("TestInput_cs.wsdl");

        // Write the ServiceDescription into the file stream.
        myContractReference.WriteDocument(myServiceDescription, myFileStream);
        Console.WriteLine("ServiceDescription is written "
            + "into the file stream successfully.");
        Console.WriteLine("The number of bytes written into the file stream: "
            + myFileStream.Length);
         myFileStream.Close();