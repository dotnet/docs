//<Snippet1>
// Example for the Exception.GetBaseException method.
using System;

namespace NDP_UE_CS
{
    // Define two derived exceptions to demonstrate nested exceptions.
    class SecondLevelException : Exception
    {
        public SecondLevelException( string message, Exception inner )
            : base( message, inner )
        { }
    }
    class ThirdLevelException : Exception
    {
        public ThirdLevelException( string message, Exception inner ) 
            : base( message, inner )
        { }
    }

    class NestedExceptions
    {
        public static void Main() 
        {
            Console.WriteLine( 
                "This example of Exception.GetBaseException " +
                "generates the following output." );
            Console.WriteLine( 
                "\nThe program forces a division by 0, then " +
                "throws the exception \ntwice more, " +
                "using a different derived exception each time.\n" );

            try
            {
                // This function calls another that forces a 
                // division by 0.
                Rethrow( );
            }
            catch( Exception ex )
            {
                Exception current;

                Console.WriteLine( 
                    "Unwind the nested exceptions " +
                    "using the InnerException property:\n" );

                // This code unwinds the nested exceptions using the 
                // InnerException property.
                current = ex;
                while( current != null )
                {
                    Console.WriteLine( current.ToString( ) );
                    Console.WriteLine( );
                    current = current.InnerException;
                }

                // Display the innermost exception.
                Console.WriteLine( 
                    "Display the base exception " +
                    "using the GetBaseException method:\n" );
                Console.WriteLine( 
                    ex.GetBaseException( ).ToString( ) );
            }
        }

        // This function catches the exception from the called 
        // function DivideBy0( ) and throws another in response.
        static void Rethrow()
        {
            try
            {
                DivideBy0( );
            }
            catch( Exception ex )
            {
                throw new ThirdLevelException( 
                    "Caught the second exception and " +
                    "threw a third in response.", ex );
            }
        }

        // This function forces a division by 0 and throws a second 
        // exception.
        static void DivideBy0( )
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
    }
}

/*
This example of Exception.GetBaseException generates the following output.

The program forces a division by 0, then throws the exception
twice more, using a different derived exception each time.

Unwind the nested exceptions using the InnerException property:

NDP_UE_CS.ThirdLevelException: Caught the second exception and threw a third in
 response. ---> NDP_UE_CS.SecondLevelException: Forced a division by 0 and thre
w a second exception. ---> System.DivideByZeroException: Attempted to divide by
 zero.
   at NDP_UE_CS.NestedExceptions.DivideBy0()
   --- End of inner exception stack trace ---
   at NDP_UE_CS.NestedExceptions.DivideBy0()
   at NDP_UE_CS.NestedExceptions.Rethrow()
   --- End of inner exception stack trace ---
   at NDP_UE_CS.NestedExceptions.Rethrow()
   at NDP_UE_CS.NestedExceptions.Main()

NDP_UE_CS.SecondLevelException: Forced a division by 0 and threw a second excep
tion. ---> System.DivideByZeroException: Attempted to divide by zero.
   at NDP_UE_CS.NestedExceptions.DivideBy0()
   --- End of inner exception stack trace ---
   at NDP_UE_CS.NestedExceptions.DivideBy0()
   at NDP_UE_CS.NestedExceptions.Rethrow()

System.DivideByZeroException: Attempted to divide by zero.
   at NDP_UE_CS.NestedExceptions.DivideBy0()

Display the base exception using the GetBaseException method:

System.DivideByZeroException: Attempted to divide by zero.
   at NDP_UE_CS.NestedExceptions.DivideBy0()
*/
//</Snippet1>
