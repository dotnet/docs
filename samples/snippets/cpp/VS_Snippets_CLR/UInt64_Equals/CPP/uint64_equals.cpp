// <Snippet1>
using namespace System;

int main()
{
      UInt64 value1 = 50;
      UInt64 value2 = 50;

      // Display the values.
        Console::WriteLine("value1:   Type: {0}   Value: {1}",
                           value1.GetType()->Name, value1);
        Console::WriteLine("value2:   Type: {0}   Value: {1}",
                         value2.GetType()->Name, value2);

        // Compare the two values.
        Console::WriteLine("value1 and value2 are equal: {0}",
                           value1.Equals(value2));
}
// The example displays the following output:
//       value1:   Type: UInt64   Value: 50
//       value2:   Type: UInt64   Value: 50
//       value1 and value2 are equal: True
// </Snippet1>
