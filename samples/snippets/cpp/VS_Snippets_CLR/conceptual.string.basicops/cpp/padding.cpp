// <snippet2>
using namespace System;

ref class Example
{
public:
    static void Main()
    {
        PadLeft();
        PadRight();
    }

    static void PadLeft()
    {
        // <snippet3>
        String^ MyString = "Hello World!";
        Console::WriteLine(MyString->PadLeft(20, '-'));
        // </snippet3>
    }

    static void PadRight()
    {
        // <snippet4>
        String^ MyString = "Hello World!";
        Console::WriteLine(MyString->PadRight(20, '-'));
        // </snippet4>
    }
};

int main()
{
    Example::Main();
}
// </snippet2>
