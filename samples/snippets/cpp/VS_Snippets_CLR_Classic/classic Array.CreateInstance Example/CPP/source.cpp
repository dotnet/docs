
// <Snippet1>
using namespace System;
void PrintValues( Array^ myArr );
void main()
{
   // Creates and initializes a one-dimensional Array instance of type Int32.
   Array^ my1DArray = Array::CreateInstance( Int32::typeid, 5 );
   for ( int i = my1DArray->GetLowerBound( 0 ); i <= my1DArray->GetUpperBound( 0 ); i++ )
      my1DArray->SetValue( i + 1, i );

   // Displays the values of the Array.
   Console::WriteLine(  "The one-dimensional Array instance contains the following values:" );
   PrintValues( my1DArray );
}

void PrintValues( Array^ myArr )
{
   System::Collections::IEnumerator^ myEnumerator = myArr->GetEnumerator();
   int i = 0;
   int cols = myArr->GetLength( myArr->Rank - 1 );
   while ( myEnumerator->MoveNext() )
   {
      if ( i < cols )
      {
         i++;
      }
      else
      {
         Console::WriteLine();
         i = 1;
      }

      Console::Write(  "\t{0}", myEnumerator->Current );
   }

   Console::WriteLine();
}

/*
 This code produces the following output.
 
 The one-dimensional Array instance contains the following values:
     1    2    3    4    5
 */
// </Snippet1>
