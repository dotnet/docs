// <Snippet2>
using namespace System;

namespace ExampleA
{
    // <Snippet3>
    public ref class ObsoleteAttribute{};
    // </Snippet3>
}

namespace ExampleB
{
    // <Snippet4>
    [AttributeUsage(AttributeTargets::All, Inherited = false, AllowMultiple = true)]
    public ref class ObsoleteAttribute : Attribute {};
    // </Snippet4>

    // <Snippet5>
    public ref class NameAttribute : Attribute
    {
    private:
        String^ userName;
        int age;

        // This is a positional argument.
    public:
        NameAttribute(String^ userName)
        {
            this->userName = userName;
        }

        property String^ UserName
        {
            String^ get()
            {
                return userName;
            }
        }

        // This is a named argument.
        property int Age
        {
            int get()
            {
                return age;
            }
            void set(int value)
            {
                age = value;
            }
        }
    };
    // </Snippet5>

    ref class Dummy
    {
    public:
        static void Main()
        {
            Console::WriteLine("Dummy.Main()");
        }
    };
}

int main()
{
    ExampleB::Dummy::Main();
}
// </Snippet2>

