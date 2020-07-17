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
        StringBuilder^ myStringBuilder = gcnew StringBuilder("Hello World!");
        // </Snippet1>
    }

    static void InstantiateWithCapacity()
    {
        // <Snippet2>
        StringBuilder^ myStringBuilder = gcnew StringBuilder("Hello World!", 25);
        // </Snippet2>
        // <Snippet3>
        myStringBuilder->Capacity = 25;
        // </Snippet3>
    }

    static void Appending()
    {
        // <Snippet4>
        StringBuilder^ myStringBuilder = gcnew StringBuilder("Hello World!");
        myStringBuilder->Append(" What a beautiful day.");
        Console::WriteLine(myStringBuilder);
        // The example displays the following output:
        //       Hello World! What a beautiful day.
        // </Snippet4>
    }

    static void AppendingFormat()
    {
        // <Snippet5>
        int MyInt = 25;
        StringBuilder^ myStringBuilder = gcnew StringBuilder("Your total is ");
        myStringBuilder->AppendFormat("{0:C} ", MyInt);
        Console::WriteLine(myStringBuilder);
        // The example displays the following output:
        //       Your total is $25.00
        // </Snippet5>
    }

    static void Inserting()
    {
        // <Snippet6>
        StringBuilder^ myStringBuilder = gcnew StringBuilder("Hello World!");
        myStringBuilder->Insert(6,"Beautiful ");
        Console::WriteLine(myStringBuilder);
        // The example displays the following output:
        //       Hello Beautiful World!
        // </Snippet6>
    }

    static void Removing()
    {
        // <Snippet7>
        StringBuilder^ myStringBuilder = gcnew StringBuilder("Hello World!");
        myStringBuilder->Remove(5,7);
        Console::WriteLine(myStringBuilder);
        // The example displays the following output:
        //       Hello
        // </Snippet7>
    }

    static void Replacing()
    {
        // <Snippet8>
        StringBuilder^ myStringBuilder = gcnew StringBuilder("Hello World!");
        myStringBuilder->Replace('!', '?');
        Console::WriteLine(myStringBuilder);
        // The example displays the following output:
        //       Hello World?
        // </Snippet8>
    }
};

int main()
{
    Example::Main();
}
