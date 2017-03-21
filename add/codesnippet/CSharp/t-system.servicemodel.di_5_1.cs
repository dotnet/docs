            QueryStringConverter converter = new QueryStringConverter();
            if (converter.CanConvert(typeof(Int32)))
                converter.ConvertStringToValue("123", typeof(Int32));
            int value = 321;
            string strValue = converter.ConvertValueToString(value, typeof(Int32));
            Console.WriteLine("the value = {0}, the string representation of the value = {1}", value, strValue);