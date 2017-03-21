   Class MyClass1
      
      Shared Sub Main()
         Try
            ' Create the file stream.
            Dim wsdlStream As _
                New FileStream("MyService1_vb.wsdl", FileMode.Open)
            Dim myContractReference As New ContractReference()

            ' Read the service description from the passed stream.
            Dim myServiceDescription As ServiceDescription = _
                CType(myContractReference.ReadDocument(wsdlStream), _
                ServiceDescription)
            Console.Write(("Target Namesapce for the service description is: " _
                + myServiceDescription.TargetNamespace))
            wsdlStream.Close()

         Catch e As Exception
            Console.WriteLine(("Exception: " + e.Message))
         End Try
      End Sub 'Main
   End Class 'MyClass1