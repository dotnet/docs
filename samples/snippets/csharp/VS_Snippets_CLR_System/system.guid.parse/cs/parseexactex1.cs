using System;

public class Example
{
    public static void Main()
    {
        // <Snippet4>
        // Define an array of all format specifiers.
        string[] formats = { "N", "D", "B", "P", "X" };
        Guid guid = Guid.NewGuid();
        // Create an array of valid Guid string representations.
        var stringGuids = new string[formats.Length];
        for (int ctr = 0; ctr < formats.Length; ctr++)
            stringGuids[ctr] = guid.ToString(formats[ctr]);

        // Parse the strings in the array using the "B" format specifier.
        foreach (var stringGuid in stringGuids)
        {
            try
            {
                Guid newGuid = Guid.ParseExact(stringGuid, "B");
                Console.WriteLine($"Successfully parsed {stringGuid}");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("The string to be parsed is null.");
            }
            catch (FormatException)
            {
                Console.WriteLine($"Bad Format: {stringGuid}");
            }
        }     

        // The example displays output similar to the following:
        //
        //    Bad Format: eb5c8c7d187a44e68afb81e854c39457
        //    Bad Format: eb5c8c7d-187a-44e6-8afb-81e854c39457
        //    Successfully parsed {eb5c8c7d-187a-44e6-8afb-81e854c39457}
        //    Bad Format: (eb5c8c7d-187a-44e6-8afb-81e854c39457)
        //    Bad Format: {0xeb5c8c7d,0x187a,0x44e6,{0x8a,0xfb,0x81,0xe8,0x54,0xc3,0x94,0x57}}
        // </Snippet4>
    }
}
