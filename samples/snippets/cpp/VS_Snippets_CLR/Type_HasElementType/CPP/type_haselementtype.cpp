// <Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Runtime::InteropServices;

public ref class Example
{
public:
    // This method is for demonstration purposes. It includes a
    // tracking reference (C# ref, VB ByRef), an out parameter,
    // and a pointer.
    void Test(int% x, [OutAttribute()] int% y, int* z)
    { 
        *z = x = y = 0; 
    }    
};

int main()
{
    // All of the following display 'True'.

    // Define a managed array, get its type, and display HasElementType. 
    array<Example^>^ examples = {gcnew Example(), gcnew Example()};
    Type^ t = examples::typeid; 
    Console::WriteLine(t);
    Console::WriteLine("HasElementType is '{0}' for managed array types.", t->HasElementType);

    // When you use Reflection Emit to emit dynamic methods and
    // assemblies, you can create array types using MakeArrayType.
    // The following creates the type 'array of Example'.
    t = Example::typeid->MakeArrayType();
    Console::WriteLine("HasElementType is '{0}' for managed array types.", t->HasElementType);

    // When you reflect over methods, HasElementType is true for
    // ref, out, and pointer parameter types. The following 
    // gets the Test method, defined above, and examines its
    // parameters.
    MethodInfo^ mi = Example::typeid->GetMethod("Test");
    array<ParameterInfo^>^ parms = mi->GetParameters();
    t = parms[0]->ParameterType;
    Console::WriteLine("HasElementType is '{0}' for ref parameter types.", t->HasElementType);
    t = parms[1]->ParameterType;
    Console::WriteLine("HasElementType is '{0}' for out parameter types.", t->HasElementType);
    t = parms[2]->ParameterType;
    Console::WriteLine("HasElementType is '{0}' for pointer parameter types.", t->HasElementType);

    // When you use Reflection Emit to emit dynamic methods and
    // assemblies, you can create pointer and ByRef types to use
    // when you define method parameters.
    t = Example::typeid->MakePointerType();
    Console::WriteLine("HasElementType is '{0}' for pointer types.", t->HasElementType);
    t = Example::typeid->MakeByRefType();
    Console::WriteLine("HasElementType is '{0}' for ByRef types.", t->HasElementType);
}
// </Snippet1>
