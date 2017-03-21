            // Display the date and time that the ServicePoint was last 
            // connected to a host.
            Console.WriteLine ("IdleSince = " + sp.IdleSince.ToString ());

            // Display the maximum length of time that the ServicePoint instance  
            // is allowed to maintain an idle connection to an Internet  
            // resource before it is recycled for use in another connection.
            Console.WriteLine ("MaxIdleTime = " + sp.MaxIdleTime);
