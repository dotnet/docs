
// <Snippet1>
using namespace System;
using namespace System::Collections;
void PrintValues( IEnumerable^ myList, int myWidth );
int main()
{
   
   // Creates and initializes several BitArrays.
   BitArray^ myBA1 = gcnew BitArray( 5 );
   BitArray^ myBA2 = gcnew BitArray( 5,false );
   array<Byte>^myBytes = {1,2,3,4,5};
   BitArray^ myBA3 = gcnew BitArray( myBytes );
   array<Boolean>^myBools = {true,false,true,true,false};
   BitArray^ myBA4 = gcnew BitArray( myBools );
   array<Int32>^myInts = {6,7,8,9,10};
   BitArray^ myBA5 = gcnew BitArray( myInts );
   
   // Displays the properties and values of the BitArrays.
   Console::WriteLine( "myBA1" );
   Console::WriteLine( "   Count:    {0}", myBA1->Count );
   Console::WriteLine( "   Length:   {0}", myBA1->Length );
   Console::WriteLine( "   Values:" );
   PrintValues( myBA1, 8 );
   Console::WriteLine( "myBA2" );
   Console::WriteLine( "   Count:    {0}", myBA2->Count );
   Console::WriteLine( "   Length:   {0}", myBA2->Length );
   Console::WriteLine( "   Values:" );
   PrintValues( myBA2, 8 );
   Console::WriteLine( "myBA3" );
   Console::WriteLine( "   Count:    {0}", myBA3->Count );
   Console::WriteLine( "   Length:   {0}", myBA3->Length );
   Console::WriteLine( "   Values:" );
   PrintValues( myBA3, 8 );
   Console::WriteLine( "myBA4" );
   Console::WriteLine( "   Count:    {0}", myBA4->Count );
   Console::WriteLine( "   Length:   {0}", myBA4->Length );
   Console::WriteLine( "   Values:" );
   PrintValues( myBA4, 8 );
   Console::WriteLine( "myBA5" );
   Console::WriteLine( "   Count:    {0}", myBA5->Count );
   Console::WriteLine( "   Length:   {0}", myBA5->Length );
   Console::WriteLine( "   Values:" );
   PrintValues( myBA5, 8 );
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
 
 myBA1
    Count:    5
    Length:   5
    Values:
    False   False   False   False   False
 myBA2
    Count:    5
    Length:   5
    Values:
    False   False   False   False   False
 myBA3
    Count:    40
    Length:   40
    Values:
     True   False   False   False   False   False   False   False
    False    True   False   False   False   False   False   False
     True    True   False   False   False   False   False   False
    False   False    True   False   False   False   False   False
     True   False    True   False   False   False   False   False
 myBA4
    Count:    5
    Length:   5
    Values:
     True   False    True    True   False
 myBA5
    Count:    160
    Length:   160
    Values:
    False    True    True   False   False   False   False   False
    False   False   False   False   False   False   False   False
    False   False   False   False   False   False   False   False
    False   False   False   False   False   False   False   False
     True    True    True   False   False   False   False   False
    False   False   False   False   False   False   False   False
    False   False   False   False   False   False   False   False
    False   False   False   False   False   False   False   False
    False   False   False    True   False   False   False   False
    False   False   False   False   False   False   False   False
    False   False   False   False   False   False   False   False
    False   False   False   False   False   False   False   False
     True   False   False    True   False   False   False   False
    False   False   False   False   False   False   False   False
    False   False   False   False   False   False   False   False
    False   False   False   False   False   False   False   False
    False    True   False    True   False   False   False   False
    False   False   False   False   False   False   False   False
    False   False   False   False   False   False   False   False
    False   False   False   False   False   False   False   False
 */
// </Snippet1>
