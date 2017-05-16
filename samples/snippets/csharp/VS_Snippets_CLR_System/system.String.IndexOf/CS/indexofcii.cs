//<snippet1>
// Example for the String.IndexOf( char, int, int ) method.
using System;

class IndexOfCII 
{
    public static void Main() 
    {
        string br1 = 
            "0----+----1----+----2----+----3----+----" +
            "4----+----5----+----6----+----7";
        string br2 = 
            "0123456789012345678901234567890123456789" +
            "0123456789012345678901234567890";
        string str = 
            "ABCDEFGHI abcdefghi ABCDEFGHI abcdefghi " +
            "ABCDEFGHI abcdefghi ABCDEFGHI";

        Console.WriteLine( 
            "This example of String.IndexOf( char, int, int )\n" +
            "generates the following output." );
        Console.WriteLine( 
            "{0}{1}{0}{2}{0}{3}{0}", 
            Environment.NewLine, br1, br2, str );

        FindAllChar( 'A', str );
        FindAllChar( 'a', str );
        FindAllChar( 'I', str );
        FindAllChar( 'i', str );
        FindAllChar( '@', str );
        FindAllChar( ' ', str );
    }

    static void FindAllChar( Char target, String searched )
    {
        Console.Write( 
            "The character '{0}' occurs at position(s): ", 
            target );

        int     startIndex = -1;
        int     hitCount = 0;

        // Search for all occurrences of the target.
        while( true )
        {
            startIndex = searched.IndexOf( 
                target, startIndex + 1, 
                searched.Length - startIndex - 1 );

            // Exit the loop if the target is not found.
            if( startIndex < 0 )
                break;

            Console.Write( "{0}, ", startIndex );
            hitCount++;
        }

        Console.WriteLine( "occurrences: {0}", hitCount );
    }
}

/*
This example of String.IndexOf( char, int, int )
generates the following output.

0----+----1----+----2----+----3----+----4----+----5----+----6----+----7
01234567890123456789012345678901234567890123456789012345678901234567890
ABCDEFGHI abcdefghi ABCDEFGHI abcdefghi ABCDEFGHI abcdefghi ABCDEFGHI

The character 'A' occurs at position(s): 0, 20, 40, 60, occurrences: 4
The character 'a' occurs at position(s): 10, 30, 50, occurrences: 3
The character 'I' occurs at position(s): 8, 28, 48, 68, occurrences: 4
The character 'i' occurs at position(s): 18, 38, 58, occurrences: 3
The character '@' occurs at position(s): occurrences: 0
The character ' ' occurs at position(s): 9, 19, 29, 39, 49, 59, occurrences: 6
*/
//</snippet1>
