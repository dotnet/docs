
// The following code example shows how sorting with CompareOptions::StringSort differs 
// from sorting with->Item[Out] CompareOptions::StringSort.
// <snippet1>
using namespace System;
using namespace System::Collections;
using namespace System::Globalization;

// __gc public class SamplesCompareOptions {
ref class MyStringComparer: public IComparer
{
public:

   // Constructs a comparer using the specified CompareOptions.
   CompareInfo^ myComp;
   CompareOptions myOptions;
   MyStringComparer( CompareInfo^ cmpi, CompareOptions options )
      : myComp( cmpi ), myOptions( options )
   {}

   // Compares strings with the CompareOptions specified in the constructor.
   virtual int Compare( Object^ a, Object^ b )
   {
      if ( a == b )
            return 0;

      if ( a == nullptr )
            return  -1;

      if ( b == nullptr )
            return 1;

      String^ sa = dynamic_cast<String^>(a);
      String^ sb = dynamic_cast<String^>(b);
      if ( sa != nullptr && sb != nullptr )
            return myComp->Compare( sa, sb, myOptions );

      throw gcnew ArgumentException( "a and b should be strings." );
   }
};

int main()
{
   
   // Creates and initializes an array of strings to sort.
   array<String^>^myArr = {"cant","bill's","coop","cannot","billet","can't","con","bills","co-op"};
   Console::WriteLine( "\nInitially, " );
   IEnumerator^ myEnum = myArr->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      String^ myStr = safe_cast<String^>(myEnum->Current);
      Console::WriteLine( myStr );
   }

   
   // Creates and initializes a Comparer to use.
   //CultureInfo* myCI = new CultureInfo(S"en-US", false);
   MyStringComparer^ myComp = gcnew MyStringComparer( CompareInfo::GetCompareInfo( "en-US" ),CompareOptions::None );
   
   // Sorts the array without StringSort.
   Array::Sort( myArr, myComp );
   Console::WriteLine( "\nAfter sorting without CompareOptions::StringSort:" );
   myEnum = myArr->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      String^ myStr = safe_cast<String^>(myEnum->Current);
      Console::WriteLine( myStr );
   }

   
   // Sorts the array with StringSort.
   myComp = gcnew MyStringComparer( CompareInfo::GetCompareInfo( "en-US" ),CompareOptions::StringSort );
   Array::Sort( myArr, myComp );
   Console::WriteLine( "\nAfter sorting with CompareOptions::StringSort:" );
   myEnum = myArr->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      String^ myStr = safe_cast<String^>(myEnum->Current);
      Console::WriteLine( myStr );
   }
}

/*
This code produces the following output.

Initially,
cant
bill's
coop
cannot
billet
can't
con
bills
co-op

After sorting without CompareOptions::StringSort:
billet
bills
bill's
cannot
cant
can't
con
coop
co-op

After sorting with CompareOptions::StringSort:
bill's
billet
bills
can't
cannot
cant
co-op
con
coop
*/
// </snippet1>
