            ' Get another message from ServiceDescription.
            Dim myMessage2 As Message = myServiceDescription.Messages("DivideHttpGetOut")
            Dim myMessagePart As MessagePart = myMessage2.FindPartByName("Body")
            Console.WriteLine("Results of FindPartByName operation:")
            Console.WriteLine("Part Name: " + myMessagePart.Name)
            Console.WriteLine("Part Element: " + myMessagePart.Element.ToString())