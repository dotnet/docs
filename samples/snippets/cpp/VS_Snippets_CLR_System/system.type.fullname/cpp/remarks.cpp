
using namespace System;

// <Snippet1>
generic<typename TBase> 
    public ref class Base { };
generic<typename TDerived>
    public ref class Derived : Base<TDerived> { };
// </Snippet1>


int main() {}

