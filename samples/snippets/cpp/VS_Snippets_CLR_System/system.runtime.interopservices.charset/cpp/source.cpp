using namespace System;
using namespace System::Runtime::InteropServices;

// <Snippet1>
[StructLayout(LayoutKind::Sequential, CharSet=CharSet::Ansi)]
public ref struct MyPerson
{
public:
    String^ first;
    String^ last;
};
// </Snippet1>


int main()
{

}