// <snippet2>
using namespace System;
using namespace System::IO;
using namespace System::Reflection;

public ref class MyMemberInfo
{
public:
    static void Main()
    {
        Console::WriteLine ("\nReflection.MemberInfo");
        // Gets the Type and MemberInfo.
        Type^ myType = Type::GetType("System.IO.File");
        array<MemberInfo^>^ myMemberInfoArray = myType->GetMembers();
        // Gets and displays the DeclaringType method.
        Console::WriteLine("\nThere are {0} members in {1}.",
            myMemberInfoArray->Length, myType->FullName);
        Console::WriteLine("{0}.", myType->FullName);
        if (myType->IsPublic)
        {
            Console::WriteLine("{0} is public.", myType->FullName);
        }
    }
};

int main()
{
    MyMemberInfo::Main();
}
// </snippet2>
