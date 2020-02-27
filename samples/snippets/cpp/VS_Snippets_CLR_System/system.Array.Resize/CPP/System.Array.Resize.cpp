
// The following example shows how resizing affects the array.
// <Snippet1>
using namespace System;
static void PrintIndexAndValues(array<String^>^myArr)
{
    for(int i = 0; i < myArr->Length; i++)
    {
       Console::WriteLine(L"   [{0}] : {1}", i, myArr[i]);
    }
    Console::WriteLine();
}

int main()
{
   
    // Create and initialize a new string array.
    array<String^>^myArr = {L"The", L"quick", L"brown", L"fox",
        L"jumps", L"over", L"the", L"lazy", L"dog"};
   
    // Display the values of the array.
    Console::WriteLine( 
        L"The string array initially contains the following values:");
    PrintIndexAndValues(myArr);
   
    // Resize the array to a bigger size (five elements larger).
    Array::Resize(myArr, myArr->Length + 5);
   
    // Display the values of the array.
    Console::WriteLine(L"After resizing to a larger size, ");
    Console::WriteLine(L"the string array contains the following values:");
    PrintIndexAndValues(myArr);
   
    // Resize the array to a smaller size (four elements).
    Array::Resize(myArr, 4);
   
    // Display the values of the array.
    Console::WriteLine(L"After resizing to a smaller size, ");
    Console::WriteLine(L"the string array contains the following values:");
    PrintIndexAndValues(myArr);
    return 1;
}

/* 
This code produces the following output.

The string array initially contains the following values:
   [0] : The
   [1] : quick
   [2] : brown
   [3] : fox
   [4] : jumps
   [5] : over
   [6] : the
   [7] : lazy
   [8] : dog

After resizing to a larger size, 
the string array contains the following values:
   [0] : The
   [1] : quick
   [2] : brown
   [3] : fox
   [4] : jumps
   [5] : over
   [6] : the
   [7] : lazy
   [8] : dog
   [9] :
   [10] :
   [11] :
   [12] :
   [13] :

After resizing to a smaller size, 
the string array contains the following values:
   [0] : The
   [1] : quick
   [2] : brown
   [3] : fox

*/
// </Snippet1>
