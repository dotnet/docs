// <snippet1>
// This program lists all the public constructors
// of the System.String class.
using namespace System;
using namespace System::Reflection;

class ListMembers
{
public:
    static void Main()
    {
        Type^ t = System::String::typeid;
        Console::WriteLine ("Listing all the public constructors of the {0} type", t);
        // Constructors.
        array<ConstructorInfo^>^ ci = t->GetConstructors(BindingFlags::Public | BindingFlags::Instance);
        Console::WriteLine ("//Constructors");
        PrintMembers(ci);
    }

    static void PrintMembers(array<MemberInfo^>^ ms)
    {
        for each (MemberInfo^ m in ms)
        {
            Console::WriteLine ("{0}{1}", "     ", m);
        }
        Console::WriteLine();
    }
};

int main()
{
    ListMembers::Main();
}
// </snippet1>
