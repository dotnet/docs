    static void Main()
    {
        HashSet<int>^ lowNumbers = gcnew HashSet<int>();
        HashSet<int>^ highNumbers = gcnew HashSet<int>();

        for (int i = 0; i < 6; i++)
        {
            lowNumbers->Add(i);
        }

        for (int i = 3; i < 10; i++)
        {
            highNumbers->Add(i);
        }

        Console::Write("lowNumbers contains {0} elements: ", lowNumbers->Count);
        DisplaySet(lowNumbers);

        Console::Write("highNumbers contains {0} elements: ", highNumbers->Count);
        DisplaySet(highNumbers);

        Console::WriteLine("highNumbers ExceptWith lowNumbers...");
        highNumbers->ExceptWith(lowNumbers);

        Console::Write("highNumbers contains {0} elements: ", highNumbers->Count);
        DisplaySet(highNumbers);
    }
    /* This example provides output similar to the following:
     * lowNumbers contains 6 elements: { 0 1 2 3 4 5 }
     * highNumbers contains 7 elements: { 3 4 5 6 7 8 9 }
     * highNumbers ExceptWith lowNumbers...
     * highNumbers contains 4 elements: { 6 7 8 9 }
     */