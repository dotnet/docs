         Dim myPortTypeCollection As PortTypeCollection
         
         Dim myServiceDescription As ServiceDescription = _
            ServiceDescription.Read("MathService_VB.wsdl")
         myPortTypeCollection = myServiceDescription.PortTypes
         Dim noOfPortTypes As Integer = myServiceDescription.PortTypes.Count
         Console.WriteLine( _
            ControlChars.NewLine + "Total number of PortTypes: " & _
            myServiceDescription.PortTypes.Count.ToString())

         ' Copy the collection into an array.
         Dim myPortTypeArray(noOfPortTypes-1) As PortType
         myPortTypeCollection.CopyTo(myPortTypeArray, 0)

         ' Display names of all PortTypes.
         Dim i As Integer
         For i = 0 To noOfPortTypes - 1
            Console.WriteLine("PortType Name: " + myPortTypeArray(i).Name)
         Next i
         myServiceDescription.Write("MathService_New.wsdl")