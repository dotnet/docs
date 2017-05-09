// <Snippet1>
using namespace System;
using namespace System::Reflection;

public ref class MagicClass
{
private:
    int magicBaseValue;

public:
    MagicClass()
    {
        magicBaseValue = 9;
    }

    int ItsMagic(int preMagic)
    {
        return preMagic * magicBaseValue;
    }
};

public ref class TestMethodInfo
{
public:
    static void Main()
    {
        // Get the constructor and create an instance of MagicClass

        Type^ magicType = Type::GetType("MagicClass");
        ConstructorInfo^ magicConstructor = magicType->GetConstructor(Type::EmptyTypes);
        Object^ magicClassObject = magicConstructor->Invoke(gcnew array<Object^>(0));

        // Get the ItsMagic method and invoke with a parameter value of 100

        MethodInfo^ magicMethod = magicType->GetMethod("ItsMagic");
        Object^ magicValue = magicMethod->Invoke(magicClassObject, gcnew array<Object^>(1){100});

        Console::WriteLine("MethodInfo.Invoke() Example\n");
        Console::WriteLine("MagicClass.ItsMagic() returned: {0}", magicValue);
    }
};

int main()
{
    TestMethodInfo::Main();
}

// The example program gives the following output:
//
// MethodInfo.Invoke() Example
//
// MagicClass.ItsMagic() returned: 900
// </Snippet1>
