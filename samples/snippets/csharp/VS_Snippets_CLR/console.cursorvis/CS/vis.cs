//<snippet1>
// This example demonstrates the Console.CursorVisible property.

using System;

class Sample 
{
    public static void Main() 
    {
    string m1 = "\nThe cursor is {0}.\nType any text then press Enter. " +
                "Type '+' in the first column to show \n" +
                "the cursor, '-' to hide the cursor, " +
                "or lowercase 'x' to quit:";
    string s;
    bool saveCursorVisibile;
    int  saveCursorSize;
//
    Console.CursorVisible = true; // Initialize the cursor to visible.
    saveCursorVisibile = Console.CursorVisible;
    saveCursorSize  = Console.CursorSize;
    Console.CursorSize = 100;     // Emphasize the cursor.

    while(true) 
        {
        Console.WriteLine(m1, 
                         ((Console.CursorVisible == true) ? 
                           "VISIBLE" : "HIDDEN"));
        s = Console.ReadLine();
        if (String.IsNullOrEmpty(s) == false) 
            if (s[0] == '+')
                Console.CursorVisible = true;
            else if (s[0] == '-')
                Console.CursorVisible = false;
            else if (s[0] == 'x')
                break;
        }
    Console.CursorVisible = saveCursorVisibile;
    Console.CursorSize    = saveCursorSize;
    }

}
/*
This example produces the following results. Note that these results
cannot depict cursor visibility. You must run the example to see the 
cursor behavior:

The cursor is VISIBLE.
Type any text then press Enter. Type '+' in the first column to show
the cursor, '-' to hide the cursor, or lowercase 'x' to quit:
The quick brown fox

The cursor is VISIBLE.
Type any text then press Enter. Type '+' in the first column to show
the cursor, '-' to hide the cursor, or lowercase 'x' to quit:
-

The cursor is HIDDEN.
Type any text then press Enter. Type '+' in the first column to show
the cursor, '-' to hide the cursor, or lowercase 'x' to quit:
jumps over

The cursor is HIDDEN.
Type any text then press Enter. Type '+' in the first column to show
the cursor, '-' to hide the cursor, or lowercase 'x' to quit:
+

The cursor is VISIBLE.
Type any text then press Enter. Type '+' in the first column to show
the cursor, '-' to hide the cursor, or lowercase 'x' to quit:
the lazy dog.

The cursor is VISIBLE.
Type any text then press Enter. Type '+' in the first column to show
the cursor, '-' to hide the cursor, or lowercase 'x' to quit:
x

*/
//</snippet1>