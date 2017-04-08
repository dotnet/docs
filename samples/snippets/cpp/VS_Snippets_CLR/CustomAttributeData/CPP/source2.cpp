// <snippet2>
using namespace System;

public ref class ExampleAttribute : Attribute
{
private:
    String^ stringVal;

public:
    ExampleAttribute()
    {
        stringVal = "This is the default string.";
    }


    property String^ StringValue
    {
        String^ get() { return stringVal; }
        void set(String^ value) { stringVal = value; }
    }
};

[Example(StringValue="This is a string.")]
public ref class Class1
{
public:
    static void Main()
    {
        System::Reflection::MemberInfo^ info = Type::GetType("Class1");
        for each (Object^ attrib in info->GetCustomAttributes(true))
        {
            Console::WriteLine(attrib);
        }
    }
};

int main()
{
    Class1::Main();
}
// </snippet2>
