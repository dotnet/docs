// Completely rewrote sample 2/15/06 GlennHa
// <Snippet1>
using namespace System;
using namespace System::Reflection;

public ref class Example
{
public:
    void m_public() {};
internal:
    void m_internal() {};
protected:
    void m_protected() {};
protected public:
    void m_protected_public() {};
protected private:
    void m_protected_private() {};
};

void main()
{
    Console::WriteLine("\n{0,-30}{1,-18}{2}", "", "IsAssembly", "IsFamilyOrAssembly"); 
    Console::WriteLine("{0,-21}{1,-18}{2,-18}{3}\n", 
        "", "IsPublic", "IsFamily", "IsFamilyAndAssembly");

    for each (MethodBase^ m in Example::typeid->GetMethods(
        BindingFlags::Instance | BindingFlags::NonPublic | BindingFlags::Public))
    {
        if (m->Name->Substring(0, 1) == "m")
        {
            Console::WriteLine("{0,-21}{1,-9}{2,-9}{3,-9}{4,-9}{5,-9}", 
                m->Name,
                m->IsPublic,
                m->IsAssembly,
                m->IsFamily,
                m->IsFamilyOrAssembly,
                m->IsFamilyAndAssembly
            );
        }
    }
}

/* This code example produces output similar to the following:

                              IsAssembly        IsFamilyOrAssembly
                     IsPublic          IsFamily          IsFamilyAndAssembly

m_public             True     False    False    False    False
m_internal           False    True     False    False    False
m_protected          False    False    True     False    False
m_protected_public   False    False    False    True     False
m_protected_private  False    False    False    False    True
 */
// </Snippet1>
