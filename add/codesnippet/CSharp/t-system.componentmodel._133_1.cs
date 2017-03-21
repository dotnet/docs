            Guid myGuid = new Guid("B80D56EC-5899-459d-83B4-1AE0BB8418E4");
            string myGuidString = "1AA7F83F-C7F5-11D0-A376-00C04FC9DA04";
            Console.WriteLine(TypeDescriptor.GetConverter(myGuid).ConvertTo(myGuid, typeof(string))); 
            Console.WriteLine(TypeDescriptor.GetConverter(myGuid).ConvertFrom(myGuidString));    