//<Snippet2>
using namespace System;
using namespace System::Collections;

public ref class ScrambleList : public ArrayList
{
public:
    static void Main()
    {
        // Create an empty ArrayList, and add some elements.
        ScrambleList^ integerList = gcnew ScrambleList();

        for (int i = 0; i < 10; i++)
        {
            integerList->Add(i);
        }

        Console::WriteLine("Ordered:\n");
        for each (int value in integerList)
        {
            Console::Write("{0}, ", value);
        }
        Console::WriteLine("<end>\n\nScrambled:\n");

        // Scramble the order of the items in the list.
        integerList->Scramble();

        for each (int value in integerList)
        {
            Console::Write("{0}, ", value);
        }
        Console::WriteLine("<end>\n");
    }

    void Scramble()
    {
        int limit = this->Count;
        int temp;
        int swapindex;
        Random^ rnd = gcnew Random();
        for (int i = 0; i < limit; i++)
        {
            // The Item property of ArrayList is the default indexer. Thus,
            // this->default[i] and this[i] are used interchangeably.
            temp = (int)this->default[i];
            swapindex = rnd->Next(0, limit - 1);
            this[i] = this->default[swapindex];
            this[swapindex] = temp;
        }
    }
};

int main()
{
    ScrambleList::Main();
}
// The program produces output similar to the following:
//
// Ordered:
//
// 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, <end>
//
// Scrambled:
//
// 5, 2, 8, 9, 6, 1, 7, 0, 4, 3, <end>
//</Snippet2>



