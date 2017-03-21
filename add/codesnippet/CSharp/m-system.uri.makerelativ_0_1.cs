            // Create a base Uri.
            Uri address1 = new Uri("http://www.contoso.com/");

            // Create a new Uri from a string.
            Uri address2 = new Uri("http://www.contoso.com/index.htm?date=today"); 
           
            // Determine the relative Uri.  
            Console.WriteLine("The difference is {0}", address1.MakeRelativeUri(address2));