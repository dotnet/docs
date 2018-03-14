//<Snippet1>
// Example for the Exception.HResult property.
using System;

namespace NDP_UE_CS
{
    // Create the derived exception class.
    class SecondLevelException : Exception
    {
        const int SecondLevelHResult = unchecked( (int)0x81234567 );

        // Set HResult for this exception, and include it in 
        // the exception message.
        public SecondLevelException( string message, Exception inner ) :
            base( string.Format( "(HRESULT:0x{1:X8}) {0}", 
                message, SecondLevelHResult ), inner )
        {
            HResult = SecondLevelHResult;
        }
    }

    class HResultDemo 
    {
        public static void Main() 
        {
            Console.WriteLine( 
                "This example of Exception.HResult " +
                "generates the following output.\n" );

            // This function forces a division by 0 and throws 
            // a second exception.
            try
            {
                try
                {
                    int  zero = 0;
                    int  ecks = 1 / zero;
                }
                catch( Exception ex )
                {
                    throw new SecondLevelException( 
                        "Forced a division by 0 and threw " +
                        "a second exception.", ex );
                }
            }
            catch( Exception ex )
            {
                Console.WriteLine( ex.ToString( ) );
            }
        }
    }
}

/*
This example of Exception.HResult generates the following output.

NDP_UE_CS.SecondLevelException: (HRESULT:0x81234567) Forced a division by 0 and
 threw a second exception. ---> System.DivideByZeroException: Attempted to divi
de by zero.
   at NDP_UE_CS.HResultDemo.Main()
   --- End of inner exception stack trace ---
   at NDP_UE_CS.HResultDemo.Main()
*/
//</Snippet1>
