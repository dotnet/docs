// <Snippet1>
using namespace System;
using namespace System::Reflection;

int main()
{
    MemberInfo^ m1 = Object::typeid->GetMethod("ToString");
    MemberInfo^ m2 = MemberInfo::typeid->GetMethod("ToString");

    Console::WriteLine("m1.DeclaringType: {0}", m1->DeclaringType);
    Console::WriteLine("m1.ReflectedType: {0}", m1->ReflectedType);
    Console::WriteLine();
    Console::WriteLine("m2.DeclaringType: {0}", m2->DeclaringType);
    Console::WriteLine("m2.ReflectedType: {0}", m2->ReflectedType);

    //Console::ReadLine();
}

/* This code example produces the following output:

m1.DeclaringType: System.Object
m1.ReflectedType: System.Object

m2.DeclaringType: System.Object
m2.ReflectedType: System.Reflection.MemberInfo
 */
// </Snippet1>
