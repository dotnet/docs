//<Snippet1>
using namespace System;

enum class Colors
{
   Red, Green, Blue, Yellow
};

enum class Styles
{
   Plaid, Striped, Tartan, Corduroy
};

int main()
{
   Console::WriteLine(  "The 4th value of the Colors Enum is {0}", Enum::GetName( Colors::typeid, 3 ) );
   Console::WriteLine(  "The 4th value of the Styles Enum is {0}", Enum::GetName( Styles::typeid, 3 ) );
}
// The example displays the following output:
//       The 4th value of the Colors Enum is Yellow
//       The 4th value of the Styles Enum is Corduroy
// </Snippet1>
