
// <Snippet1>
using namespace System;
void PrintValues( Array^ myArr );
void main()
{
   // Creates and initializes a two-dimensional Array instance of type String.
   Array^ my2DArray = Array::CreateInstance( String::typeid, 2, 3 );
   for ( int i = my2DArray->GetLowerBound( 0 ); i <= my2DArray->GetUpperBound( 0 ); i++ )
      for ( int j = my2DArray->GetLowerBound( 1 ); j <= my2DArray->GetUpperBound( 1 ); j++ )
         my2DArray->SetValue( String::Concat( "abc", i, j ), i, j );
   
   // Displays the values of the Array.
   Console::WriteLine(  "The two-dimensional Array instance contains the following values:" );
   PrintValues( my2DArray );
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
 
 The two-dimensional Array instance contains the following values:
     abc00    abc01    abc02
     abc10    abc11    abc12
 */
// </Snippet1>
