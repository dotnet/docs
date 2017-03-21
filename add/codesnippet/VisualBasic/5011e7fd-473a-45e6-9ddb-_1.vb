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