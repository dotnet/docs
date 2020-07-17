// <snippet2>
using namespace System;
using namespace System::IO;
using namespace System::Reflection;

public ref class Mymemberinfo
{
public:
    static void Main()
    {
        Console::WriteLine ("\nReflection.MemberInfo");
        // Gets the Type and MemberInfo.
        Type^ MyType = Type::GetType("System.IO.File");
        array<MemberInfo^>^ Mymemberinfoarray = MyType->GetMembers();
        // Gets and displays the DeclaringType method.
        Console::WriteLine("\nThere are {0} members in {1}.",
            Mymemberinfoarray->Length, MyType->FullName);
        Console::WriteLine("{0}.", MyType->FullName);
        if (MyType->IsPublic)
        {
            Console::WriteLine("{0} is public.", MyType->FullName);
        }
    }
};

int main()
{
    Mymemberinfo::Main();
}
// </snippet2>
