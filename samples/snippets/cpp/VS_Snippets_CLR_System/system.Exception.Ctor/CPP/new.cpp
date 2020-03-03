
//<Snippet1>
// Example for the Exception( ) constructor.
using namespace System;

namespace NDP_UE_CPP
{

   // Derive an exception with a predefined message.
   public ref class NotEvenException: public Exception
   {
   public:
      NotEvenException()
         : Exception( "The argument to a function requiring "
      "even input is not divisible by 2." )
      {}

   };


   // Half throws a base exception if the input is not even.
   int Half( int input )
   {
      if ( input % 2 != 0 )
            throw gcnew Exception;
      else
            return input / 2;
   }


   // Half2 throws a derived exception if the input is not even.
   int Half2( int input )
   {
      if ( input % 2 != 0 )
            throw gcnew NotEvenException;
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
   Console::WriteLine( "This example of the Exception( ) constructor "
   "generates the following output." );
   Console::WriteLine( "\nHere, an exception is thrown using the \n"
   "parameterless constructor of the base class.\n" );
   NDP_UE_CPP::CalcHalf( 12 );
   NDP_UE_CPP::CalcHalf( 15 );
   Console::WriteLine( "\nHere, an exception is thrown using the \n"
   "parameterless constructor of a derived class.\n" );
   NDP_UE_CPP::CalcHalf2( 24 );
   NDP_UE_CPP::CalcHalf2( 27 );
}

/*
This example of the Exception( ) constructor generates the following output.

Here, an exception is thrown using the
parameterless constructor of the base class.

Half of 12 is 6.
System.Exception: Exception of type System.Exception was thrown.
   at NDP_UE_CPP.Half(Int32 input)
   at NDP_UE_CPP.CalcHalf(Int32 input)

Here, an exception is thrown using the
parameterless constructor of a derived class.

Half of 24 is 12.
NDP_UE_CPP.NotEvenException: The argument to a function requiring even input is
 not divisible by 2.
   at NDP_UE_CPP.Half2(Int32 input)
   at NDP_UE_CPP.CalcHalf2(Int32 input)
*/
//</Snippet1>
