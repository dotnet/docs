// <Snippet2>
using System;

class Example
{
    // Display the individual bytes in the array in hexadecimal.
    public static void DisplayArray(Array arr, string name)
    {
        Console.WindowWidth = 120;
        Console.Write("{0,11}:", name);
        for (int ctr = 0; ctr < arr.Length; ctr++)
        {
            byte[] bytes;
            if (arr is long[])
               bytes = BitConverter.GetBytes((long) arr.GetValue(ctr));
            else
               bytes = BitConverter.GetBytes((short) arr.GetValue(ctr));
            
            foreach (byte byteValue in bytes)
               Console.Write(" {0:X2}", byteValue);
        }
        Console.WriteLine();
    }

    // Display the individual array element values in hexadecimal.
    public static void DisplayArrayValues(Array arr, string name)
    {
        // Get the length of one element in the array.
        int elementLength = Buffer.ByteLength(arr) / arr.Length;
        string formatString = String.Format(" {{0:X{0}}}", 2 * elementLength);
        Console.Write( "{0,11}:", name);
        for (int ctr = 0; ctr < arr.Length; ctr++)
            Console.Write(formatString, arr.GetValue(ctr));

        Console.WriteLine();
    }

    public static void Main( )
    {
        // These are the source and destination arrays for BlockCopy.
        short[] src  = { 258, 259, 260, 261, 262, 263, 264, 
                          265, 266, 267, 268, 269, 270 };
        long[] dest = { 17, 18, 19, 20 };

        // Display the initial value of the arrays in memory.
        Console.WriteLine( "Initial values of arrays:");
        Console.WriteLine("   Array values as Bytes:");
        DisplayArray(src, "src" );
        DisplayArray(dest, "dest");
        Console.WriteLine("   Array values:");
        DisplayArrayValues(src, "src");
        DisplayArrayValues(dest, "dest");
        Console.WriteLine();

        // Copy bytes 5-10 from source to index 7 in destination and display the result.
        Buffer.BlockCopy(src, 5, dest, 7, 6);
        Console.WriteLine("Buffer.BlockCopy(src, 5, dest, 7, 6 )");
        Console.WriteLine("   Array values as Bytes:");
        DisplayArray(src, "src");
        DisplayArray(dest, "dest");
        Console.WriteLine("   Array values:");
        DisplayArrayValues(src, "src");
        DisplayArrayValues(dest, "dest");
        Console.WriteLine();
        
        // Copy bytes 16-20 from source to index 22 in destination and display the result. 
        Buffer.BlockCopy(src, 16, dest, 22, 5);
        Console.WriteLine("Buffer.BlockCopy(src, 16, dest, 22, 5)");
        Console.WriteLine("   Array values as Bytes:");
        DisplayArray(src, "src");
        DisplayArray(dest, "dest");
        Console.WriteLine("   Array values:");
        DisplayArrayValues(src, "src");
        DisplayArrayValues(dest, "dest");
        Console.WriteLine();
         
        // Copy overlapping range of bytes 4-10 to index 5 in source.
        Buffer.BlockCopy(src, 4, src, 5, 7 );
        Console.WriteLine("Buffer.BlockCopy( src, 4, src, 5, 7)");
        Console.WriteLine("   Array values as Bytes:");
        DisplayArray(src, "src");
        DisplayArray(dest, "dest");
        Console.WriteLine("   Array values:");
        DisplayArrayValues(src, "src");
        DisplayArrayValues(dest, "dest");
        Console.WriteLine();
        
        // Copy overlapping range of bytes 16-22 to index 15 in source. 
        Buffer.BlockCopy(src, 16, src, 15, 7);
        Console.WriteLine("Buffer.BlockCopy( src, 16, src, 15, 7)");
        Console.WriteLine("   Array values as Bytes:");
        DisplayArray(src, "src");
        DisplayArray(dest, "dest");
        Console.WriteLine("   Array values:");
        DisplayArrayValues(src, "src");
        DisplayArrayValues(dest, "dest");
    }
}
// The example displays the following output:
//    Initial values of arrays:
//       Array values as Bytes:
//            src: 02 01 03 01 04 01 05 01 06 01 07 01 08 01 09 01 0A 01 0B 01 0C 01 0D 01 0E 01
//           dest: 11 00 00 00 00 00 00 00 12 00 00 00 00 00 00 00 13 00 00 00 00 00 00 00 14 00 00 00 00 00 00 00
//       Array values:
//            src: 0102 0103 0104 0105 0106 0107 0108 0109 010A 010B 010C 010D 010E
//           dest: 0000000000000011 0000000000000012 0000000000000013 0000000000000014
//    
//    Buffer.BlockCopy(src, 5, dest, 7, 6 )
//       Array values as Bytes:
//            src: 02 01 03 01 04 01 05 01 06 01 07 01 08 01 09 01 0A 01 0B 01 0C 01 0D 01 0E 01
//           dest: 11 00 00 00 00 00 00 01 05 01 06 01 07 00 00 00 13 00 00 00 00 00 00 00 14 00 00 00 00 00 00 00
//       Array values:
//            src: 0102 0103 0104 0105 0106 0107 0108 0109 010A 010B 010C 010D 010E
//           dest: 0100000000000011 0000000701060105 0000000000000013 0000000000000014
//    
//    Buffer.BlockCopy(src, 16, dest, 22, 5)
//       Array values as Bytes:
//            src: 02 01 03 01 04 01 05 01 06 01 07 01 08 01 09 01 0A 01 0B 01 0C 01 0D 01 0E 01
//           dest: 11 00 00 00 00 00 00 01 05 01 06 01 07 00 00 00 13 00 00 00 00 00 0A 01 0B 01 0C 00 00 00 00 00
//       Array values:
//            src: 0102 0103 0104 0105 0106 0107 0108 0109 010A 010B 010C 010D 010E
//           dest: 0100000000000011 0000000701060105 010A000000000013 00000000000C010B
//    
//    Buffer.BlockCopy( src, 4, src, 5, 7)
//       Array values as Bytes:
//            src: 02 01 03 01 04 04 01 05 01 06 01 07 08 01 09 01 0A 01 0B 01 0C 01 0D 01 0E 01
//           dest: 11 00 00 00 00 00 00 01 05 01 06 01 07 00 00 00 13 00 00 00 00 00 0A 01 0B 01 0C 00 00 00 00 00
//       Array values:
//            src: 0102 0103 0404 0501 0601 0701 0108 0109 010A 010B 010C 010D 010E
//           dest: 0100000000000011 0000000701060105 010A000000000013 00000000000C010B
//    
//    Buffer.BlockCopy( src, 16, src, 15, 7)
//       Array values as Bytes:
//            src: 02 01 03 01 04 04 01 05 01 06 01 07 08 01 09 0A 01 0B 01 0C 01 0D 0D 01 0E 01
//           dest: 11 00 00 00 00 00 00 01 05 01 06 01 07 00 00 00 13 00 00 00 00 00 0A 01 0B 01 0C 00 00 00 00 00
//       Array values:
//            src: 0102 0103 0404 0501 0601 0701 0108 0A09 0B01 0C01 0D01 010D 010E
//           dest: 0100000000000011 0000000701060105 010A000000000013 00000000000C010B
// </Snippet2>
