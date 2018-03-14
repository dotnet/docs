//<snippet23>
#using <System.dll>

using namespace System;
using namespace System::Collections::Generic;

ref class AdvantageGenerics
{
public:
    static void Main()
    {
        array<String^>^ myArray =
            {"First String", "test string",  "Last String"};

        //<snippet24>
        LinkedList<String^>^ llist = gcnew LinkedList<String^>();
        //</snippet24>

        for each (String^ item in myArray)
        {
            llist->AddLast(item);
        }
        LinkedListNode<String^>^ found = llist->Find("test string");
        if (found != nullptr)
        {
            Console::WriteLine("Item found: {0}", found->Value);
        }
        //<snippet25>
        int index0 = Array::BinarySearch(myArray, "test string");
        int index1 = Array::BinarySearch<String^>(myArray, "test string");
        //</snippet25>

        Console::WriteLine("Indexes for binary searches: {0}, {1}", index0, index1);
    }
};

int main()
{
    AdvantageGenerics::Main();
}
//</snippet23>
