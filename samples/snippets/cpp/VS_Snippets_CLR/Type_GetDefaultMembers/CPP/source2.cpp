// <snippet11>
using namespace System;
using namespace System::Reflection;

// <snippet12>
[DefaultMember("GetIVal")]
public ref class Class1
{
private:
    int ival;
    String^ sval;

public:
    Class1()
    {
        ival = 5050;
        sval = "6040";
    }

    int GetIVal()
    {
        return ival;
    }

    String^ GetSVal()
    {
        return sval;
    }
};
// </snippet12>

public ref class GetMemberExample
{
public:
    static void Main()
    {
        // <snippet13>
        Class1^ c = gcnew Class1();
        Object^ o;
        o = c->GetType()->InvokeMember("", BindingFlags::InvokeMethod, nullptr, c, gcnew array<Object^>(0));
        Console::WriteLine("Default member result: {0}", o);
        // </snippet13>

        GetDefMemberExample1();
        GetDefMemberExample2();
        GetDefMemberExample3();
    }

    static void GetDefMemberExample1()
    {
        // <snippet14>
        Type^ classType = Class1::typeid;
        Type^ attribType = DefaultMemberAttribute::typeid;
        DefaultMemberAttribute^ defMem =
            (DefaultMemberAttribute^)Attribute::GetCustomAttribute((MemberInfo^)classType, attribType);
        array<MemberInfo^>^ memInfo = classType->GetMember(defMem->MemberName);
        // </snippet14>
        if ( memInfo->Length > 0)
        {
            Console::WriteLine("Default Member: {0}", memInfo[0]->Name);
        }
    }

    static void GetDefMemberExample2()
    {
        // <snippet15>
        Type^ t = Class1::typeid;
        array<MemberInfo^>^ memInfo = t->GetDefaultMembers();
        // </snippet15>
        if ( memInfo->Length > 0)
        {
            Console::WriteLine("Default Member: {0}", memInfo[0]->Name);
        }
    }

    static void GetDefMemberExample3()
    {
        // <snippet16>
        Type^ t = Class1::typeid;
        array<Object^>^ customAttribs = t->GetCustomAttributes(DefaultMemberAttribute::typeid, false);
        if (customAttribs->Length > 0)
        {
            DefaultMemberAttribute^ defMem = (DefaultMemberAttribute^)customAttribs[0];
            array<MemberInfo^>^ memInfo = t->GetMember(defMem->MemberName);
            if (memInfo->Length > 0)
            {
                Console::WriteLine("Default Member: {0}", memInfo[0]->Name);
            }
        }
        // </snippet16>
    }
};

int main()
{
    GetMemberExample::Main();
}
// </snippet11>
