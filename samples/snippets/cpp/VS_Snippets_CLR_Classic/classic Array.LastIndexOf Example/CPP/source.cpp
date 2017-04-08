
// <Snippet1>
using namespace System;
void PrintIndexAndValues( Array^ myArray );

void main()
{
   // Creates and initializes a new Array instance with three elements of the same value.
   Array^ myArray = Array::CreateInstance( String::typeid, 12 );
   myArray->SetValue( "the", 0 );
   myArray->SetValue( "quick", 1 );
   myArray->SetValue( "brown", 2 );
   myArray->SetValue( "fox", 3 );
   myArray->SetValue( "jumped", 4 );
   myArray->SetValue( "over", 5 );
   myArray->SetValue( "the", 6 );
   myArray->SetValue( "lazy", 7 );
   myArray->SetValue( "dog", 8 );
   myArray->SetValue( "in", 9 );
   myArray->SetValue( "the", 10 );
   myArray->SetValue( "barn", 11 );

   // Displays the values of the Array.
   Console::WriteLine(  "The Array instance contains the following values:" );
   PrintIndexAndValues( myArray );

   // Searches for the last occurrence of the duplicated value.
   String^ myString =  "the";
   int myIndex = Array::LastIndexOf( myArray, myString );
   Console::WriteLine(  "The last occurrence of \"{0}\" is at index {1}.", myString, myIndex );

   // Searches for the last occurrence of the duplicated value in the first section of the Array.
   myIndex = Array::LastIndexOf( myArray, myString, 8 );
   Console::WriteLine(  "The last occurrence of \"{0}\" between the start and index 8 is at index {1}.", myString, myIndex );

   // Searches for the last occurrence of the duplicated value in a section of the Array.  
   // Note that the start index is greater than the end index because the search is done backward.
   myIndex = Array::LastIndexOf( myArray, myString, 10, 6 );
   Console::WriteLine(  "The last occurrence of \"{0}\" between index 5 and index 10 is at index {1}.", myString, myIndex );
}

void PrintIndexAndValues( Array^ myArray )
{
   for ( int i = myArray->GetLowerBound( 0 ); i <= myArray->GetUpperBound( 0 ); i++ )
      Console::WriteLine(  "\t[{0}]:\t{1}", i, myArray->GetValue( i ) );
}

/* 
 This code produces the following output.
 
 The Array instance contains the following values:
     [0]:    the
     [1]:    quick
     [2]:    brown
     [3]:    fox
     [4]:    jumped
     [5]:    over
     [6]:    the
     [7]:    lazy
     [8]:    dog
     [9]:    in
     [10]:    the
     [11]:    barn
 The last occurrence of "the" is at index 10.
 The last occurrence of "the" between the start and index 8 is at index 6.
 The last occurrence of "the" between index 5 and index 10 is at index 10.
 */
// </Snippet1>
