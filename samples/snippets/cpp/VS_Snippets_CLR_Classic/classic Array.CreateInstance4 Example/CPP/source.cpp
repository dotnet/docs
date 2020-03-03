
// <Snippet1>
using namespace System;
void PrintValues( Array^ myArr );
void main()
{
   // Creates and initializes a multidimensional Array instance of type String.
   array<int>^myLengthsArray = {3,5};
   array<int>^myBoundsArray = {2,3};
   Array^ myArray = Array::CreateInstance( String::typeid, myLengthsArray, myBoundsArray );
   for ( int i = myArray->GetLowerBound( 0 ); i <= myArray->GetUpperBound( 0 ); i++ )
      for ( int j = myArray->GetLowerBound( 1 ); j <= myArray->GetUpperBound( 1 ); j++ )
      {
         array<int>^myIndicesArray = {i,j};
         myArray->SetValue( String::Concat( Convert::ToString( i ), j ), myIndicesArray );

      }

   // Displays the lower bounds and the upper bounds of each dimension.
   Console::WriteLine(  "Bounds:\tLower\tUpper" );
   for ( int i = 0; i < myArray->Rank; i++ )
      Console::WriteLine(  "{0}:\t{1}\t{2}", i, myArray->GetLowerBound( i ), myArray->GetUpperBound( i ) );

   // Displays the values of the Array.
   Console::WriteLine(  "The Array instance contains the following values:" );
   PrintValues( myArray );
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
 
 Bounds:    Lower    Upper
 0:    2    4
 1:    3    7
 The Array instance contains the following values:
     23    24    25    26    27
     33    34    35    36    37
     43    44    45    46    47
 */
// </Snippet1>
