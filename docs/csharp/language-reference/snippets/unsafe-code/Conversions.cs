public class ClassConvert
{
    public static void Conversions()
    {
        // <SnippetConversion>
        int number = 1024;

        unsafe
        {
            // Convert to byte:
            byte* p = (byte*)&number;

            System.Console.Write("The 4 bytes of the integer:");

            // Display the 4 bytes of the int variable:
            for (int i = 0 ; i < sizeof(int) ; ++i)
            {
                System.Console.Write(" {0:X2}", *p);
                // Increment the pointer:
                p++;
            }
            System.Console.WriteLine();
            System.Console.WriteLine("The value of the integer: {0}", number);

            /* Output:
                The 4 bytes of the integer: 00 04 00 00
                The value of the integer: 1024
            */
        }
        // </SnippetConversion>
    }
}
