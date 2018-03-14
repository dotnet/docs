
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
   
   // Performs a bitwise NOT operation between BitArray instances of the same size.
   Console::WriteLine( "Initial values" );
   Console::Write( "myBA1:" );
   PrintValues( myBA1, 8 );
   Console::Write( "myBA2:" );
   PrintValues( myBA2, 8 );
   Console::WriteLine();
   myBA1->Not();
   myBA2->Not();
   Console::WriteLine( "After NOT" );
   Console::Write( "myBA1:" );
   PrintValues( myBA1, 8 );
   Console::Write( "myBA2:" );
   PrintValues( myBA2, 8 );
   Console::WriteLine();
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

 After NOT
 myBA1:    True    True   False   False
 myBA2:    True   False    True   False

 */
// </Snippet1>
