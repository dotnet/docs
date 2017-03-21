            myPortCollection = myService.Ports

            ' Create an array of Port objects.
            Console.WriteLine(ControlChars.NewLine & "Port collection :")
            Dim myPortArray(myService.Ports.Count) As Port
            myPortCollection.CopyTo(myPortArray, 0)
            Dim i1 As Integer
            For i1 = 0 to myService.Ports.Count -1
               Console.WriteLine("Port[" & i1.ToString + "] : " & _
                  myPortArray(i1).Name)
            Next
            Dim myIndexPort As Port = myPortCollection(0)
            Console.WriteLine(ControlChars.NewLine + ControlChars.NewLine + _
                              "The index of port '" + myIndexPort.Name + "' is : " + _
                              myPortCollection.IndexOf(myIndexPort).ToString)
            Dim myPortTestInsert As Port = myPortCollection(0)
            myPortCollection.Remove(myPortTestInsert)
            myPortCollection.Insert(0, myPortTestInsert)
            Console.WriteLine(ControlChars.NewLine + ControlChars.NewLine + _
                  "Total Number of Ports after inserting " + "a new port '" + _
                  myPortTestInsert.Name + "' is : " + myService.Ports.Count.ToString)
            While i1 < myService.Ports.Count
               Console.WriteLine("Port[" + i1.ToString + "]  : " + myPortArray(i1).Name)
            End While
            myServiceDescription.Write("MathServiceCopyToNew_vb.wsdl")