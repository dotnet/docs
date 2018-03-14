//<Snippet1>
using namespace System;
using namespace System::Reflection;

// The base class Parent contains an overloaded method PrintCall.
//
public ref class Parent
{
public:
    virtual void PrintCall()
    {
        Console::WriteLine("Parent's PrintCall()");
    }
public:
    virtual void PrintCall(int x)
    {
        Console::WriteLine("Parent's PrintCall({0})", x);
    }
};

// The derived class Child hides one overload of the inherited 
// method PrintCall.
//
public ref class Child : public Parent
{
public:
    void PrintCall(int i) new
    {
        Console::WriteLine("Child's PrintCall({0})", i);
    }
};

int main()
{
    Child^ childInstance = gcnew Child();

    // In C#, the method in the derived class hides by name and by
    // signature, so the overload in the derived class hides only one
    // of the overloads in the base class.
    //
    Console::WriteLine("------ List the overloads of PrintCall in the " +
        "derived class Child ------");
    Type^ t = childInstance->GetType();
    for each(MethodInfo^ minfo in t->GetMethods())
    {
        if (minfo->Name == "PrintCall")
        {
            Console::WriteLine("Overload of PrintCall: {0}" +
                " IsHideBySig = {1}, DeclaringType = {2}", 
                minfo, minfo->IsHideBySig, minfo->DeclaringType);
        }
    }

    // The method PrintCall in the derived class hides one overload of the 
    // method in Parent.  Contrast this with Visual Basic, which hides by
    // name instead of by name and signature.  In Visual Basic, the
    // parameterless overload of PrintCall would be unavailable from Child.
    //
    Console::WriteLine(
        "------ Call the overloads of PrintCall available in Child ------");
    childInstance->PrintCall();
    childInstance->PrintCall(42);

    // If Child is cast to the base type Parent, both overloads of the 
    // shadowed method can be called.
    //
    Console::WriteLine(
        "------ Call the shadowed overloads of PrintCall ------");
    Parent^ parentInstance = childInstance;
    parentInstance->PrintCall();
    parentInstance->PrintCall(42);
}

/* This code example produces the following output:

------ List the overloads of PrintCall in the derived class Child ------
Overload of PrintCall: Void PrintCall(Int32) IsHideBySig = True, DeclaringType = Child
Overload of PrintCall: Void PrintCall() IsHideBySig = True, DeclaringType = Parent
Overload of PrintCall: Void PrintCall(Int32) IsHideBySig = True, DeclaringType = Parent
------ Call the overloads of PrintCall available in Child ------
Parent's PrintCall()
Child's PrintCall(42)
------ Call the shadowed overloads of PrintCall ------
Parent's PrintCall()
Parent's PrintCall(42)

*/

//</Snippet1>

