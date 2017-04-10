// <Snippet1>
using System;

class GetHashCode 
{
    public static void Main() 
    {
        DisplayHashCode( "" );
        DisplayHashCode( "a" );
        DisplayHashCode( "ab" );
        DisplayHashCode( "abc" );
        DisplayHashCode( "abd" );
        DisplayHashCode( "abe" );
        DisplayHashCode( "abcdef" );
        DisplayHashCode( "abcdeg" );
        DisplayHashCode( "abcdeh" );
        DisplayHashCode( "abcdei" );
        DisplayHashCode( "Abcdeg" );
        DisplayHashCode( "Abcdeh" );
        DisplayHashCode( "Abcdei" );
    }

    static void DisplayHashCode( String Operand )
    {
        int     HashCode = Operand.GetHashCode( );
        Console.WriteLine("The hash code for \"{0}\" is: 0x{1:X8}, {1}",
                          Operand, HashCode );
    }
}
/*
      This example displays output like the following:
      The hash code for "" is: 0x2D2816FE, 757602046
      The hash code for "a" is: 0xCDCAB7BF, -842352705
      The hash code for "ab" is: 0xCDE8B7BF, -840386625
      The hash code for "abc" is: 0x2001D81A, 536991770
      The hash code for "abd" is: 0xC2A94CB5, -1029092171
      The hash code for "abe" is: 0x6550C150, 1699791184
      The hash code for "abcdef" is: 0x1762906D, 392335469
      The hash code for "abcdeg" is: 0x1763906D, 392401005
      The hash code for "abcdeh" is: 0x175C906D, 391942253
      The hash code for "abcdei" is: 0x175D906D, 392007789
      The hash code for "Abcdeg" is: 0x1763954D, 392402253
      The hash code for "Abcdeh" is: 0x175C954D, 391943501
      The hash code for "Abcdei" is: 0x175D954D, 392009037
*/
// </Snippet1>
