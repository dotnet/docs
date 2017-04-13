// <Snippet1>
using namespace System;

public ref class SamplesArray
{
public:
    static void Main()
    {
        // Creates and initializes a new Array.
        Array^ myIntArray = Array::CreateInstance(Int32::typeid, 5);

        myIntArray->SetValue(8, 0);
        myIntArray->SetValue(2, 1);
        myIntArray->SetValue(6, 2);
        myIntArray->SetValue(3, 3);
        myIntArray->SetValue(7, 4);

        // Do the required sort first
        Array::Sort(myIntArray);

        // Displays the values of the Array.
        Console::WriteLine("The Int32 array contains the following:");
        PrintValues(myIntArray);

        // Locates a specific object that does not exist in the Array.
        Object^ myObjectOdd = 1;
        FindMyObject(myIntArray, myObjectOdd);

        // Locates an object that exists in the Array.
        Object^ myObjectEven = 6;
        FindMyObject(myIntArray, myObjectEven);
    }

    static void FindMyObject(Array^ myArr, Object^ myObject)
    {
        int myIndex = Array::BinarySearch(myArr, myObject);
        if (myIndex < 0)
        {
            Console::WriteLine("The object to search for ({0}) is not found. The next larger object is at index {1}.", myObject, ~myIndex);
        }
        else
        {
            Console::WriteLine("The object to search for ({0}) is at index {1}.", myObject, myIndex);
        }
    }

    static void PrintValues(Array^ myArr)
    {
        int i = 0;
        int cols = myArr->GetLength(myArr->Rank - 1);
        for each (Object^ o in myArr)
        {
            if ( i < cols )
            {
                i++;
            }
            else
            {
                Console::WriteLine();
                i = 1;
            }
            Console::Write("\t{0}", o);
        }
        Console::WriteLine();
    }
};

int main()
{
    SamplesArray::Main();
}
// This code produces the following output.
//
//The Int32 array contains the following:
//        2       3       6       7       8
//The object to search for (1) is not found. The next larger object is at index 0
//
//The object to search for (6) is at index 2.
// </Snippet1>

