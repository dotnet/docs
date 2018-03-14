//<Snippet1>
// Example of BitConverter class methods.
using System;

class BitConverterDemo
{
    public static void Main( )
    {
        const string formatter = "{0,25}{1,30}";
 
        double  aDoubl  = 0.1111111111111111111;
        float   aSingl  = 0.1111111111111111111F;
        long    aLong   = 1111111111111111111;
        int     anInt   = 1111111111;
        short   aShort  = 11111;
        char    aChar   = '*';
        bool    aBool   = true;

        Console.WriteLine( 
            "This example of methods of the BitConverter class" +
            "\ngenerates the following output.\n" );
        Console.WriteLine( formatter, "argument", "byte array" );
        Console.WriteLine( formatter, "--------", "----------" );

        // Convert values to Byte arrays and display them.
        Console.WriteLine( formatter, aDoubl, 
            BitConverter.ToString( BitConverter.GetBytes( aDoubl ) ) );
        Console.WriteLine( formatter, aSingl, 
            BitConverter.ToString( BitConverter.GetBytes( aSingl ) ) );
        Console.WriteLine( formatter, aLong, 
            BitConverter.ToString( BitConverter.GetBytes( aLong ) ) );
        Console.WriteLine( formatter, anInt, 
            BitConverter.ToString( BitConverter.GetBytes( anInt ) ) );
        Console.WriteLine( formatter, aShort, 
            BitConverter.ToString( BitConverter.GetBytes( aShort ) ) );
        Console.WriteLine( formatter, aChar, 
            BitConverter.ToString( BitConverter.GetBytes( aChar ) ) );
        Console.WriteLine( formatter, aBool, 
            BitConverter.ToString( BitConverter.GetBytes( aBool ) ) );
    }
}

/*
This example of methods of the BitConverter class
generates the following output.

                 argument                    byte array
                 --------                    ----------
        0.111111111111111       1C-C7-71-1C-C7-71-BC-3F
                0.1111111                   39-8E-E3-3D
      1111111111111111111       C7-71-C4-2B-AB-75-6B-0F
               1111111111                   C7-35-3A-42
                    11111                         67-2B
                        *                         2A-00
                     True                            01
*/
//</Snippet1>
