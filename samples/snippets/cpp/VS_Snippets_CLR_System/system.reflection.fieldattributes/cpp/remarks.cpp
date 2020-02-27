
using namespace System;
using namespace System::Reflection;

public ref class FieldAttribTest
{
public:
    static int field1 = 99;

    static void Main()
    {
        Object^ obj = gcnew FieldAttribTest();

        // <snippet1>
        FieldInfo^ fi = obj->GetType()->GetField("field1");

        if ((fi->Attributes & FieldAttributes::FieldAccessMask) ==
            FieldAttributes::Public)
        {
            Console::WriteLine("{0:s} is public. Value: {1:d}", fi->Name, fi->GetValue(obj));
        }
        // </snippet1>
    }
};

int main()
{
    FieldAttribTest::Main();
}



