//<snippet15>
using namespace System;

ref class Example
{
public:
    static void Main()
    {
        Trim();
        TrimEnd1();
        TrimEnd2();
        TrimStart();
        Remove();
    }

    static void Trim()
    {
        // <snippet17>
        String^ MyString = " Big   ";
        Console::WriteLine("Hello{0}World!", MyString);
        String^ TrimString = MyString->Trim();
        Console::WriteLine("Hello{0}World!", TrimString);
        // The example displays the following output:
        //       Hello Big   World!
        //       HelloBigWorld!        
        // </snippet17>
    }


    static void TrimEnd1()
    {
        // <snippet18>
        String^ MyString = "Hello World!";
        array<Char>^ MyChar = {'r','o','W','l','d','!',' '};
        String^ NewString = MyString->TrimEnd(MyChar);
        Console::WriteLine(NewString);
        // </snippet18>
    }
    
    static void TrimEnd2()
    {
        // <snippet19>
        String^ MyString = "Hello, World!";
        array<Char>^ MyChar = {'r','o','W','l','d','!',' '};
        String^ NewString = MyString->TrimEnd(MyChar);
        Console::WriteLine(NewString);
        // </snippet19>
    }

    static void TrimStart()
    {
        // <snippet20>
        String^ MyString = "Hello World!";
        array<Char>^ MyChar = {'e', 'H','l','o',' ' };
        String^ NewString = MyString->TrimStart(MyChar);
        Console::WriteLine(NewString);
        // </snippet20>
    }

    static void Remove()
    {
        // <snippet21>
        String^ MyString = "Hello Beautiful World!";
        Console::WriteLine(MyString->Remove(5,10));
        // The example displays the following output:
        //         Hello World!        
        // </snippet21>
    }
};

int main()
{
    Example::Main();
}
//</snippet15>
