            // Create an instance of the binding to use.
            WSHttpBinding b = new WSHttpBinding();

            // Get the binding element collection.
            BindingElementCollection bec = b.CreateBindingElements();

            // Find the SymmetricSecurityBindingElement in the collection.
            // Important: Cast to the SymmetricSecurityBindingElement when using the Find
            // method.
            SymmetricSecurityBindingElement sbe = (SymmetricSecurityBindingElement)
                bec.Find<SecurityBindingElement>();

            // Get the LocalSecuritySettings from the binding element.
            LocalClientSecuritySettings lc = sbe.LocalClientSettings;

            // Print out values.
            Console.WriteLine("Maximum cookie caching time: {0} days", lc.MaxCookieCachingTime.Days);
            Console.WriteLine("Replay Cache Size: {0}", lc.ReplayCacheSize);
            Console.WriteLine("ReplayWindow: {0} minutes", lc.ReplayWindow.Minutes);
            Console.WriteLine("MaxClockSkew: {0} minutes", lc.MaxClockSkew.Minutes);
            Console.ReadLine();

            // Change the MaxClockSkew to 3 minutes.
            lc.MaxClockSkew = new TimeSpan(0, 0, 3, 0);

            // Print the new value.
            Console.WriteLine("New MaxClockSkew: {0} minutes", lc.MaxClockSkew.Minutes);
            Console.ReadLine();

            // Create an EndpointAddress for the service.
            EndpointAddress ea = new EndpointAddress("http://localhost/calculator");

            // Create a client. The binding has the changed MaxClockSkew.
            // CalculatorClient cc = new CalculatorClient(b, ea);
            // Use the new client. (Not shown.)
            // cc.Close();