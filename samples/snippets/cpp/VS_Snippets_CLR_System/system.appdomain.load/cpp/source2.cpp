//<snippet2>
using namespace System;
using namespace System::Reflection;

public ref class Asmload0
{
public:
    static void Main()
    {
        // Use the file name to load the assembly into the current
        // application domain.
        Assembly^ a = Assembly::Load("example");
        // Get the type to use.
        Type^ myType = a->GetType("Example");
        // Get the method to call.
        MethodInfo^ myMethod = myType->GetMethod("MethodA");
        // Create an instance.
        Object^ obj = Activator::CreateInstance(myType);
        // Execute the method.
        myMethod->Invoke(obj, nullptr);
    }
};

int main()
{
    Asmload0::Main();
}
//</snippet2>
