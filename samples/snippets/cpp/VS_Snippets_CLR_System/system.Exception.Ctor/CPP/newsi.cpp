
//<Snippet3>
// Example for the Exception( String*, Exception* ) constructor.
using namespace System;

namespace NDP_UE_CPP
{

   // Derive an exception with a specifiable message and inner exception.
   public ref class LogTableOverflowException: public Exception
   {
   private:
      static String^ overflowMessage =  "The log table has overflowed.";

   public:
      LogTableOverflowException()
         : Exception( overflowMessage )
      {}

      LogTableOverflowException( String^ auxMessage )
         : Exception( String::Format( "{0} - {1}", overflowMessage, auxMessage ) )
      {}

      LogTableOverflowException( String^ auxMessage, Exception^ inner )
         : Exception( String::Format( "{0} - {1}", overflowMessage, auxMessage ), inner )
      {}

   };

   public ref class LogTable
   {
   public:
      LogTable( int numElements )
      {
         logArea = gcnew array<String^>(numElements);
         elemInUse = 0;
      }


   protected:
      array<String^>^logArea;
      int elemInUse;

   public:

      // The AddRecord method throws a derived exception 
      // if the array bounds exception is caught.
      int AddRecord( String^ newRecord )
      {
         try
         {
            logArea[ elemInUse ] = newRecord;
            return elemInUse++;
         }
         catch ( Exception^ ex ) 
         {
            throw gcnew LogTableOverflowException( String::Format( "Record \"{0}\" was not logged.", newRecord ),ex );
         }

      }

   };


   // Create a log table and force an overflow.
   void ForceOverflow()
   {
      LogTable^ log = gcnew LogTable( 4 );
      try
      {
         for ( int count = 1; ; count++ )
         {
            log->AddRecord( String::Format( "Log record number {0}", count ) );

         }
      }
      catch ( Exception^ ex ) 
      {
         Console::WriteLine( ex->ToString() );
      }

   }

}

int main()
{
   Console::WriteLine( "This example of the Exception( String*, Exception* )\n"
   "constructor generates the following output." );
   Console::WriteLine( "\nExample of a derived exception "
   "that references an inner exception:\n" );
   NDP_UE_CPP::ForceOverflow();
}

/*
This example of the Exception( String*, Exception* )
constructor generates the following output.

Example of a derived exception that references an inner exception:

NDP_UE_CPP.LogTableOverflowException: The log table has overflowed. - Record "L
og record number 5" was not logged. ---> System.IndexOutOfRangeException: Index
 was outside the bounds of the array.
   at NDP_UE_CPP.LogTable.AddRecord(String newRecord)
   --- End of inner exception stack trace ---
   at NDP_UE_CPP.LogTable.AddRecord(String newRecord)
   at NDP_UE_CPP.ForceOverflow()
*/
//</Snippet3>
