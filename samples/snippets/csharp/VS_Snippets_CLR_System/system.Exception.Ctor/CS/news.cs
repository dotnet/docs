//<Snippet2>
// Example for the Exception( string ) constructor.
using System;

namespace NDP_UE_CS
{
    // Derive an exception with a specifiable message.
    class NotEvenException : Exception
    {
        const string notEvenMessage = 
            "The argument to a function requiring " +
            "even input is not divisible by 2.";

        public NotEvenException( ) :
            base( notEvenMessage )
        { }

        public NotEvenException( string auxMessage ) :
            base( String.Format( "{0} - {1}", 
                auxMessage, notEvenMessage ) )
        { }
    }

    class NewSExceptionDemo 
    {
        public static void Main() 
        {
            Console.WriteLine( 
                "This example of the Exception( string )\n" +
                "constructor generates the following output." );
            Console.WriteLine( 
                "\nHere, an exception is thrown using the \n" +
                "constructor of the base class.\n" );

            CalcHalf( 18 );
            CalcHalf( 21 );

            Console.WriteLine( 
                "\nHere, an exception is thrown using the \n" +
                "constructor of a derived class.\n" );

            CalcHalf2( 30 );
            CalcHalf2( 33 );
        }
    	
        // Half throws a base exception if the input is not even.
        static int Half( int input )
        {
            if( input % 2 != 0 )
                throw new Exception( String.Format( 
                    "The argument {0} is not divisible by 2.", 
                    input ) );

            else return input / 2;
        }

        // Half2 throws a derived exception if the input is not even.
        static int Half2( int input )
        {
            if( input % 2 != 0 )
                throw new NotEvenException( 
                    String.Format( "Invalid argument: {0}", input ) );

            else return input / 2;
        }

        // CalcHalf calls Half and catches any thrown exceptions.
        static void CalcHalf(int input )
        {
            try
            {
                int halfInput = Half( input );
                Console.WriteLine( 
                    "Half of {0} is {1}.", input, halfInput );
            }
            catch( Exception ex )
            {
                Console.WriteLine( ex.ToString( ) );
            }
        }

        // CalcHalf2 calls Half2 and catches any thrown exceptions.
        static void CalcHalf2(int input )
        {
            try
            {
                int halfInput = Half2( input );
                Console.WriteLine( 
                    "Half of {0} is {1}.", input, halfInput );
            }
            catch( Exception ex )
            {
                Console.WriteLine( ex.ToString( ) );
            }
        }
    }
}

/*
This example of the Exception( string )
constructor generates the following output.

Here, an exception is thrown using the
constructor of the base class.

Half of 18 is 9.
System.Exception: The argument 21 is not divisible by 2.
   at NDP_UE_CS.NewSExceptionDemo.Half(Int32 input)
   at NDP_UE_CS.NewSExceptionDemo.CalcHalf(Int32 input)

Here, an exception is thrown using the
constructor of a derived class.

Half of 30 is 15.
NDP_UE_CS.NotEvenException: Invalid argument: 33 - The argument to a function r
equiring even input is not divisible by 2.
   at NDP_UE_CS.NewSExceptionDemo.Half2(Int32 input)
   at NDP_UE_CS.NewSExceptionDemo.CalcHalf2(Int32 input)
*/
//</Snippet2>
