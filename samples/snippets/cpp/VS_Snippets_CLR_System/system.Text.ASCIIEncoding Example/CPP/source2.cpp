//<snippet2>
using namespace System;
using namespace System::Text;

ref class BaseTypeEncoding
{
public:
    static void Main()
    {
        SnippetA();
        SnippetB();
    }

    static void SnippetA()
    {
        //<snippet3>
        String^ MyString = "Encoding String.";
        ASCIIEncoding^ AE = gcnew ASCIIEncoding();
        array<Byte>^ ByteArray = AE->GetBytes(MyString);
        for (int x = 0; x < ByteArray->Length; x++)
        {
            Console::Write("{0} ", ByteArray[x]);
        }
        //</snippet3>
    }

    static void SnippetB()
    {
        //<snippet4>
        ASCIIEncoding^ AE = gcnew ASCIIEncoding();
        array<Byte>^ ByteArray = {69, 110, 99, 111, 100, 105, 110, 103,
            32, 83, 116, 114, 105, 110, 103, 46 };
        array<Char>^ CharArray = AE->GetChars(ByteArray);
        for (int x = 0; x < CharArray->Length; x++)
        {
            Console::Write(CharArray[x]);
        }
        //</snippet4>
    }
};

int main()
{
    BaseTypeEncoding::Main();
}
//</snippet2>
