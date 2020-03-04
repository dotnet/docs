// <Snippet1>
using namespace System;

public ref class MyBaseClass {};

public ref class MyDerivedClass: MyBaseClass{};

int main()
{
   MyBaseClass^ myBase = gcnew MyBaseClass;
   MyDerivedClass^ myDerived = gcnew MyDerivedClass;
   Object^ o = myDerived;
   MyBaseClass^ b = myDerived;
   Console::WriteLine( "mybase: Type is {0}", myBase->GetType() );
   Console::WriteLine( "myDerived: Type is {0}", myDerived->GetType() );
   Console::WriteLine( "object o = myDerived: Type is {0}", o->GetType() );
   Console::WriteLine( "MyBaseClass b = myDerived: Type is {0}", b->GetType() );
}

/*

This code produces the following output.

mybase: Type is MyBaseClass
myDerived: Type is MyDerivedClass
object o = myDerived: Type is MyDerivedClass
MyBaseClass b = myDerived: Type is MyDerivedClass 

*/
// </Snippet1>
