﻿// <Snippet15>
public class ByteByByteFormatter : IFormatProvider, ICustomFormatter
{
    public object? GetFormat(Type? formatType)
    {
        if (formatType == typeof(ICustomFormatter))
            return this;
        else
            return null;
    }

    public string Format(string? format, object? arg,
                           IFormatProvider? formatProvider)
    {
        if ((formatProvider is not null) && !formatProvider.Equals(this)) return "";

        // Handle only hexadecimal format string.
        if ((format is not null) && !format.StartsWith("X")) return "";

        byte[] bytes;

        // Handle only integral types.
        if (arg is Int16)
            bytes = BitConverter.GetBytes((Int16)arg);
        else if (arg is Int32)
            bytes = BitConverter.GetBytes((Int32)arg);
        else if (arg is Int64)
            bytes = BitConverter.GetBytes((Int64)arg);
        else if (arg is UInt16)
            bytes = BitConverter.GetBytes((UInt16)arg);
        else if (arg is UInt32)
            bytes = BitConverter.GetBytes((UInt32)arg);
        else if (arg is UInt64)
            bytes = BitConverter.GetBytes((UInt64)arg);
        else
            return "";

        string output= "";
        for (int ctr = bytes.Length - 1; ctr >= 0; ctr--)
            output += string.Format("{0:X2} ", bytes[ctr]);

        return output.Trim();
    }
}
// </Snippet15>

// <Snippet16>
public class Example10
{
    public static void Main()
    {
        long value = 3210662321;
        byte value1 = 214;
        byte value2 = 19;

        Console.WriteLine(string.Format(new ByteByByteFormatter(), "{0:X}", value));
        Console.WriteLine(string.Format(new ByteByByteFormatter(), "{0:X} And {1:X} = {2:X} ({2:000})",
                                        value1, value2, value1 & value2));
        Console.WriteLine(string.Format(new ByteByByteFormatter(), "{0,10:N0}", value));
    }
}
// The example displays the following output:
//       00 00 00 00 BF 5E D1 B1
//       00 D6 And 00 13 = 00 12 (018)
//       3,210,662,321
// </Snippet16>
