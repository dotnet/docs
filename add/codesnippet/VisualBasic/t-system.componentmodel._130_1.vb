            Dim myServer As Servers = Servers.Exchange
            Dim myServerString As string = "BizTalk"
            Console.WriteLine(TypeDescriptor.GetConverter(myServer).ConvertTo(myServer, GetType(String))) 
            Console.WriteLine(TypeDescriptor.GetConverter(myServer).ConvertFrom(myServerString))	
            			