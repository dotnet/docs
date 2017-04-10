//<Snippet1>
using namespace System;
using namespace System::Collections;

namespace UsageLibrary
{
   public ref class WritableCollection
   {
   public:
      // Violates the rule.
      property ArrayList^ SomeStrings;

      WritableCollection()
      {
         SomeStrings = gcnew ArrayList(
            gcnew array<String^> {"IEnumerable", "ICollection", "IList"} );
      }
   };
}

using namespace UsageLibrary;

void main()
{
   ArrayList^ newCollection = gcnew ArrayList(
      gcnew array<String^> {"a", "new", "collection"} );

   // strings is directly replaced with newCollection.
   WritableCollection^ collection = gcnew WritableCollection();
   collection->SomeStrings = newCollection;

   // newCollection is added to the cleared strings collection.
   collection->SomeStrings->Clear();
   collection->SomeStrings->AddRange(newCollection);
}
//</Snippet1>
