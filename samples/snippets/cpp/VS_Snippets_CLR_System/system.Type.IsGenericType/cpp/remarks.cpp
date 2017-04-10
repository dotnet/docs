
using namespace System;
using namespace System::Reflection;

// <Snippet2>
generic<typename T, typename U> public ref class Base {};

generic<typename T> public ref class G {};

generic<typename V> public ref class Derived : Base<String^, V>
{
public:
    G<Derived<V>^>^ F;

    ref class Nested {};
};
// </Snippet2>


void main() {}

