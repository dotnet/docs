// The following code example enumerates the elements of a OrderedDictionary.
#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Collections::Specialized;

public ref class OrderedDictionarySample
{
public:
    static void Main()
    {
        // Creates and initializes a OrderedDictionary.
        OrderedDictionary^ myOrderedDictionary = gcnew OrderedDictionary();
        myOrderedDictionary->Add("testKey1", "testValue1");
        myOrderedDictionary->Add("testKey2", "testValue2");
        myOrderedDictionary->Add("keyToDelete", "valueToDelete");
        myOrderedDictionary->Add("testKey3", "testValue3");

        ICollection^ keyCollection = myOrderedDictionary->Keys;
        ICollection^ valueCollection = myOrderedDictionary->Values;

        // Display the contents using the key and value collections
        DisplayContents(keyCollection, valueCollection, myOrderedDictionary->Count);

        // Modifying the OrderedDictionary
        if (!myOrderedDictionary->IsReadOnly)
        {
            // Insert a new key to the beginning of the OrderedDictionary
            myOrderedDictionary->Insert(0, "insertedKey1", "insertedValue1");

            // Modify the value of the entry with the key "testKey2"
            myOrderedDictionary["testKey2"] = "modifiedValue";

            // Remove the last entry from the OrderedDictionary: "testKey3"
            myOrderedDictionary->RemoveAt(myOrderedDictionary->Count - 1);

            // Remove the "keyToDelete" entry, if it exists
            if (myOrderedDictionary->Contains("keyToDelete"))
            {
                myOrderedDictionary->Remove("keyToDelete");
            }
        }

        Console::WriteLine(
            "{0}Displaying the entries of a modified OrderedDictionary.",
            Environment::NewLine);
        DisplayContents(keyCollection, valueCollection, myOrderedDictionary->Count);

        // Clear the OrderedDictionary and add new values
        myOrderedDictionary->Clear();
        myOrderedDictionary->Add("newKey1", "newValue1");
        myOrderedDictionary->Add("newKey2", "newValue2");
        myOrderedDictionary->Add("newKey3", "newValue3");

        // Display the contents of the "new" Dictionary using an enumerator
        IDictionaryEnumerator^ myEnumerator =
            myOrderedDictionary->GetEnumerator();

        Console::WriteLine(
            "{0}Displaying the entries of a \"new\" OrderedDictionary.",
            Environment::NewLine);

        DisplayEnumerator(myEnumerator);

        Console::ReadLine();
    }

    // Displays the contents of the OrderedDictionary from its keys and values
    static void DisplayContents(
        ICollection^ keyCollection, ICollection^ valueCollection, int dictionarySize)
    {
        array<String^>^ myKeys = gcnew array<String^>(dictionarySize);
        array<String^>^ myValues = gcnew array<String^>(dictionarySize);
        keyCollection->CopyTo(myKeys, 0);
        valueCollection->CopyTo(myValues, 0);

        // Displays the contents of the OrderedDictionary
        Console::WriteLine("   INDEX KEY                       VALUE");
        for (int i = 0; i < dictionarySize; i++)
        {
            Console::WriteLine("   {0,-5} {1,-25} {2}",
                i, myKeys[i], myValues[i]);
        }
        Console::WriteLine();
    }

    // Displays the contents of the OrderedDictionary using its enumerator
    static void DisplayEnumerator(IDictionaryEnumerator^ myEnumerator)
    {
        Console::WriteLine("   KEY                       VALUE");
        while (myEnumerator->MoveNext())
        {
            Console::WriteLine("   {0,-25} {1}",
                myEnumerator->Key, myEnumerator->Value);
        }
    }
};

int main()
{
    OrderedDictionarySample::Main();
}

/*
This code produces the following output.

   INDEX KEY                       VALUE
   0     testKey1                  testValue1
   1     testKey2                  testValue2
   2     keyToDelete               valueToDelete
   3     testKey3                  testValue3


Displaying the entries of a modified OrderedDictionary.
   INDEX KEY                       VALUE
   0     insertedKey1              insertedValue1
   1     testKey1                  testValue1
   2     testKey2                  modifiedValue


Displaying the entries of a "new" OrderedDictionary.
   KEY                       VALUE
   newKey1                   newValue1
   newKey2                   newValue2
   newKey3                   newValue3

*/