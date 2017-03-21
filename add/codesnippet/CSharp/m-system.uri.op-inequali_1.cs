            // Create some Uris.
            Uri address1 = new Uri("http://www.contoso.com/index.htm#search");
            Uri address2 = new Uri("http://www.contoso.com/index.htm"); 
            Uri address3 = new Uri("http://www.contoso.com/index.htm?date=today"); 

            // The first two are equal because the fragment is ignored.
            if (address1 == address2)
                Console.WriteLine("{0} is equal to {1}", address1.ToString(), address2.ToString());

            // The second two are not equal.
            if (address2 != address3)
                Console.WriteLine("{0} is not equal to {1}", address2.ToString(), address3.ToString());