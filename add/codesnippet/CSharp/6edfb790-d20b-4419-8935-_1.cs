            int value = 321;
            string strValue = converter.ConvertValueToString(value, typeof(Int32));
            Console.WriteLine("the value = {0}, the string representation of the value = {1}", value, strValue);