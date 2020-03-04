
//<Snippet1>
// Example for the Exception::HelpLink, Exception::Source,
// Exception::StackTrace, and Exception::TargetSite properties.
using namespace System;

namespace NDP_UE_CPP
{

   // Derive an exception; the constructor sets the HelpLink and 
   // Source properties.
   public ref class LogTableOverflowException: public Exception
   {
   private:
      static String^ overflowMessage = "The log table has overflowed.";

   public:
      LogTableOverflowException( String^ auxMessage, Exception^ inner )
         : Exception( String::Format( "{0} - {1}", overflowMessage, auxMessage ), inner )
      {
         this->HelpLink = "http://msdn.microsoft.com";
         this->Source = "Exception_Class_Samples";
      }

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

      // The AddRecord method throws a derived exception if 
      // the array bounds exception is caught.
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
         Console::WriteLine( "\nMessage ---\n{0}", ex->Message );
         Console::WriteLine( "\nHelpLink ---\n{0}", ex->HelpLink );
         Console::WriteLine( "\nSource ---\n{0}", ex->Source );
         Console::WriteLine( "\nStackTrace ---\n{0}", ex->StackTrace );
         Console::WriteLine( "\nTargetSite ---\n{0}", ex->TargetSite->ToString() );
      }

   }

}

int main()
{
   Console::WriteLine( "This example of \n   Exception::Message, \n"
   "   Exception::HelpLink, \n   Exception::Source, \n"
   "   Exception::StackTrace, and \n   Exception::"
   "TargetSite \ngenerates the following output." );
   NDP_UE_CPP::ForceOverflow();
}

/*
This example of
   Exception::Message,
   Exception::HelpLink,
   Exception::Source,
   Exception::StackTrace, and
   Exception::TargetSite
generates the following output.

Message ---
The log table has overflowed. - Record "Log record number 5" was not logged.

HelpLink ---
http://msdn.microsoft.com

Source ---
Exception_Class_Samples

StackTrace ---
   at NDP_UE_CPP.LogTable.AddRecord(String newRecord)
   at NDP_UE_CPP.ForceOverflow()

TargetSite ---
Int32 AddRecord(System.String)
*/
//</Snippet1>
