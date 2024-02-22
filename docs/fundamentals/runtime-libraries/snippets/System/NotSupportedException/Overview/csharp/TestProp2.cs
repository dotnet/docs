using System;
using System.IO;
using System.Threading.Tasks;

public class TestPropEx2
{
    public static async Task Main()
    {
        String name = @".\TestFile.dat";
        var fs = new FileStream(name,
                                FileMode.Create,
                                FileAccess.Write);
        Console.WriteLine("Filename: {0}, Encoding: {1}",
                          name, await FileUtilities.GetEncodingType(fs));
    }
}

public class FileUtilities
{
    public enum EncodingType
    { None = 0, Unknown = -1, Utf8 = 1, Utf16 = 2, Utf32 = 3 }

    // <Snippet4>
    public static async Task<EncodingType> GetEncodingType(FileStream fs)
    {
        if (!fs.CanRead)
            return EncodingType.Unknown;

        Byte[] bytes = new Byte[4];
        int bytesRead = await fs.ReadAsync(bytes, 0, 4);
        if (bytesRead < 2)
            return EncodingType.None;

        if (bytesRead >= 3 & (bytes[0] == 0xEF && bytes[1] == 0xBB && bytes[2] == 0xBF))
            return EncodingType.Utf8;

        if (bytesRead == 4)
        {
            var value = BitConverter.ToUInt32(bytes, 0);
            if (value == 0x0000FEFF | value == 0xFEFF0000)
                return EncodingType.Utf32;
        }

        var value16 = BitConverter.ToUInt16(bytes, 0);
        if (value16 == (ushort)0xFEFF | value16 == (ushort)0xFFFE)
            return EncodingType.Utf16;

        return EncodingType.Unknown;
    }
}
// The example displays the following output:
//       Filename: .\TestFile.dat, Encoding: Unknown
// </Snippet4>
