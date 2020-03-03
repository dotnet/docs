using System;

public class Example
{
    public static void Main()
    {
        // <Snippet3>
        var originalGuid = Guid.NewGuid();
        // Create an array of string representations of the GUID.
        string[] stringGuids = { originalGuid.ToString("B"),
                                 originalGuid.ToString("D"),
                                 originalGuid.ToString("X") };

        // Parse each string representation.
        foreach (var stringGuid in stringGuids)
        {
            try
            {
                Guid newGuid = Guid.Parse(stringGuid);
                Console.WriteLine($"Converted {stringGuid} to a Guid");
            }   
            catch (ArgumentNullException)
            {
                Console.WriteLine("The string to be parsed is null.");   
            }
            catch (FormatException)
            {
                Console.WriteLine($"Bad format: {stringGuid}");
            }
        }

        // The example displays output similar to the following:
        //
        //    Converted {81a130d2-502f-4cf1-a376-63edeb000e9f} to a Guid
        //    Converted 81a130d2-502f-4cf1-a376-63edeb000e9f to a Guid
        //    Converted {0x81a130d2,0x502f,0x4cf1,{0xa3,0x76,0x63,0xed,0xeb,0x00,0x0e,0x9f}} to a Guid
        // </Snippet3>
    }
}
