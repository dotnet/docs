         If myServiceDescription.Services.Contains(myService) Then
            Console.WriteLine( _
               "The mentioned service Exists at index {0} in the WSDL.", _
               myServiceDescription.Services.IndexOf(myService))
            Dim myServiceArray(myServiceDescription.Services.Count - 1) _
            As Service

            ' Copy the services into an array.
            myServiceDescription.Services.CopyTo(myServiceArray, 0)
            Dim myEnumerator As IEnumerator = myServiceArray.GetEnumerator()
            Console.WriteLine("The names of services in the array are")
            While myEnumerator.MoveNext()
               Dim myService1 As Service = CType(myEnumerator.Current, Service)
               Console.WriteLine(myService1.Name)
            End While
         Else
            Console.WriteLine("Service does not exist in the WSDL.")
         End If