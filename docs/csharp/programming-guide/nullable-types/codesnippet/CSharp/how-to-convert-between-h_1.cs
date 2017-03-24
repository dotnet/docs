            string input = "Hello World!";
            char[] values = input.ToCharArray();
            foreach (char letter in values)
            {
                // Get the integral value of the character.
                int value = Convert.ToInt32(letter);
                // Convert the decimal value to a hexadecimal value in string form.
                string hexOutput = String.Format("{0:X}", value);
                Console.WriteLine("Hexadecimal value of {0} is {1}", letter, hexOutput);
            }
            /* Output:
               Hexadecimal value of H is 48
                Hexadecimal value of e is 65
                Hexadecimal value of l is 6C
                Hexadecimal value of l is 6C
                Hexadecimal value of o is 6F
                Hexadecimal value of   is 20
                Hexadecimal value of W is 57
                Hexadecimal value of o is 6F
                Hexadecimal value of r is 72
                Hexadecimal value of l is 6C
                Hexadecimal value of d is 64
                Hexadecimal value of ! is 21
             */