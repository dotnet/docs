         Dim myDescription As New ServiceDescription()

         ' Create a StreamReader to read a WSDL file.
         Dim myTextReader = New StreamReader("MyWsdl.wsdl")
         myDescription = ServiceDescription.Read(myTextReader)
         Console.WriteLine("Bindings are: ")

         ' Display the Bindings present in the WSDL file.
         Dim myBinding As Binding
         For Each myBinding In myDescription.Bindings
            Console.WriteLine(myBinding.Name)
         Next myBinding