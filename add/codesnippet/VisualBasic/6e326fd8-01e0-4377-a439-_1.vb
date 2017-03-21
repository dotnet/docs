        Dim myContractReference As New ContractReference()
        Dim myFileStream As New FileStream("TestOutput_vb.wsdl", _
            FileMode.OpenOrCreate, FileAccess.Write)

        ' Get the ServiceDescription for the test .wsdl file.
        Dim myServiceDescription As ServiceDescription = _
            ServiceDescription.Read("TestInput_vb.wsdl")

        ' Write the ServiceDescription into the file stream.
        myContractReference.WriteDocument(myServiceDescription, myFileStream)
        Console.WriteLine("ServiceDescription is written " + _
            "into the file stream successfully.")
        Console.WriteLine("The number of bytes written into the file stream: " + _
            myFileStream.Length.ToString())
        myFileStream.Close()