// Completely rewrote sample 2/15/06 GlennHa
// <Snippet1>
using namespace System;
using namespace System::Reflection;

public ref class Example
{
public:
    int f_public;
internal:
    int f_internal;
protected:
    int f_protected;
protected public:
    int f_protected_public;
protected private:
    int f_protected_private;
};

void main()
{
    Console::WriteLine("\n{0,-30}{1,-18}{2}", "", "IsAssembly", "IsFamilyOrAssembly"); 
    Console::WriteLine("{0,-21}{1,-18}{2,-18}{3}\n", 
        "", "IsPublic", "IsFamily", "IsFamilyAndAssembly");

    for each (FieldInfo^ f in Example::typeid->GetFields(
        BindingFlags::Instance | BindingFlags::NonPublic | BindingFlags::Public))
    {
        Console::WriteLine("{0,-21}{1,-9}{2,-9}{3,-9}{4,-9}{5,-9}", 
            f->Name,
            f->IsPublic,
            f->IsAssembly,
            f->IsFamily,
            f->IsFamilyOrAssembly,
            f->IsFamilyAndAssembly
        );
    }
}

/* This code example produces output similar to the following:

                              IsAssembly        IsFamilyOrAssembly
                     IsPublic          IsFamily          IsFamilyAndAssembly

f_public             True     False    False    False    False
f_internal           False    True     False    False    False
f_protected          False    False    True     False    False
f_protected_public   False    False    False    True     False
f_protected_private  False    False    False    False    True
 */
// </Snippet1>
