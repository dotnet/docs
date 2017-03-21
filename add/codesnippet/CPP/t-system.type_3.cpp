#using <System.dll>

using namespace System;
using namespace System::Reflection;

void main()
{
    // Get a Type object representing the System.String type.
    Type^ t = String::typeid;

    MethodInfo^ substr = t->GetMethod("Substring", 
        gcnew array<Type^> { int::typeid, int::typeid });

    Object^ result = 
        substr->Invoke("Hello, World!", gcnew array<Object^> { 7, 5 });
    Console::WriteLine("{0} returned \"{1}\".", substr, result);
}

/* This code example produces the following output:

System.String Substring(Int32, Int32) returned "World".
 */