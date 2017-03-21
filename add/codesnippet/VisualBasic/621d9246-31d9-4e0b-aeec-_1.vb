         Dim myServiceDescription As ServiceDescription = _
            ServiceDescription.Read("MathService_VB.wsdl")
         Dim myPortTypeCollection As PortTypeCollection = _
            myServiceDescription.PortTypes
         
         Dim noOfPortTypes As Integer = myServiceDescription.PortTypes.Count
         Console.WriteLine( _
            ControlChars.Newline & "Total number of PortTypes: " & _
            myServiceDescription.PortTypes.Count.ToString())
         
         ' Get the first PortType in the collection.
         Dim myNewPortType As PortType = myPortTypeCollection(0)
         Console.WriteLine( _
            "The PortType at index 0 is: " & myNewPortType.Name)
         Console.WriteLine("Removing the PortType " & myNewPortType.Name)
         
         ' Remove the PortType from the collection.
         myPortTypeCollection.Remove(myNewPortType)

         ' Display the number of PortTypes.
         Console.WriteLine(ControlChars.Newline & _
            "Total number of PortTypes after removing: " & _
            myServiceDescription.PortTypes.Count.ToString())
         
         Console.WriteLine("Adding a PortType " & myNewPortType.Name)

         ' Add a new PortType from the collection.
         myPortTypeCollection.Add(myNewPortType)

         ' Display the number of PortTypes after adding a port.
         Console.WriteLine( _
            "Total Number of PortTypes after adding a new port: " & _
            myServiceDescription.PortTypes.Count.ToString())
         
         myServiceDescription.Write("MathService_New.wsdl")