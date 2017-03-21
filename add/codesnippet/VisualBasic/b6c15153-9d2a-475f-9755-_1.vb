            myPortCollection = myService.Ports
            Dim myNewPort As Port = myPortCollection(0)
            myPortCollection.Remove(myNewPort)

            ' Display the number of ports.
            Console.WriteLine(ControlChars.NewLine & _
               "Total number of ports before " & _
               "adding a new port : " & _
               myService.Ports.Count.ToString)

            ' Add a new port.
            myPortCollection.Add(myNewPort)

            ' Display the number of ports after adding a port.
            Console.WriteLine("Total number of ports after " & _
               "adding a new port : " & _
               myService.Ports.Count.ToString)
