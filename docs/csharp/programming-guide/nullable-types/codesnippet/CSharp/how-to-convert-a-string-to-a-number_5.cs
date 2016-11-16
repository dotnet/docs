            string inputString = "abc";
            int numValue;
            bool parsed = Int32.TryParse(inputString, out numValue);

            if (!parsed)
                Console.WriteLine("Int32.TryParse could not parse '{0}' to an int.\n", inputString);

            // Output: Int32.TryParse could not parse 'abc' to an int.