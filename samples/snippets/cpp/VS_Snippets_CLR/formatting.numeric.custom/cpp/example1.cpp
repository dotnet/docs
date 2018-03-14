using namespace System;

void main()
{
    // <Snippet10>
    double number1 = 1234567890;
    String^ value1 = number1.ToString("(###) ###-####");
    Console::WriteLine(value1);
    
    int number2 = 42;
    String^ value2 = number2.ToString("My Number = #");
    Console::WriteLine(value2);
    // The example displays the following output:
    //       (123) 456-7890
    //       My Number = 42
    // </Snippet10>      
}
