
// <Snippet1>
using namespace System;
using namespace System::Reflection;
public ref class Program
{

    public:

        // Method to get:
        void MethodA() { }

    };

    int main()
    {

        // Get MethodA()
        MethodInfo^ mInfo = Program::typeid->GetMethod("MethodA",
            static_cast<BindingFlags>(BindingFlags::Public | BindingFlags::Instance));
        Console::WriteLine("Found method: {0}", mInfo );

    }
// </Snippet1>

