// <Snippet11>
using namespace System;
using namespace System::Text;
// </Snippet11>

[assembly:CLSCompliant(true)];
public ref class Example
{
public:
    static void Main()
    {
        InstantiateStringBuilder();
        InstantiateWithCapacity();
        Appending();
        AppendingFormat();
        Inserting();
        Removing();
        Replacing();
    }

private:
    static void InstantiateStringBuilder()
    {
        // <Snippet1>
        StringBuilder^ MyStringBuilder = gcnew StringBuilder("Hello World!");
        // </Snippet1>
    }

    static void InstantiateWithCapacity()
    {
        // <Snippet2>
        StringBuilder^ MyStringBuilder = gcnew StringBuilder("Hello World!", 25);
        // </Snippet2>
        // <Snippet3>
        MyStringBuilder->Capacity = 25;
        // </Snippet3>
    }

    static void Appending()
    {
        // <Snippet4>
        StringBuilder^ MyStringBuilder = gcnew StringBuilder("Hello World!");
        MyStringBuilder->Append(" What a beautiful day.");
        Console::WriteLine(MyStringBuilder);
        // The example displays the following output:
        //       Hello World! What a beautiful day.
        // </Snippet4>
    }

    static void AppendingFormat()
    {
        // <Snippet5>
        int MyInt = 25;
        StringBuilder^ MyStringBuilder = gcnew StringBuilder("Your total is ");
        MyStringBuilder->AppendFormat("{0:C} ", MyInt);
        Console::WriteLine(MyStringBuilder);
        // The example displays the following output:
        //       Your total is $25.00
        // </Snippet5>
    }

    static void Inserting()
    {
        // <Snippet6>
        StringBuilder^ MyStringBuilder = gcnew StringBuilder("Hello World!");
        MyStringBuilder->Insert(6,"Beautiful ");
        Console::WriteLine(MyStringBuilder);
        // The example displays the following output:
        //       Hello Beautiful World!
        // </Snippet6>
    }

    static void Removing()
    {
        // <Snippet7>
        StringBuilder^ MyStringBuilder = gcnew StringBuilder("Hello World!");
        MyStringBuilder->Remove(5,7);
        Console::WriteLine(MyStringBuilder);
        // The example displays the following output:
        //       Hello
        // </Snippet7>
    }

    static void Replacing()
    {
        // <Snippet8>
        StringBuilder^ MyStringBuilder = gcnew StringBuilder("Hello World!");
        MyStringBuilder->Replace('!', '?');
        Console::WriteLine(MyStringBuilder);
        // The example displays the following output:
        //       Hello World?
        // </Snippet8>
    }
};

int main()
{
    Example::Main();
}
