            TimeSpan ts=new TimeSpan(133333330);
            string myTSStr = "5000000";
            Console.WriteLine(TypeDescriptor.GetConverter(ts).ConvertTo(ts, typeof(string))); 
            Console.WriteLine(TypeDescriptor.GetConverter(ts).ConvertFrom(myTSStr));    