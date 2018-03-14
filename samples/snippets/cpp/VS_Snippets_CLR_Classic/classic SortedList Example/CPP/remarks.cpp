using namespace System;
using namespace System::Collections;

public ref class SamplesSortedList
{
public:
    static void Main()
    {
        // Creates and initializes a new SortedList.
        SortedList^ mySortedList = gcnew SortedList();
        mySortedList->Add("Third", "!");
        mySortedList->Add("Second", "World");
        mySortedList->Add("First", "Hello");

        // <Snippet2>
        for each (DictionaryEntry de in mySortedList)
        {
            //...
        }
        // </Snippet2>
    }
};

int main()
{
    SamplesSortedList::Main();
}