            Console.Write("Enter a character: ");
            char c = (char)Console.Read();
            if (Char.IsLetter(c))
            {
                if (Char.IsLower(c))
                {
                    Console.WriteLine("The character is lowercase.");
                }
                else
                {
                    Console.WriteLine("The character is uppercase.");
                }
            }
            else
            {
                Console.WriteLine("The character isn't an alphabetic character.");
            }

            //Sample Output:

            //Enter a character: 2
            //The character isn't an alphabetic character.

            //Enter a character: A
            //The character is uppercase.

            //Enter a character: h
            //The character is lowercase.