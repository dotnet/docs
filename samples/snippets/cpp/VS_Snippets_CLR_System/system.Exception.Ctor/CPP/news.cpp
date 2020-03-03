
//<Snippet2>
// Example for the Exception( String* ) constructor.
using namespace System;

namespace NDP_UE_CPP
{

   // Derive an exception with a specifiable message.
   public ref class NotEvenException: public Exception
   {
   private:
      static String^ notEvenMessage = "The argument to a function requiring "
      "even input is not divisible by 2.";

   public:
      NotEvenException()
         : Exception( notEvenMessage )
      {}

      NotEvenException( String^ auxMessage )
         : Exception( String::Format( "{0} - {1}", auxMessage, notEvenMessage ) )
      {}

   };


   // Half throws a base exception if the input is not even.
   int Half( int input )
   {
      if ( input % 2 != 0 )
            throw gcnew Exception( String::Format( "The argument {0} is not divisible by 2.", input ) );
      else
            return input / 2;
   }


   // Half2 throws a derived exception if the input is not even.
   int Half2( int input )
   {
      if ( input % 2 != 0 )
            throw gcnew NotEvenException( String::Format( "Invalid argument: {0}", input ) );
      else
            return input / 2;
   }


   // CalcHalf calls Half and catches any thrown exceptions.
   void CalcHalf( int input )
   {
      try
      {
         int halfInput = Half( input );
         Console::WriteLine( "Half of {0} is {1}.", input, halfInput );
      }
      catch ( Exception^ ex ) 
      {
         Console::WriteLine( ex->ToString() );
      }

   }


   // CalcHalf2 calls Half2 and catches any thrown exceptions.
   void CalcHalf2( int input )
   {
      try
      {
         int halfInput = Half2( input );
         Console::WriteLine( "Half of {0} is {1}.", input, halfInput );
      }
      catch ( Exception^ ex ) 
      {
         Console::WriteLine( ex->ToString() );
      }

   }

}

int main()
{
   Console::WriteLine( "This example of the Exception( String* )\n"
   "constructor generates the following output." );
   Console::WriteLine( "\nHere, an exception is thrown using the \n"
   "constructor of the base class.\n" );
   NDP_UE_CPP::CalcHalf( 18 );
   NDP_UE_CPP::CalcHalf( 21 );
   Console::WriteLine( "\nHere, an exception is thrown using the \n"
   "constructor of a derived class.\n" );
   NDP_UE_CPP::CalcHalf2( 30 );
   NDP_UE_CPP::CalcHalf2( 33 );
}

/*
This example of the Exception( String* )
constructor generates the following output.

Here, an exception is thrown using the
constructor of the base class.

Half of 18 is 9.
System.Exception: The argument 21 is not divisible by 2.
   at NDP_UE_CPP.Half(Int32 input)
   at NDP_UE_CPP.CalcHalf(Int32 input)

Here, an exception is thrown using the
constructor of a derived class.

Half of 30 is 15.
NDP_UE_CPP.NotEvenException: Invalid argument: 33 - The argument to a function
requiring even input is not divisible by 2.
   at NDP_UE_CPP.Half2(Int32 input)
   at NDP_UE_CPP.CalcHalf2(Int32 input)
*/
//</Snippet2>
