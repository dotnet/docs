void PrintIndexAndValues( Array^ myArray );
void main2()
{
   // Creates and initializes the source Array.
   Array^ myArrayZero = Array::CreateInstance( String::typeid, 3 );
   myArrayZero->SetValue( "zero", 0 );
   myArrayZero->SetValue( "one", 1 );

   // Displays the source Array.
   Console::WriteLine(  "The array with lowbound=0 contains:" );
   PrintIndexAndValues( myArrayZero );

   // Creates and initializes the target Array.
   array<int>^myArrLen = {4};
   array<int>^myArrLow = {2};
   Array^ myArrayTwo = Array::CreateInstance( String::typeid, myArrLen, myArrLow );
   myArrayTwo->SetValue( "two", 2 );
   myArrayTwo->SetValue( "three", 3 );
   myArrayTwo->SetValue( "four", 4 );
   myArrayTwo->SetValue( "five", 5 );

   // Displays the target Array.
   Console::WriteLine(  "The array with lowbound=2 contains:" );
   PrintIndexAndValues( myArrayTwo );

   // Copy from the array with lowbound=0 to the array with lowbound=2.
   myArrayZero->CopyTo( myArrayTwo, 3 );

   // Displays the modified target Array.
   Console::WriteLine(  "\nAfter copying at relative index 1:" );
   PrintIndexAndValues( myArrayTwo );
}

void PrintIndexAndValues( Array^ myArray )
{
   for ( int i = myArray->GetLowerBound( 0 ); i <= myArray->GetUpperBound( 0 ); i++ )
      Console::WriteLine(  "\t[{0}]:\t{1}", i, myArray->GetValue( i ) );
}

/* 
 This code produces the following output.
 
 The array with lowbound=0 contains:
     [0]:    zero
     [1]:    one
     [2]:    
 The array with lowbound=2 contains:
     [2]:    two
     [3]:    three
     [4]:    four
     [5]:    five
 
 After copying at relative index 1:
     [2]:    two
     [3]:    zero
     [4]:    one
     [5]:
 */