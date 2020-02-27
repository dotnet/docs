
using namespace System;

// <Snippet1>
generic<typename T, typename U>
    public ref class Base { };
generic<typename V>
    public ref class Derived : Base<int, V> { };
// </Snippet1>

// <Snippet2>
generic<typename T> public ref class Outermost
{
public:
    generic<typename U> ref class Inner
    {
    public:
        generic<typename V> ref class Innermost1 {};
        ref class Innermost2 {};
    };
};
// </Snippet2>


int main() {}

