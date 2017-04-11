// <Snippet1>
using namespace System;

void main()
{
    int value = -16325;
    // Display value using default ToString method.
    Console::WriteLine(value.ToString());             
    // Display value using some standard format specifiers.
    Console::WriteLine(value.ToString("G"));         
    Console::WriteLine(value.ToString("C"));         
    Console::WriteLine(value.ToString("D"));         
    Console::WriteLine(value.ToString("F"));         
    Console::WriteLine(value.ToString("N"));         
    Console::WriteLine(value.ToString("X"));              
}
// The example displays the following output:
//     -16325
//     -16325
//     ($16,325.00)
//     -16325
//     -16325.00
//     -16,325.00
//     FFFFC03B
// </Snippet1>

