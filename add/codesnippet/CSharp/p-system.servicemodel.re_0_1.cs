            // Create a new reliable session object
            ReliableSessionBindingElement bindingElement = new ReliableSessionBindingElement();
            ReliableSession reliableSession = new ReliableSession(bindingElement);

            // Now you can access property values
            Console.WriteLine("Ordered: {0}", reliableSession.Ordered);
            Console.WriteLine("InactivityTimeout: {0}", reliableSession.InactivityTimeout);