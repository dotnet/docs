         Dim myServiceDescription As ServiceDescription = _
            ServiceDescription.Read("MathService_VB.wsdl")
         
         Dim myPortTypeCollection As PortTypeCollection = _
            myServiceDescription.PortTypes
         Dim noOfPortTypes As Integer = myServiceDescription.PortTypes.Count
         Console.WriteLine(ControlChars.Newline & _
            "Total number of PortTypes: " & noOfPortTypes.ToString())
         
         Dim myNewPortType As PortType = myPortTypeCollection("MathServiceSoap")
         ' Get the index in the collection.
         Dim index As Integer = myPortTypeCollection.IndexOf(myNewPortType)
         Console.WriteLine("Removing the PortType named " & _
            myNewPortType.Name)

         ' Remove the PortType from the collection.
         myPortTypeCollection.Remove(myNewPortType)
         noOfPortTypes = myServiceDescription.PortTypes.Count
         Console.WriteLine(ControlChars.Newline & _
            "Total number of PortTypes: " & noOfPortTypes.ToString())

         ' Check whether the PortType exists in the collection.
         Dim bContains As Boolean = myPortTypeCollection.Contains(myNewPortType)
         Console.WriteLine("Port Type'" & myNewPortType.Name & _
            "' exists: " & bContains.ToString())
         
         Console.WriteLine("Adding the 'PortType'")
         ' Insert a new portType at the index location.
         myPortTypeCollection.Insert(index, myNewPortType)