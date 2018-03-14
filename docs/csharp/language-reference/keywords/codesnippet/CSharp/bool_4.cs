    public class BoolKeyTest
    {
        static void Main()
        {
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
                Console.WriteLine("Not an alphabetic character.");
            }
        }
    }
    /* Sample Output:
        Enter a character: X
        The character is uppercase.
     
        Enter a character: x
        The character is lowercase.

        Enter a character: 2
        The character is not an alphabetic character.
     */