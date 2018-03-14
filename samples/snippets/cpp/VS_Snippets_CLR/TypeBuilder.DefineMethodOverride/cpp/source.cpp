//<Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;

public interface class I 
{
    void M();
};

public ref class A 
{
public:
    virtual void M() { Console::WriteLine("In method A.M"); }
};

// The object of this code example is to emit code equivalent to
// the following C++ code:
//
public ref class C : A, I 
{
public:
    virtual void M() override 
    { 
        Console::WriteLine("Overriding A.M from C.M"); 
    }

private:
    // In order to provide a different implementation from C.M when 
    // emitting the following explicit interface implementation, 
    // it is necessary to use a MethodImpl.
    //
    virtual void IM() sealed = I::M 
    {
        Console::WriteLine("The I::M implementation of C");
    }
};

void main() 
{
    String^ name = "DefineMethodOverrideExample";
    AssemblyName^ asmName = gcnew AssemblyName(name);
    AssemblyBuilder^ ab = 
        AppDomain::CurrentDomain->DefineDynamicAssembly(
            asmName, AssemblyBuilderAccess::RunAndSave);
    ModuleBuilder^ mb = ab->DefineDynamicModule(name, name + ".dll");

    TypeBuilder^ tb = 
        mb->DefineType("C", TypeAttributes::Public, A::typeid);
    tb->AddInterfaceImplementation(I::typeid);

    // Build the method body for the explicit interface 
    // implementation. The name used for the method body 
    // can be anything. Here, it is the name of the method,
    // qualified by the interface name.
    //
    MethodBuilder^ mbIM = tb->DefineMethod("I.M", 
        MethodAttributes::Private | MethodAttributes::HideBySig |
            MethodAttributes::NewSlot | MethodAttributes::Virtual | 
            MethodAttributes::Final,
        nullptr,
        Type::EmptyTypes);
    ILGenerator^ il = mbIM->GetILGenerator();
    il->Emit(OpCodes::Ldstr, "The I.M implementation of C");
    il->Emit(OpCodes::Call, Console::typeid->GetMethod("WriteLine", 
        gcnew array<Type^> { String::typeid }));
    il->Emit(OpCodes::Ret);

    // DefineMethodOverride is used to associate the method 
    // body with the interface method that is being implemented.
    //
    tb->DefineMethodOverride(mbIM, I::typeid->GetMethod("M"));

    MethodBuilder^ mbM = tb->DefineMethod("M", 
        MethodAttributes::Public | MethodAttributes::ReuseSlot | 
            MethodAttributes::Virtual | MethodAttributes::HideBySig, 
        nullptr, 
        Type::EmptyTypes);
    il = mbM->GetILGenerator();
    il->Emit(OpCodes::Ldstr, "Overriding A.M from C.M");
    il->Emit(OpCodes::Call, Console::typeid->GetMethod("WriteLine", 
        gcnew array<Type^> { String::typeid }));
    il->Emit(OpCodes::Ret);

    Type^ tc = tb->CreateType();

    // Save the emitted assembly, to examine with Ildasm.exe.
    ab->Save(name + ".dll");

    Object^ test = Activator::CreateInstance(tc);

    MethodInfo^ mi = I::typeid->GetMethod("M");
    mi->Invoke(test, nullptr);

    mi = A::typeid->GetMethod("M");
    mi->Invoke(test, nullptr);
}

/* This code example produces the following output:

The I.M implementation of C
Overriding A.M from C.M
 */
//</Snippet1>
