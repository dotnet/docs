// <Snippet6>
using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Runtime.Versioning;

public class Example6
{
    [SupportedOSPlatform("windows")]
    public static void Run()
    {
        ResourceReader rdr = new ResourceReader(@".\ContactResources.resources");
        IDictionaryEnumerator dict = rdr.GetEnumerator();
        while (dict.MoveNext())
        {
            Console.WriteLine($"Resource Name: {dict.Key}");
            try
            {
                Console.WriteLine($"   Value: {dict.Value}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("   Exception: A file cannot be found.");
                DisplayResourceInfo(rdr, (string)dict.Key, false);
            }
            catch (FormatException)
            {
                Console.WriteLine("   Exception: Corrupted data.");
                DisplayResourceInfo(rdr, (string)dict.Key, true);
            }
            catch (TypeLoadException)
            {
                Console.WriteLine("   Exception: Cannot load the data type.");
                DisplayResourceInfo(rdr, (string)dict.Key, false);
            }
        }
    }

    [SupportedOSPlatform("windows")]
    private static void DisplayResourceInfo(ResourceReader rr,
                                    string key, bool loaded)
    {
        string dataType = null;
        byte[] data = null;
        rr.GetResourceData(key, out dataType, out data);

        // Display the data type.
        Console.WriteLine($"   Data Type: {dataType}");
        // Display the bytes that form the available data.      
        Console.Write("   Data: ");
        int lines = 0;
        foreach (var dataItem in data)
        {
            lines++;
            Console.Write("{0:X2} ", dataItem);
            if (lines % 25 == 0)
                Console.Write("\n         ");
        }
        Console.WriteLine();
        // Try to recreate current state of data.
        // Do: Bitmap, DateTimeTZI
        switch (dataType)
        {
            // Handle internally serialized string data (ResourceTypeCode members).
            case "ResourceTypeCode.String":
                BinaryReader reader = new BinaryReader(new MemoryStream(data));
                string binData = reader.ReadString();
                Console.WriteLine($"   Recreated Value: {binData}");
                break;
            case "ResourceTypeCode.Int32":
                Console.WriteLine("   Recreated Value: {0}",
                                  BitConverter.ToInt32(data, 0));
                break;
            case "ResourceTypeCode.Boolean":
                Console.WriteLine("   Recreated Value: {0}",
                                  BitConverter.ToBoolean(data, 0));
                break;
            // .jpeg image stored as a stream.
            case "ResourceTypeCode.Stream":
                const int OFFSET = 4;
                int size = BitConverter.ToInt32(data, 0);
                Bitmap value1 = new Bitmap(new MemoryStream(data, OFFSET, size));
                Console.WriteLine($"   Recreated Value: {value1}");
                break;
            default:
                break;
        }
        Console.WriteLine();
    }
}
// </Snippet6>
