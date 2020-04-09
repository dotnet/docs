using namespace System;
using namespace System::Reflection;

ref class Asminfo1
{
public:
    static void Main()
    {
        Console::WriteLine ("\nReflection.MemberInfo");

        // Get the Type and MemberInfo.
        // Insert the fully qualified class name inside the quotation marks in the
        // following statement.
        Type^ MyType = Type::GetType("System.IO.BinaryReader");
        array<MemberInfo^>^ Mymemberinfoarray = MyType->GetMembers(BindingFlags::Public |
            BindingFlags::NonPublic | BindingFlags::Static |
            BindingFlags::Instance | BindingFlags::DeclaredOnly);

        // Get and display the DeclaringType method.
        Console::Write($"\nThere are {Mymemberinfoarray->Length} documentable members in ");
        Console::Write($"{MyType->FullName}.");

        for each (MemberInfo^ Mymemberinfo in Mymemberinfoarray)
        {
            Console::Write("\n" + Mymemberinfo->Name);
        }
    }
};

int main()
{
    Asminfo1::Main();
}
