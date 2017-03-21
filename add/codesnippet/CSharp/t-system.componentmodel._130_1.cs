            Enum myServer= Servers.Exchange;
            string myServerString = "BizTalk";
            Console.WriteLine(TypeDescriptor.GetConverter(myServer).ConvertTo(myServer, typeof(string))); 
            Console.WriteLine(TypeDescriptor.GetConverter(myServer).ConvertFrom(myServerString));    
            