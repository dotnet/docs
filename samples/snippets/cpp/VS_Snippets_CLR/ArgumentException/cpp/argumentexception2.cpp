// <Snippet3>
using namespace System;

static int DivideByTwo(int num) 
{
    // If num is an odd number, throw an ArgumentException.
    if ((num & 1) == 1)
        throw gcnew ArgumentException(String::Format("{0} is not an even number", num), 
                                      "num");

    // num is even, return half of its value.
    return num / 2;
}

void main() 
{
    // Define some integers for a division operation.
    array<int>^ values = { 10, 7 };
    for each (int value in values) {
        try {
           Console::WriteLine("{0} divided by 2 is {1}", value, DivideByTwo(value));
        }
        catch (ArgumentException^ e) {
           Console::WriteLine("{0}: {1}", e->GetType()->Name, e->Message);
        }
        Console::WriteLine();
    }
}
// This example displays the following output:
//     10 divided by 2 is 5
//     
//     ArgumentException: 7 is not an even number
//     Parameter name: num
//</snippet3>