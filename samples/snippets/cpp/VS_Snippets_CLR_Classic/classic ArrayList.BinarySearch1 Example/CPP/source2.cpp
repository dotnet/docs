//<Snippet2>
using namespace System;
using namespace System::Collections;

public ref class SimpleStringComparer : public IComparer
{
    virtual int Compare(Object^ x, Object^ y) sealed = IComparer::Compare
    {
        String^ cmpstr = (String^)x;
        return cmpstr->CompareTo((String^)y);
    }
};

public ref class MyArrayList : public ArrayList
{
public:
    static void Main()
    {
        // Creates and initializes a new ArrayList.
        MyArrayList^ coloredAnimals = gcnew MyArrayList();

        coloredAnimals->Add("White Tiger");
        coloredAnimals->Add("Pink Bunny");
        coloredAnimals->Add("Red Dragon");
        coloredAnimals->Add("Green Frog");
        coloredAnimals->Add("Blue Whale");
        coloredAnimals->Add("Black Cat");
        coloredAnimals->Add("Yellow Lion");

        // BinarySearch requires a sorted ArrayList.
        coloredAnimals->Sort();

        // Compare results of an iterative search with a binary search
        int index = coloredAnimals->IterativeSearch("White Tiger");
        Console::WriteLine("Iterative search, item found at index: {0}", index);

        index = coloredAnimals->BinarySearch("White Tiger", gcnew SimpleStringComparer());
        Console::WriteLine("Binary search, item found at index:    {0}", index);
    }

    int IterativeSearch(Object^ finditem)
    {
        int index = -1;

        for (int i = 0; i < this->Count; i++)
        {
            if (finditem->Equals(this[i]))
            {
                index = i;
                break;
            }
        }
        return index;
    }
};

int main()
{
    MyArrayList::Main();
}
//
// This code produces the following output.
//
// Iterative search, item found at index: 5
// Binary search, item found at index:    5
//
//</Snippet2>
