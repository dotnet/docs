//<Snippet1>
using namespace System;
using namespace System::Reflection;

public ref class Test
{
public:
    virtual String^ ToString() override
    {
        return "An instance of class Test!";
    }
};

int main()
{
    Test^ target = gcnew Test();
    MethodInfo^ toStringInfo = target->GetType()->GetMethod("ToString");
    Console::WriteLine("{0} is defined in {1}", toStringInfo->Name,
        toStringInfo->Module->Name);

    MethodInfo^ getHashCodeInfo = target->GetType()->GetMethod("GetHashCode");
    Console::WriteLine("{0} is defined in {1}", getHashCodeInfo->Name,
        getHashCodeInfo->Module->Name);
}

/*
* This example produces the following console output:
*
* ToString is defined in source.exe
* GetHashCode is defined in mscorlib.dll
*/
//</Snippet1>
