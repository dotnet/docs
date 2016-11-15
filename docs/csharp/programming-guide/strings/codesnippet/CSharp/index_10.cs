        static void Main()
        {
            string str = "hello";
            string nullStr = null;
            string emptyStr = String.Empty;

            string tempStr = str + nullStr;
            // Output of the following line: hello
            Console.WriteLine(tempStr);

            bool b = (emptyStr == nullStr);
            // Output of the following line: False
            Console.WriteLine(b);

            // The following line creates a new empty string.
            string newStr = emptyStr + nullStr;

            // Null strings and empty strings behave differently. The following
            // two lines display 0.
            Console.WriteLine(emptyStr.Length);
            Console.WriteLine(newStr.Length);
            // The following line raises a NullReferenceException.
            //Console.WriteLine(nullStr.Length);

            // The null character can be displayed and counted, like other chars.
            string s1 = "\x0" + "abc";
            string s2 = "abc" + "\x0";
            // Output of the following line: * abc*
            Console.WriteLine("*" + s1 + "*");
            // Output of the following line: *abc *
            Console.WriteLine("*" + s2 + "*");
            // Output of the following line: 4
            Console.WriteLine(s2.Length);
        }