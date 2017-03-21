         ' Create a StreamReader to read a WSDL file.
         Dim myStreamReader As New StreamReader("MyWsdl.wsdl")
         Dim myDescription As ServiceDescription = _
            ServiceDescription.Read(myStreamReader)
         Console.WriteLine("Bindings are :")

         ' Display the Bindings present in the WSDL file.
         Dim myBinding As Binding
         For Each myBinding In myDescription.Bindings
            Console.WriteLine(myBinding.Name)
         Next myBinding