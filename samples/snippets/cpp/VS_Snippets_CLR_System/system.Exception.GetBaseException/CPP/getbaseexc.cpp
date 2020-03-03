
//<Snippet1>
// Example for the Exception::GetBaseException method.
using namespace System;

namespace NDP_UE_CPP
{

   // Define two derived exceptions to demonstrate nested exceptions.
   ref class SecondLevelException: public Exception
   {
   public:
      SecondLevelException( String^ message, Exception^ inner )
         : Exception( message, inner )
      {}

   };

   ref class ThirdLevelException: public Exception
   {
   public:
      ThirdLevelException( String^ message, Exception^ inner )
         : Exception( message, inner )
      {}

   };


   // DivideBy0 forces a division by 0 and throws a second exception.
   void DivideBy0()
   {
      try
      {
         int zero = 0;
         int ecks = 1 / zero;
      }
      catch ( Exception^ ex ) 
      {
         throw gcnew SecondLevelException( "Forced a division by 0 and threw "
         "a second exception.",ex );
      }

   }


   // This function catches the exception from the called function
   // DivideBy0( ) and throws another in response.
   void Rethrow()
   {
      try
      {
         DivideBy0();
      }
      catch ( Exception^ ex ) 
      {
         throw gcnew ThirdLevelException( "Caught the second exception and "
         "threw a third in response.",ex );
      }

   }

}

int main()
{
   Console::WriteLine( "This example of Exception.GetBaseException "
   "generates the following output." );
   Console::WriteLine( "\nThe program forces a division by 0, "
   "then throws the exception \ntwice more, "
   "using a different derived exception each time.\n" );
   try
   {
      
      // This function calls another that forces a division by 0.
      NDP_UE_CPP::Rethrow();
   }
   catch ( Exception^ e ) 
   {
      Exception^ current;
      Console::WriteLine( "Unwind the nested exceptions using "
      "the InnerException property:\n" );
      
      // This code unwinds the nested exceptions using the 
      // InnerException property.
      current = e;
      while ( current != (Object^)0 )
      {
         Console::WriteLine( current->ToString() );
         Console::WriteLine();
         current = current->InnerException;
      }
      
      // Display the innermost exception.
      Console::WriteLine( "Display the base exception using the \n"
      "GetBaseException method:\n" );
      Console::WriteLine( e->GetBaseException()->ToString() );
   }

}

/*
This example of Exception.GetBaseException generates the following output.

The program forces a division by 0, then throws the exception
twice more, using a different derived exception each time.

Unwind the nested exceptions using the InnerException property:

NDP_UE_CPP.ThirdLevelException: Caught the second exception and threw a third i
n response. ---> NDP_UE_CPP.SecondLevelException: Forced a division by 0 and th
rew a second exception. ---> System.DivideByZeroException: Attempted to divide
by zero.
   at NDP_UE_CPP.DivideBy0()
   --- End of inner exception stack trace ---
   at NDP_UE_CPP.DivideBy0()
   at NDP_UE_CPP.Rethrow()
   --- End of inner exception stack trace ---
   at NDP_UE_CPP.Rethrow()
   at main()

NDP_UE_CPP.SecondLevelException: Forced a division by 0 and threw a second exce
ption. ---> System.DivideByZeroException: Attempted to divide by zero.
   at NDP_UE_CPP.DivideBy0()
   --- End of inner exception stack trace ---
   at NDP_UE_CPP.DivideBy0()
   at NDP_UE_CPP.Rethrow()

System.DivideByZeroException: Attempted to divide by zero.
   at NDP_UE_CPP.DivideBy0()

Display the base exception using the
GetBaseException method:

System.DivideByZeroException: Attempted to divide by zero.
   at NDP_UE_CPP.DivideBy0()
*/
//</Snippet1>
