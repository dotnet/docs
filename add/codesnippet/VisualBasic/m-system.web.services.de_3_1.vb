            ' Get message from ServiceDescription.
            Dim myMessage1 As Message = myServiceDescription.Messages("AddHttpPostIn")
            Console.WriteLine("ServiceDescription :" + _
                              myMessage1.ServiceDescription.ToString())
            Dim myParts(1) As String
            myParts(0) = "a"
            myParts(1) = "b"
            Dim myMessageParts As MessagePart() = myMessage1.FindPartsByName(myParts)
            Console.WriteLine("Results of FindPartsByName operation:")
            Dim i As Integer
            For i = 0 To myMessageParts.Length - 1
               Console.WriteLine("Part Name: " + myMessageParts(i).Name)
               Console.WriteLine("Part Type: " + myMessageParts(i).Type.ToString())
            Next i