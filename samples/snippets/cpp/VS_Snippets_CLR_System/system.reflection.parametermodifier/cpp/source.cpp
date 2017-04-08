
using namespace System;
using namespace System::Reflection;

public ref class ParmInfoTest
{
public:
    static void Main()
    {
        Object^ obj = gcnew ParmInfoTest;

        // <Snippet1>
        // Create an array containing the arguments.
        array<Object^>^ args = {"Argument 1", "Argument 2", "Argument 3" };

        // Initialize a ParameterModifier with the number of parameters.
        ParameterModifier p = ParameterModifier(3);

        // Pass the first and third parameters by reference.
        p[0] = true;
        p[2] = true;

        // The ParameterModifier must be passed as the single element
        // of an array.

        array<ParameterModifier>^ mods = { p };

        // Invoke the method late bound.
        obj->GetType()->InvokeMember("MethodName", BindingFlags::InvokeMethod,
             nullptr, obj, args, mods, nullptr, nullptr);
        // </Snippet1>
    }

    void MethodName(String^% str1, String^ str2, String^% str3)
    {
        Console::WriteLine("Called 'MethodName'");
    }
};

int main()
{
    ParmInfoTest::Main();
}



