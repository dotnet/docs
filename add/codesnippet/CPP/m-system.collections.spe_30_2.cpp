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