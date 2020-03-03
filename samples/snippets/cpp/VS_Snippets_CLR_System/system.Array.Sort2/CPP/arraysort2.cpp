// The following example shows how to sort two associated arrays
// where the first array contains the keys and the second array contains the values.
// Sorts are done using the default comparer and a custom comparer that reverses the sort order.

// <Snippet1>
using namespace System;
using namespace System::Collections;

public ref class myReverserClass: public IComparer
{
private:

   // Calls CaseInsensitiveComparer::Compare with the parameters reversed.
   virtual int Compare( Object^ x, Object^ y ) = IComparer::Compare
   {
      return ((gcnew CaseInsensitiveComparer)->Compare( y, x ));
   }
};

void PrintKeysAndValues( array<String^>^myKeys, array<String^>^myValues )
{
   for ( int i = 0; i < myKeys->Length; i++ )
   {
      Console::WriteLine( " {0, -10}: {1}", myKeys[ i ], myValues[ i ] );
   }
   Console::WriteLine();
}

int main()
{
   // Creates and initializes a new Array and a new custom comparer.
   array<String^>^myKeys = {"red","GREEN","YELLOW","BLUE","purple","black","orange"};
   array<String^>^myValues = {"strawberries","PEARS","LIMES","BERRIES","grapes","olives","cantaloupe"};
   IComparer^ myComparer = gcnew myReverserClass;

   // Displays the values of the Array.
   Console::WriteLine( "The Array initially contains the following values:" );
   PrintKeysAndValues( myKeys, myValues );

   // Sorts a section of the Array using the default comparer.
   Array::Sort( myKeys, myValues, 1, 3 );
   Console::WriteLine( "After sorting a section of the Array using the default comparer:" );

   // Sorts a section of the Array using the reverse case-insensitive comparer.
   Array::Sort( myKeys, myValues, 1, 3, myComparer );
   Console::WriteLine( "After sorting a section of the Array using the reverse case-insensitive comparer:" );
   PrintKeysAndValues( myKeys, myValues );

   // Sorts the entire Array using the default comparer.
   Array::Sort( myKeys, myValues );
   Console::WriteLine( "After sorting the entire Array using the default comparer:" );
   PrintKeysAndValues( myKeys, myValues );

   // Sorts the entire Array using the reverse case-insensitive comparer.
   Array::Sort( myKeys, myValues, myComparer );
   Console::WriteLine( "After sorting the entire Array using the reverse case-insensitive comparer:" );
   PrintKeysAndValues( myKeys, myValues );
}

/* 
This code produces the following output.

The Array initially contains the following values:
   red       : strawberries
   GREEN     : PEARS
   YELLOW    : LIMES
   BLUE      : BERRIES
   purple    : grapes
   black     : olives
   orange    : cantaloupe

After sorting a section of the Array using the default comparer:
   red       : strawberries
   BLUE      : BERRIES
   GREEN     : PEARS
   YELLOW    : LIMES
   purple    : grapes
   black     : olives
   orange    : cantaloupe

After sorting a section of the Array using the reverse case-insensitive comparer:
   red       : strawberries
   YELLOW    : LIMES
   GREEN     : PEARS
   BLUE      : BERRIES
   purple    : grapes
   black     : olives
   orange    : cantaloupe

After sorting the entire Array using the default comparer:
   black     : olives
   BLUE      : BERRIES
   GREEN     : PEARS
   orange    : cantaloupe
   purple    : grapes
   red       : strawberries
   YELLOW    : LIMES

After sorting the entire Array using the reverse case-insensitive comparer:
   YELLOW    : LIMES
   red       : strawberries
   purple    : grapes
   orange    : cantaloupe
   GREEN     : PEARS
   BLUE      : BERRIES
   black     : olives

*/
// </Snippet1>
