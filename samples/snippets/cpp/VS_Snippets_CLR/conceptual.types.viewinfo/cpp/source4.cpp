// <snippet4>
// This program lists all the members of the
// System.IO.BufferedStream class.
using namespace System;
using namespace System::IO;
using namespace System::Reflection;

public ref class ListMembers
{
public:
    static void Main()
    {
        // Specifies the class.
        Type^ t = System::IO::BufferedStream::typeid;
        Console::WriteLine("Listing all the members (public and non public) of the {0} type", t);

        // Lists static fields first.
        array<FieldInfo^>^ fi = t->GetFields(BindingFlags::Static |
            BindingFlags::NonPublic | BindingFlags::Public);
        Console::WriteLine("// Static Fields");
        PrintMembers(fi);

        // Static properties.
        array<PropertyInfo^>^ pi = t->GetProperties(BindingFlags::Static |
            BindingFlags::NonPublic | BindingFlags::Public);
        Console::WriteLine("// Static Properties");
        PrintMembers(pi);

        // Static events.
        array<EventInfo^>^ ei = t->GetEvents(BindingFlags::Static |
            BindingFlags::NonPublic | BindingFlags::Public);
        Console::WriteLine("// Static Events");
        PrintMembers(ei);

        // Static methods.
        array<MethodInfo^>^ mi = t->GetMethods (BindingFlags::Static |
            BindingFlags::NonPublic | BindingFlags::Public);
        Console::WriteLine("// Static Methods");
        PrintMembers(mi);

        // Constructors.
        array<ConstructorInfo^>^ ci = t->GetConstructors(BindingFlags::Instance |
            BindingFlags::NonPublic | BindingFlags::Public);
        Console::WriteLine("// Constructors");
        PrintMembers(ci);

        // Instance fields.
        fi = t->GetFields(BindingFlags::Instance | BindingFlags::NonPublic |
            BindingFlags::Public);
        Console::WriteLine("// Instance Fields");
        PrintMembers(fi);

        // Instance properties.
        pi = t->GetProperties(BindingFlags::Instance | BindingFlags::NonPublic |
            BindingFlags::Public);
        Console::WriteLine ("// Instance Properties");
        PrintMembers(pi);

        // Instance events.
        ei = t->GetEvents(BindingFlags::Instance | BindingFlags::NonPublic |
            BindingFlags::Public);
        Console::WriteLine("// Instance Events");
        PrintMembers(ei);

        // Instance methods.
        mi = t->GetMethods(BindingFlags::Instance | BindingFlags::NonPublic
            | BindingFlags::Public);
        Console::WriteLine("// Instance Methods");
        PrintMembers(mi);

        Console::WriteLine("\r\nPress ENTER to exit.");
        Console::Read();
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
// </snippet4>
