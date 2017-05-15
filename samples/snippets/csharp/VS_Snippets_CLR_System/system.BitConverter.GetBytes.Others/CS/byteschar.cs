//<Snippet2>
// Example of the BitConverter.GetBytes( char ) method.
using System;

class GetBytesCharDemo
{
    const string formatter = "{0,10}{1,16}";
 
    // Convert a char argument to a byte array and display it.
    public static void GetBytesChar( char argument )
    {
        byte[ ] byteArray = BitConverter.GetBytes( argument );
        Console.WriteLine( formatter, argument, 
            BitConverter.ToString( byteArray ) );
    }
       
    public static void Main( )
    {
        Console.WriteLine( 
            "This example of the BitConverter.GetBytes( char ) " +
            "\nmethod generates the following output.\r\n" );
        Console.WriteLine( formatter, "char", "byte array" );
        Console.WriteLine( formatter, "----", "----------" );
          
        // Convert char values and display the results.
        GetBytesChar( '\0' );
        GetBytesChar( ' ' );
        GetBytesChar( '*' );
        GetBytesChar( '3' );
        GetBytesChar( 'A' );
        GetBytesChar( '[' );
        GetBytesChar( 'a' );
        GetBytesChar( '{' );
    }
}

/*
This example of the BitConverter.GetBytes( char )
method generates the following output.

      char      byte array
      ----      ----------
                     00-00
                     20-00
         *           2A-00
         3           33-00
         A           41-00
         [           5B-00
         a           61-00
         {           7B-00
*/
//</Snippet2>
