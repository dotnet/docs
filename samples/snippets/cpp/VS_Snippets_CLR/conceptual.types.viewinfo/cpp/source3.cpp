// <snippet3>
// This code displays information about the GetValue method of FieldInfo.
using namespace System;
using namespace System::Reflection;

public ref class MyMethodInfo
{
public:
    static int Main()
    {
        Console::WriteLine("Reflection.MethodInfo");
        // Gets and displays the Type.
        Type^ MyType = Type::GetType("System.Reflection.FieldInfo");
        // Specifies the member for which you want type information.
        MethodInfo^ Mymethodinfo = MyType->GetMethod("GetValue");
        Console::WriteLine(MyType->FullName + "." + Mymethodinfo->Name);
        // Gets and displays the MemberType property.
        MemberTypes Mymembertypes = Mymethodinfo->MemberType;
        if (MemberTypes::Constructor == Mymembertypes)
        {
            Console::WriteLine("MemberType is of type All");
        }
        else if (MemberTypes::Custom == Mymembertypes)
        {
            Console::WriteLine("MemberType is of type Custom");
        }
        else if (MemberTypes::Event == Mymembertypes)
        {
            Console::WriteLine("MemberType is of type Event");
        }
        else if (MemberTypes::Field == Mymembertypes)
        {
            Console::WriteLine("MemberType is of type Field");
        }
        else if (MemberTypes::Method == Mymembertypes)
        {
            Console::WriteLine("MemberType is of type Method");
        }
        else if (MemberTypes::Property == Mymembertypes)
        {
            Console::WriteLine("MemberType is of type Property");
        }
        else if (MemberTypes::TypeInfo == Mymembertypes)
        {
            Console::WriteLine("MemberType is of type TypeInfo");
        }
        return 0;
    }
};

int main()
{
    MyMethodInfo::Main();
}
// </snippet3>
