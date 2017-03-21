            // Get message from ServiceDescription.
            Message myMessage1 = myServiceDescription.Messages["AddHttpPostIn"];
            Console.WriteLine("ServiceDescription :"+myMessage1.ServiceDescription);
            string[] myParts = new string[2];
            myParts[0] = "a";
            myParts[1] = "b";
            MessagePart[] myMessageParts = myMessage1.FindPartsByName(myParts);
            Console.WriteLine("Results of FindPartsByName operation:");
            for(int i=0;i<myMessageParts.Length; ++i)
            {
               Console.WriteLine("Part Name: " +myMessageParts[i].Name);
               Console.WriteLine("Part Type: " +myMessageParts[i].Type);
            }