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