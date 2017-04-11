
// The following code example compares SortKey objects created with 
// cultures that have different sort orders.
// <snippet1>
using namespace System;
using namespace System::Globalization;
int main()
{
   
   // Creates a SortKey using the en-US culture.
   CultureInfo^ MyCI = gcnew CultureInfo( "en-US",false );
   CompareInfo^ myComp_enUS = MyCI->CompareInfo;
   SortKey^ mySK1 = myComp_enUS->GetSortKey( "llama" );
   
   // Creates a SortKey using the es-ES culture with international sort.
   MyCI = gcnew CultureInfo( "es-ES",false );
   CompareInfo^ myComp_esES = MyCI->CompareInfo;
   SortKey^ mySK2 = myComp_esES->GetSortKey( "llama" );
   
   // Creates a SortKey using the es-ES culture with traditional sort.
   MyCI = gcnew CultureInfo( 0x040A,false );
   CompareInfo^ myComp_es = MyCI->CompareInfo;
   SortKey^ mySK3 = myComp_es->GetSortKey( "llama" );
   
   // Compares the en-US SortKey with each of the es-ES SortKey objects.
   Console::WriteLine( "Comparing \"llama\" in en-US and in es-ES with international sort : {0}", SortKey::Compare( mySK1, mySK2 ) );
   Console::WriteLine( "Comparing \"llama\" in en-US and in es-ES with traditional sort   : {0}", SortKey::Compare( mySK1, mySK3 ) );
}

/*
This code produces the following output.

Comparing S"llama" in en-US and in es-ES with international sort : 0
Comparing S"llama" in en-US and in es-ES with traditional sort   : -1
*/
// </snippet1>
