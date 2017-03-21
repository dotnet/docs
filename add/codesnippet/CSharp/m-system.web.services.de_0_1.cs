            // Get another message from ServiceDescription.
            Message myMessage2 = myServiceDescription.Messages["DivideHttpGetOut"];
            MessagePart myMessagePart=myMessage2.FindPartByName("Body");
            Console.WriteLine("Results of FindPartByName operation:");
            Console.WriteLine("Part Name: " +myMessagePart.Name);
            Console.WriteLine("Part Element: " +myMessagePart.Element);