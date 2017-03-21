            // Write a message to the file dependent upon
            // the value of the TotalBytes property.
            if (Request.TotalBytes > 1000)
            {
                sw.WriteLine("The request is 1KB or greater");
            }
            else
            {
                sw.WriteLine("The request is less than 1KB");
            }