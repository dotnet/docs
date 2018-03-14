
//<Snippet1>
using namespace System;

int main()
{
    // Define Boolean true and false values.
    array<bool>^ values = { true, false };

    // Display the value and its corresponding byte array.
    Console::WriteLine("{0,10}{1,16}\n", "Boolean", "Bytes");
    for each (Byte value in values) {
       array<Byte>^ bytes = BitConverter::GetBytes(value); 
       Console::WriteLine("{0,10}{1,16}", value, 
                          BitConverter::ToString(bytes));
    }
}
// This example displays the following output:
//        Boolean           Bytes
//     
//           True              01
//          False              00
//</Snippet1>
