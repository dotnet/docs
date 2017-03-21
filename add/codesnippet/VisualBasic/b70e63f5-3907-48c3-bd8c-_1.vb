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