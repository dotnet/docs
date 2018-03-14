
//<Snippet1>
using namespace System;
int main()
{
   array<String^>^names = { "Dog", "Cat", "Fish"};
   array<Object^>^objs = dynamic_cast<array<Object^>^>(names);
   try
   {
      objs[ 2 ] = (Object^)"Mouse";
      for ( Int32 i = 0; i < objs->Length; i++ )
      {
         Console::WriteLine( objs[ i ] );

      }
   }
   catch ( System::ArrayTypeMismatchException^ ) 
   {
      
      // Not reached, "Mouse" is of the correct type
      Console::WriteLine(  "Exception Thrown" );
   }

   try
   {
      Object^ obj = 13;
      objs[ 2 ] = obj;
   }
   catch ( System::ArrayTypeMismatchException^ ) 
   {
      
      // Always reached, 13 is not a string.
      Console::WriteLine(  "New element is not of the correct type" );
   }

   
   // Set obj to an array of objects instead of an array of strings
   array<Object^>^objs2 = gcnew array<Object^>(3);
   try
   {
      objs2[ 0 ] = (Object^)"Turtle";
      objs2[ 1 ] = 12;
      objs2[ 2 ] = 2.341;
      for ( Int32 i = 0; i < objs->Length; i++ )
      {
         Console::WriteLine( objs2[ i ] );

      }
   }
   catch ( System::ArrayTypeMismatchException^ ) 
   {
      
      // ArrayTypeMismatchException is not thrown this time.
      Console::WriteLine(  "Exception Thrown" );
   }

}

/*expected return values:
Dog
Cat
Mouse
New element is not of the correct type
Turtle
12
2.341
*/
//</Snippet1>
