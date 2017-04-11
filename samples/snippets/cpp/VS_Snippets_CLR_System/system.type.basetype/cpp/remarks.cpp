
using namespace System;

// <Snippet1>
generic<typename U> ref class B { };
generic<typename T> ref class C : B<T> { };
// </Snippet1>


int main() {}

