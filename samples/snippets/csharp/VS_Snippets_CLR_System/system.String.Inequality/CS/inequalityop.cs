//<snippet1>
// Example for the String Inequality operator.
using System;

class InequalityOp 
{
    public static void Main() 
    {
        Console.WriteLine( 
            "This example of the String Inequality operator\n" +
            "generates the following output.\n" );

        CompareAndDisplay( "ijkl" );
        CompareAndDisplay( "ABCD" );
        CompareAndDisplay( "abcd" );
    }

    static void CompareAndDisplay( String Comparand )
    {
        String  Lower = "abcd";

        Console.WriteLine( 
            "\"{0}\" != \"{1}\" ?  {2}",
            Lower, Comparand, Lower != Comparand );
    }
}

/*
This example of the String Inequality operator
generates the following output.

"abcd" != "ijkl" ?  True
"abcd" != "ABCD" ?  True
"abcd" != "abcd" ?  False
*/
//</snippet1>
