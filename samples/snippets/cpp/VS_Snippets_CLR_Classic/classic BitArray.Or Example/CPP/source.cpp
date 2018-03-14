
// <Snippet1>
using namespace System;
using namespace System::Collections;
void PrintValues( IEnumerable^ myList, int myWidth );
int main()
{
   
   // Creates and initializes two BitArrays of the same size.
   BitArray^ myBA1 = gcnew BitArray( 4 );
   BitArray^ myBA2 = gcnew BitArray( 4 );
   myBA1[ 0 ] = false;
   myBA1[ 1 ] = false;
   myBA1[ 2 ] = true;
   myBA1[ 3 ] = true;
   myBA2[ 0 ] = false;
   myBA2[ 1 ] = true;
   myBA2[ 2 ] = false;
   myBA2[ 3 ] = true;
   
   // Performs a bitwise OR operation between BitArray instances of the same size.
   Console::WriteLine( "Initial values" );
   Console::Write( "myBA1:" );
   PrintValues( myBA1, 8 );
   Console::Write( "myBA2:" );
   PrintValues( myBA2, 8 );
   Console::WriteLine();
   Console::WriteLine( "Result" );
   Console::Write( "OR:" );
   PrintValues( myBA1->Or( myBA2 ), 8 );
   Console::WriteLine();
   Console::WriteLine( "After OR" );
   Console::Write( "myBA1:" );
   PrintValues( myBA1, 8 );
   Console::Write( "myBA2:" );
   PrintValues( myBA2, 8 );
   Console::WriteLine();
   
   // Performing OR between BitArray instances of different sizes returns an exception.
   try
   {
      BitArray^ myBA3 = gcnew BitArray( 8 );
      myBA3[ 0 ] = false;
      myBA3[ 1 ] = false;
      myBA3[ 2 ] = false;
      myBA3[ 3 ] = false;
      myBA3[ 4 ] = true;
      myBA3[ 5 ] = true;
      myBA3[ 6 ] = true;
      myBA3[ 7 ] = true;
      myBA1->Or( myBA3 );
   }
   catch ( Exception^ myException ) 
   {
      Console::WriteLine( "Exception: {0}", myException );
   }

}

void PrintValues( IEnumerable^ myList, int myWidth )
{
   int i = myWidth;
   IEnumerator^ myEnum = myList->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Object^ obj = safe_cast<Object^>(myEnum->Current);
      if ( i <= 0 )
      {
         i = myWidth;
         Console::WriteLine();
      }

      i--;
      Console::Write( "{0,8}", obj );
   }

   Console::WriteLine();
}

/* 
 This code produces the following output.
 
 Initial values
 myBA1:   False   False    True    True
 myBA2:   False    True   False    True

 Result
 OR:   False    True    True    True

 After OR
 myBA1:   False    True    True    True
 myBA2:   False    True   False    True

 Exception: System.ArgumentException: Array lengths must be the same.
    at System.Collections.BitArray.Or(BitArray value)
    at SamplesBitArray.Main()
 */
// </Snippet1>
