// <snippet21>
using namespace System;

// <snippet22>
generic<typename T, typename U> ref class B {};
generic<typename V, typename W> ref class D : B<int, V> {};
// </snippet22>

class GenTypes
{
public:
    static void Main()
    {
    }
};

int main()
{
    GenTypes::Main();
}
// </snippet21>
