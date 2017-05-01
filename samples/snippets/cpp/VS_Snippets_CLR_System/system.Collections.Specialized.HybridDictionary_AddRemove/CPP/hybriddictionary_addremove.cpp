

// The following code example adds to and removes elements from a HybridDictionary.
// <snippet1>
#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Collections::Specialized;
void PrintKeysAndValues( IDictionary^ myCol )
{
   Console::WriteLine( "   KEY                       VALUE" );
   IEnumerator^ myEnum = myCol->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      DictionaryEntry de =  safe_cast<DictionaryEntry>(myEnum->Current);
      Console::WriteLine( "   {0,-25} {1}", de.Key, de.Value );
   }

   Console::WriteLine();
}

int main()
{
   
   // Creates and initializes a new HybridDictionary.
   HybridDictionary^ myCol = gcnew HybridDictionary;
   myCol->Add( "Braeburn Apples", "1.49" );
   myCol->Add( "Fuji Apples", "1.29" );
   myCol->Add( "Gala Apples", "1.49" );
   myCol->Add( "Golden Delicious Apples", "1.29" );
   myCol->Add( "Granny Smith Apples", "0.89" );
   myCol->Add( "Red Delicious Apples", "0.99" );
   myCol->Add( "Plantain Bananas", "1.49" );
   myCol->Add( "Yellow Bananas", "0.79" );
   myCol->Add( "Strawberries", "3.33" );
   myCol->Add( "Cranberries", "5.98" );
   myCol->Add( "Navel Oranges", "1.29" );
   myCol->Add( "Grapes", "1.99" );
   myCol->Add( "Honeydew Melon", "0.59" );
   myCol->Add( "Seedless Watermelon", "0.49" );
   myCol->Add( "Pineapple", "1.49" );
   myCol->Add( "Nectarine", "1.99" );
   myCol->Add( "Plums", "1.69" );
   myCol->Add( "Peaches", "1.99" );
   
   // Displays the values in the HybridDictionary in three different ways.
   Console::WriteLine( "Initial contents of the HybridDictionary:" );
   PrintKeysAndValues( myCol );
   
   // Deletes a key.
   myCol->Remove( "Plums" );
   Console::WriteLine( "The collection contains the following elements after removing \"Plums\":" );
   PrintKeysAndValues( myCol );
   
   // Clears the entire collection.
   myCol->Clear();
   Console::WriteLine( "The collection contains the following elements after it is cleared:" );
   PrintKeysAndValues( myCol );
}

/*
This code produces the following output.

Initial contents of the HybridDictionary:
   KEY                       VALUE
   Seedless Watermelon       0.49
   Nectarine                 1.99
   Cranberries               5.98
   Plantain Bananas          1.49
   Honeydew Melon            0.59
   Pineapple                 1.49
   Strawberries              3.33
   Grapes                    1.99
   Braeburn Apples           1.49
   Peaches                   1.99
   Red Delicious Apples      0.99
   Golden Delicious Apples   1.29
   Yellow Bananas            0.79
   Granny Smith Apples       0.89
   Gala Apples               1.49
   Plums                     1.69
   Navel Oranges             1.29
   Fuji Apples               1.29

The collection contains the following elements after removing "Plums":
   KEY                       VALUE
   Seedless Watermelon       0.49
   Nectarine                 1.99
   Cranberries               5.98
   Plantain Bananas          1.49
   Honeydew Melon            0.59
   Pineapple                 1.49
   Strawberries              3.33
   Grapes                    1.99
   Braeburn Apples           1.49
   Peaches                   1.99
   Red Delicious Apples      0.99
   Golden Delicious Apples   1.29
   Yellow Bananas            0.79
   Granny Smith Apples       0.89
   Gala Apples               1.49
   Navel Oranges             1.29
   Fuji Apples               1.29

The collection contains the following elements after it is cleared:
   KEY                       VALUE

*/
// </snippet1>
