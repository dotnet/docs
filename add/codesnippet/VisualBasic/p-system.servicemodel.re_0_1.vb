            ' Create a new reliable session object
            Dim bindingElement As ReliableSessionBindingElement = New ReliableSessionBindingElement()
            Dim reliableSession As ReliableSession = New ReliableSession(bindingElement)

            ' Now you can access property values
            Console.WriteLine("Ordered: {0}", reliableSession.Ordered)
            Console.WriteLine("InactivityTimeout: {0}", reliableSession.InactivityTimeout)