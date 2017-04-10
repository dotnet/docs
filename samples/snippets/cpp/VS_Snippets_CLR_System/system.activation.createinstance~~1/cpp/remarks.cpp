
using namespace System;

public ref class Dummy
{
// <Snippet1>
    public:
        generic <typename T> where T:gcnew()
        static T Bar()
        {
            return gcnew T();
        }
// </Snippet1>
};


void main() {}

