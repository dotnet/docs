
using namespace System;

// <Snippet1>
generic<typename T, typename U> public ref class B { };
generic<typename V> public ref class A
{
public:
    generic<typename X> B<V, X>^ GetSomething()
    {
        return gcnew B<V, X>();
    }
};
// </Snippet1>


int main() {}

