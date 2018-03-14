// <Snippet1>
using namespace System;
using namespace System::Text;

void main()
{
   String^ characters = "abc" + L'0' + "def";
   Console::WriteLine(characters->Length);        // Displays 7
}
// </Snippet1>
