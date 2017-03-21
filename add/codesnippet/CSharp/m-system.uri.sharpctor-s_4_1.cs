            // Create an absolute Uri from a string.
            Uri absoluteUri = new Uri("http://www.contoso.com/");

            // Create a relative Uri from a string.  allowRelative = true to allow for 
            // creating a relative Uri.
            Uri relativeUri = new Uri("/catalog/shownew.htm?date=today", UriKind.Relative);
         
            // Check whether the new Uri is absolute or relative.
            if (!relativeUri.IsAbsoluteUri)
                Console.WriteLine("{0} is a relative Uri.", relativeUri);

            // Create a new Uri from an absolute Uri and a relative Uri.
            Uri combinedUri = new Uri(absoluteUri, relativeUri);
            Console.WriteLine(combinedUri.AbsoluteUri);