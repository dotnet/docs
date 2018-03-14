// <Snippet4>
using namespace System;
using namespace System::Globalization;

public ref class ParseInt32
{
public:
    static void Main()
    {
        SnippetA();
        SnippetB();
        SnippetC();
    }

    static void SnippetA()
    {
        // <Snippet5>
        String^ MyString = "12345";
        int MyInt = int::Parse(MyString);
        MyInt++;
        Console::WriteLine(MyInt);
        // The result is "12346".
        // </Snippet5>
    }

    static void SnippetB()
    {
        // <Snippet6>
        CultureInfo^ MyCultureInfo = gcnew CultureInfo("en-US");
        String^ MyString = "123,456";
        int MyInt = int::Parse(MyString, MyCultureInfo);
        Console::WriteLine(MyInt);
        // Raises System.Format exception.
        // </Snippet6>
    }

    static void SnippetC()
    {
        // <Snippet7>
        CultureInfo^ MyCultureInfo = gcnew CultureInfo("en-US");
        String^ MyString = "123,456";
        int MyInt = int::Parse(MyString, NumberStyles::AllowThousands, MyCultureInfo);
        Console::WriteLine(MyInt);
        // The result is "123456".
        // </Snippet7>
    }
};

int main()
{
    ParseInt32::Main();
}
// </Snippet4>
