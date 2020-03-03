
// <Snippet1>
using namespace System;
using namespace System::Collections;
void PrintValues( IEnumerable^ myArr );
int main()
{
   // Creates and initializes the source BitArray.
   BitArray^ myBA = gcnew BitArray( 4 );
   myBA[ 0 ] = true;
   myBA[ 1 ] = true;
   myBA[ 2 ] = true;
   myBA[ 3 ] = true;

   // Creates and initializes the one-dimensional target Array of type Boolean.
   array<Boolean>^myBoolArray = gcnew array<Boolean>(8);
   myBoolArray[ 0 ] = false;
   myBoolArray[ 1 ] = false;

   // Displays the values of the target Array.
   Console::WriteLine( "The target Boolean Array contains the following (before and after copying):" );
   PrintValues( dynamic_cast<IEnumerable^>(myBoolArray) );

   // Copies the entire source BitArray to the target BitArray, starting at index 3.
   myBA->CopyTo( myBoolArray, 3 );

   // Displays the values of the target Array.
   PrintValues( dynamic_cast<IEnumerable^>(myBoolArray) );

   // Creates and initializes the one-dimensional target Array of type integer.
   array<Int32>^myIntArray = gcnew array<Int32>(8);
   myIntArray[ 0 ] = 42;
   myIntArray[ 1 ] = 43;

   // Displays the values of the target Array.
   Console::WriteLine( "The target integer Array contains the following (before and after copying):" );
   PrintValues( dynamic_cast<IEnumerable^>(myIntArray) );

   // Copies the entire source BitArray to the target BitArray, starting at index 3.
   myBA->CopyTo( myIntArray, 3 );

   // Displays the values of the target Array.
   PrintValues( dynamic_cast<IEnumerable^>(myIntArray) );

   // Creates and initializes the one-dimensional target Array of type byte.
   Array^ myByteArray = Array::CreateInstance( Byte::typeid, 8 );
   myByteArray->SetValue( (Byte)10, 0 );
   myByteArray->SetValue( (Byte)11, 1 );

   // Displays the values of the target Array.
   Console::WriteLine( "The target byte Array contains the following (before and after copying):" );
   PrintValues( myByteArray );

   // Copies the entire source BitArray to the target BitArray, starting at index 3.
   myBA->CopyTo( myByteArray, 3 );

   // Displays the values of the target Array.
   PrintValues( myByteArray );

   // Returns an exception if the array is not of type Boolean, integer or byte.
   try
   {
      Array^ myStringArray = Array::CreateInstance( String::typeid, 8 );
      myStringArray->SetValue( "Hello", 0 );
      myStringArray->SetValue( "World", 1 );
      myBA->CopyTo( myStringArray, 3 );
   }
   catch ( Exception^ myException ) 
   {
      Console::WriteLine( "Exception: {0}", myException );
   }

}

void PrintValues( IEnumerable^ myArr )
{
   IEnumerator^ myEnum = myArr->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Object^ obj = safe_cast<Object^>(myEnum->Current);
      Console::Write( "{0,8}", obj );
   }

   Console::WriteLine();
}

/* 
 This code produces the following output.
 
 The target Boolean Array contains the following (before and after copying):
    False   False   False   False   False   False   False   False
    False   False   False    True    True    True    True   False
 The target integer Array contains the following (before and after copying):
       42      43       0       0       0       0       0       0
       42      43       0      15       0       0       0       0
 The target byte Array contains the following (before and after copying):
       10      11       0       0       0       0       0       0
       10      11       0      15       0       0       0       0
 Exception: System.ArgumentException: Only supported array types for CopyTo on BitArrays are Boolean[], Int32[] and Byte[].
    at System.Collections.BitArray.CopyTo(Array array, Int32 index)
    at SamplesBitArray.Main()

 */
// </Snippet1>
