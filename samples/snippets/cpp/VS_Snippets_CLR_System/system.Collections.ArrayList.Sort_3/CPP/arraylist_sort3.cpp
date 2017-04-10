
// The following example shows how to sort the values in a section of an <see cref="System.Collections.ArrayList" /> using the default comparer and a custom comparer which reverses the sort order.
// <Snippet1>
using namespace System;
using namespace System::Collections;
void PrintIndexAndValues( IEnumerable^ myList );
ref class myReverserClass: public IComparer
{
private:

   // Calls CaseInsensitiveComparer.Compare with the parameters reversed.
   virtual int Compare( Object^ x, Object^ y ) = IComparer::Compare
   {
      return ((gcnew CaseInsensitiveComparer)->Compare( y, x ));
   }

};

int main()
{
   
   // Creates and initializes a new ArrayList.
   ArrayList^ myAL = gcnew ArrayList;
   myAL->Add( "The" );
   myAL->Add( "QUICK" );
   myAL->Add( "BROWN" );
   myAL->Add( "FOX" );
   myAL->Add( "jumped" );
   myAL->Add( "over" );
   myAL->Add( "the" );
   myAL->Add( "lazy" );
   myAL->Add( "dog" );
   
   // Displays the values of the ArrayList.
   Console::WriteLine( "The ArrayList initially contains the following values:" );
   PrintIndexAndValues( myAL );
   
   // Sorts the values of the ArrayList using the default comparer.
   myAL->Sort( 1, 3, nullptr );
   Console::WriteLine( "After sorting from index 1 to index 3 with the default comparer:" );
   PrintIndexAndValues( myAL );
   
   // Sorts the values of the ArrayList using the reverse case-insensitive comparer.
   IComparer^ myComparer = gcnew myReverserClass;
   myAL->Sort( 1, 3, myComparer );
   Console::WriteLine( "After sorting from index 1 to index 3 with the reverse case-insensitive comparer:" );
   PrintIndexAndValues( myAL );
}

void PrintIndexAndValues( IEnumerable^ myList )
{
   int i = 0;
   IEnumerator^ myEnum = myList->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Object^ obj = safe_cast<Object^>(myEnum->Current);
      Console::WriteLine( "\t[{0}]:\t{1}", i++, obj );
   }

   Console::WriteLine();
}

/* 
This code produces the following output.
The ArrayList initially contains the following values:
        [0]:    The
        [1]:    QUICK
        [2]:    BROWN
        [3]:    FOX
        [4]:    jumped
        [5]:    over
        [6]:    the
        [7]:    lazy
        [8]:    dog

After sorting from index 1 to index 3 with the default comparer:
        [0]:    The
        [1]:    BROWN
        [2]:    FOX
        [3]:    QUICK
        [4]:    jumped
        [5]:    over
        [6]:    the
        [7]:    lazy
        [8]:    dog

After sorting from index 1 to index 3 with the reverse case-insensitive comparer:
        [0]:    The
        [1]:    QUICK
        [2]:    FOX
        [3]:    BROWN
        [4]:    jumped
        [5]:    over
        [6]:    the
        [7]:    lazy
        [8]:    dog
*/
// </Snippet1>
