      Dim myServiceDescription As ServiceDescription = ServiceDescription.Read("MathService_input.wsdl")
      Console.WriteLine(("Total Number of bindings defined are:" + myServiceDescription.Bindings.Count.ToString()))
      myBinding = myServiceDescription.Bindings(0)
      
      ' Remove the first binding in the collection.
      myServiceDescription.Bindings.Remove(myBinding)
      Console.WriteLine(("Successfully removed binding " + myBinding.Name))
      Console.WriteLine(("Total Number of bindings defined now are:" + myServiceDescription.Bindings.Count.ToString()))
      myServiceDescription.Write("MathService_temp.wsdl")
      ' Add binding to the ServiceDescription instance.
      myServiceDescription.Bindings.Add(myBinding)
      If myServiceDescription.Bindings.Contains(myBinding) Then
         Console.WriteLine(("Successfully added binding " + myBinding.Name))
      End If 
      Console.WriteLine(("Binding was added at index " + myServiceDescription.Bindings.IndexOf(myBinding).ToString()))
      Console.WriteLine(("Total Number of bindings defined now are:" + myServiceDescription.Bindings.Count.ToString()))
      myServiceDescription.Write("MathService_temp1.wsdl")