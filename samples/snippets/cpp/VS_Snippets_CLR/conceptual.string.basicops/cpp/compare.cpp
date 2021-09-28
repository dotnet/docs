//<snippet5>
using namespace System;

ref class Example
{
public:
    static void Main()
    {
        Compare();
        CompareOrdinal();
        CompareTo();
        Equals1();
        Equals2();
        StartsWith();
        EndsWith();
        IndexOf();
        LastIndexOf();
    }

    static void Compare()
    {
        //<snippet6>
        String^ string1 = "Hello World!";
        Console::WriteLine(String::Compare(string1, "Hello World?"));
        //</snippet6>
    }

    static void CompareOrdinal()
    {
        //<snippet7>
        String^ string1 = "Hello World!";
        Console::WriteLine(String::CompareOrdinal(string1, "hello world!"));
        //</snippet7>
    }

    static void CompareTo()
    {
        //<snippet8>
        String^ string1 = "Hello World";
        String^ string2 = "Hello World!";
        int MyInt = string1->CompareTo(string2);
        Console::WriteLine( MyInt );
        //</snippet8>
    }

    static void Equals1()
    {
        //<snippet9>
        String^ string1 = "Hello World";
        Console::WriteLine(string1->Equals("Hello World"));
        //</snippet9>
    }

    static void Equals2()
    {
        //<snippet10>
        String^ string1 = "Hello World";
        String^ string2 = "Hello World";
        Console::WriteLine(String::Equals(string1, string2));
        //</snippet10>
    }

    static void StartsWith()
    {
        //<snippet11>
        String^ string1 = "Hello World";
        Console::WriteLine(string1->StartsWith("Hello"));
        //</snippet11>
    }

    static void EndsWith()
    {
        //<snippet12>                                                                        
        String^ string1 = "Hello World";
        Console::WriteLine(string1->EndsWith("Hello"));
        //</snippet12>
    }

    static void IndexOf()
    {
        //<snippet13>
        String^ string1 = "Hello World";
        Console::WriteLine(string1->IndexOf('l'));
        //</snippet13>
    }

    static void LastIndexOf()
    {
        //<snippet14>
        String^ string1 = "Hello World";
        Console::WriteLine(string1->LastIndexOf('l'));
        //</snippet14>
    }
};

int main()
{
    Example::Main();
}
//</snippet5>
