            string testString = "%75";
            int index = 0;
            if (Uri.IsHexEncoding(testString, index))
                 Console.WriteLine("The character is {0}", Uri.HexUnescape(testString, ref index));
            else
                 Console.WriteLine("The character is not hexadecimal encoded");