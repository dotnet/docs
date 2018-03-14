            Console.Write("Enter a character: ");
            char ch = (char)Console.Read();

            if (Char.IsUpper(ch))
            {
                Console.WriteLine("The character is an uppercase letter.");
            }
            else if (Char.IsLower(ch))
            {
                Console.WriteLine("The character is a lowercase letter.");
            }
            else if (Char.IsDigit(ch))
            {
                Console.WriteLine("The character is a number.");
            }
            else
            {
                Console.WriteLine("The character is not alphanumeric.");
            }

            //Sample Input and Output:
            //Enter a character: E
            //The character is an uppercase letter.

            //Enter a character: e
            //The character is a lowercase letter.

            //Enter a character: 4
            //The character is a number.

            //Enter a character: =
            //The character is not alphanumeric.