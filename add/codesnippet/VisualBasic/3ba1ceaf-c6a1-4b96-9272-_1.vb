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