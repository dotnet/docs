//<Snippet3>
// Example for the Exception( string, Exception ) constructor.
using System;

namespace NDP_UE_CS
{
    // Derive an exception with a specifiable message and inner exception.
    class LogTableOverflowException : Exception
    {
        const string overflowMessage = 
            "The log table has overflowed.";

        public LogTableOverflowException( ) :
            base( overflowMessage )
        { }

        public LogTableOverflowException( string auxMessage ) :
            base( String.Format( "{0} - {1}", 
                overflowMessage, auxMessage ) )
        { }

        public LogTableOverflowException( 
            string auxMessage, Exception inner ) :
                base( String.Format( "{0} - {1}", 
                    overflowMessage, auxMessage ), inner )
        { }
    }

    class LogTable
    {
        public LogTable( int numElements )
        {
            logArea = new string[ numElements ];
            elemInUse = 0;
        }

        protected string[ ] logArea;
        protected int       elemInUse;

        // The AddRecord method throws a derived exception 
        // if the array bounds exception is caught.
        public    int       AddRecord( string newRecord )
        {
            try
            {
                logArea[ elemInUse ] = newRecord;
                return elemInUse++;
            }
            catch( Exception ex )
            {
                throw new LogTableOverflowException( 
                    String.Format( "Record \"{0}\" was not logged.", 
                        newRecord ), ex );
            }
        }
    }

    class OverflowDemo 
    {
        // Create a log table and force an overflow.
        public static void Main() 
        {
            LogTable log = new LogTable( 4 );

            Console.WriteLine( 
                "This example of the Exception( string, Exception )" +
                "\nconstructor generates the following output." );
            Console.WriteLine( 
                "\nExample of a derived exception " +
                "that references an inner exception:\n" );
            try
            {
                for( int count = 1; ; count++ )
                {
                    log.AddRecord( 
                        String.Format( 
                            "Log record number {0}", count ) );
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
This example of the Exception( string, Exception )
constructor generates the following output.

Example of a derived exception that references an inner exception:

NDP_UE_CS.LogTableOverflowException: The log table has overflowed. - Record "Lo
g record number 5" was not logged. ---> System.IndexOutOfRangeException: Index
was outside the bounds of the array.
   at NDP_UE_CS.LogTable.AddRecord(String newRecord)
   --- End of inner exception stack trace ---
   at NDP_UE_CS.LogTable.AddRecord(String newRecord)
   at NDP_UE_CS.OverflowDemo.Main()
*/
//</Snippet3>
